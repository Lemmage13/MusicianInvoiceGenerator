using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Data
{
    internal class ContactsDataAccess : BaseDataAccess
    {
        public ContactsDataAccess() : base("Contacts")
        {

        }
        public int AddContact(ContactDetails c)
        {
            int id;
            string insertString = $"INSERT INTO {table} (Name, PhoneNumber, AddrsL1, AddrsL2, AddrsTown, AddrsPostCode) VALUES " +
                $"('{c.Name}','{c.PhoneNumber}','{c.Line1}','{c.Line2}','{c.Town}','{c.Postcode}')";
            string getIdString = $"SELECT TOP 1 Id FROM {table} ORDER BY Id Desc";
            Debug.WriteLine(insertString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.ExecuteNonQuery();
                SqlCommand getIdCommand = new SqlCommand(getIdString, connection);
                var idTemp = getIdCommand.ExecuteScalar();
                if (idTemp == null) { throw new ArgumentException("idTemp cannot be null", nameof(idTemp)); }
                id = Convert.ToInt32(idTemp);
                connection.Close();
            }
            return id;
        }
        public int? FindContact(ContactDetails c)
        {
            //Find entry based on name
            //verify all other fields
            //if all fields match return Id
            return null; //TEMPORARY
        }
    }
}
