using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            string selectString = $"SELECT TOP 1 Id FROM {table} WHERE " +
                $"Name = '{c.Name}' AND " +
                $"PhoneNumber = '{c.PhoneNumber}' AND " +
                $"AddrsL1 = '{c.Line1}' AND " +
                $"AddrsL2 = '{c.Line2}' AND " +
                $"AddrsTown = '{c.Town}' AND " +
                $"AddrsPostCode = '{c.Postcode}'";
            int? id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(selectString, connection);
                var idTemp = selectCommand.ExecuteScalar();
                if (idTemp == null)
                {
                    Debug.WriteLine("Contact Not Found");
                    id = null;
                }
                else { id = Convert.ToInt32(idTemp); Debug.WriteLine("Contact Found"); }
                connection.Close();
            }
            return id; //TEMPORARY
        }
    }
}
