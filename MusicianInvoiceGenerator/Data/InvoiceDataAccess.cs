using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MusicianInvoiceGenerator.Models;
using System.Windows.Controls;
using System.Diagnostics;

namespace MusicianInvoiceGenerator.Data
{
    internal class InvoiceDataAccess : BaseDataAccess
    {
        public InvoiceDataAccess() : base("Invoices")
        { }
        public void AddInvoice(Invoice i, int senderId, int recipientId)
        {
            string insertString = $"INSERT INTO {table} VALUES " +
                $"({i.invoiceNo},{senderId},{recipientId},'{i.SenderBankDetails.SortCode}'," +
                $"'{i.SenderBankDetails.AccountNumber}'," +
                $"'{ DateTimeToDateString(i.InvoiceDate) }','{ DateTimeToDateString(i.DueDate) }');";
            Debug.WriteLine(insertString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
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
        private string DateTimeToDateString(DateTime d) // POSSIBLY UNNECCESSARY
        {
            return d.ToString("yyyy") + "-" + d.ToString("MM") + "-" + d.ToString("dd");
        }
    }
}
