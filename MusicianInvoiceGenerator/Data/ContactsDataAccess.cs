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
        public void AddContact(ContactDetails c)
        {
            string insertString = "INSERT INTO Contacts (Name, PhoneNumber, AddrsL1, AddrsL2, AddrsTown, AddrsPostCode) VALUES " +
                $"('{c.Name}','{c.PhoneNumber}','{c.Line1}','{c.Line2}','{c.Town}','{c.Postcode}')";
            Debug.WriteLine(insertString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
