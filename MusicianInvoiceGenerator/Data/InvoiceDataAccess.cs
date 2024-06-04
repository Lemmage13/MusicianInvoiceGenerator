using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MusicianInvoiceGenerator.Models;
using System.Windows.Controls;
using System.Diagnostics;
using System.Data;

namespace MusicianInvoiceGenerator.Data
{
    internal class InvoiceDataAccess : BaseDataAccess
    {
        public InvoiceDataAccess() : base("Invoices")
        { }
        public void AddInvoice(Invoice i, int senderId, int recipientId)
        {
            string insertString = $"INSERT INTO {table} (Id, SenderContactId, RecipientContactId, SortCode, AccountNumber, InvoiceDate, DueDate) VALUES " +
                $"({i.invoiceNo},{senderId},{recipientId},'{i.SenderBankDetails.SortCode}'," +
                $"'{i.SenderBankDetails.AccountNumber}'," +
                $"'{ DateTimeToDateString(i.InvoiceDate) }','{ DateTimeToDateString(i.DueDate) }');";
            Debug.WriteLine(insertString);
            ExecuteNonQuery(insertString);
        }
        public void UpdateInvoice(StoredInvoice i)
        {
            string updateString = $"UPDATE {table} SET SortCode = '{i.SenderBankDetails.SortCode}', AccountNumber = '{i.SenderBankDetails.AccountNumber}', " +
                $"InvoiceDate = '{DateTimeToDateString(i.InvoiceDate)}', DueDate = '{DateTimeToDateString(i.DueDate)}' WHERE Id = {i.invoiceNo}";
            Debug.WriteLine(updateString);
            ExecuteNonQuery(updateString);
        }
        public void UpdateSenderId(int invoiceId,int newId)
        {
            string updateString = $"UPDATE {table} SET SenderContactId = '{newId}' WHERE Id = '{invoiceId}'";
            Debug.WriteLine(updateString);
            ExecuteNonQuery(updateString);
        }
        public void UpdateRecipientId(int invoiceId, int newId)
        {
            string updateString = $"UPDATE {table} SET RecipientContactId = '{newId}' WHERE Id = '{invoiceId}'";
            Debug.WriteLine(updateString);
            ExecuteNonQuery(updateString);
        }
        public bool InvoiceIdAvailable(int id)
        {
            string queryString = $"SELECT COUNT(*) FROM {table} WHERE Id = {id}";
            int count;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand countCommand = new SqlCommand(queryString, connection);
                count = Convert.ToInt32(countCommand.ExecuteScalar());
                connection.Close();
            }
            if (count > 0) { return false; }
            return true;
        }
        public List<StoredInvoice> GetInvoices(InvoiceViewStringBuilder builder)
        {
            string queryString = $"SELECT * FROM {table}" + builder.BuildQueryParametersString();
            Debug.WriteLine(queryString);
            List<StoredInvoice> invoices = new List<StoredInvoice>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Debug.WriteLine(reader.GetInt32(0).ToString());
                    invoices.Add(ReadInvoiceRow(reader));
                }
                connection.Close();
            }
            return invoices;
        }
        public List<int> GetIdsUsingContact(int cid)
        {
            string queryString = $"SELECT Id FROM {table} WHERE SenderContactId = '{cid}' OR RecipientContactId = '{cid}'";
            Debug.WriteLine(queryString);
            List<int> ids = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString , connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }
                connection.Close();
            }
            return ids;
        }
        public void UpdatePaid(int id, bool p)
        {
            string updatestring = $"UPDATE {table} SET Paid = '{Convert.ToInt16(p)}' WHERE Id = '{id}'";
            Debug.WriteLine (updatestring);
            ExecuteNonQuery(updatestring);
        }
        private StoredInvoice ReadInvoiceRow(IDataRecord invoiceRecord)
        {
            int id = invoiceRecord.GetInt32(0);
            ContactDetails senderContact = new ContactsDataAccess().GetContactById(invoiceRecord.GetInt32(1));
            ContactDetails recipientContact = new ContactsDataAccess().GetContactById(invoiceRecord.GetInt32(2));
            BankDetails senderBankDetails = new BankDetails(invoiceRecord.GetString(3), invoiceRecord.GetString(4));
            DateTime date = invoiceRecord.GetDateTime(5);
            DateTime due = invoiceRecord.GetDateTime(6);
            bool paid = invoiceRecord.GetBoolean(7);

            List<GigModel> gigs = new GigDataAccess().GetGigByInvoice(invoiceRecord.GetInt32(0));

            return new StoredInvoice(id, senderContact, senderBankDetails, recipientContact, gigs, date, due, paid);
        }
        private string DateTimeToDateString(DateTime d) // POSSIBLY UNNECCESSARY
        {
            return d.ToString("yyyy") + "-" + d.ToString("MM") + "-" + d.ToString("dd");
        }
    }
}
