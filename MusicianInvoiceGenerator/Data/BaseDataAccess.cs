using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Data
{
    internal class BaseDataAccess
    {
        private protected string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InvoiceDBS"].ConnectionString;
        private protected string table;

        public BaseDataAccess(string t)
        {
            table = t;
        }

        public int Count()
        {
            string countString = $"SELECT COUNT (*) FROM { table }";
            int count;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand countCommand = new SqlCommand(countString, connection);
                count = Convert.ToInt32(countCommand.ExecuteScalar());
                connection.Close();
            }
            return count;
        }
        public void DeleteEntry(int id)
        {
            string deleteString = $"DELETE FROM {table} WHERE Id = '{id}'";
            Debug.WriteLine(deleteString);
            ExecuteNonQuery(deleteString);
        }
        protected void ExecuteNonQuery(string cmdString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(cmdString, connection);
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
