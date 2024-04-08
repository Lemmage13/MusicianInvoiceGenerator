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
    internal class GigDataAccess : BaseDataAccess
    {
        public GigDataAccess() : base("Gigs") { }
        public void AddGig(GigModel g, Invoice i)
        {
            string insertString = "INSERT INTO Gigs (InvoiceId, Details, Rate) VALUES " +
                $"({i.invoiceNo},'{g.Details}',{g.Rate})";
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
