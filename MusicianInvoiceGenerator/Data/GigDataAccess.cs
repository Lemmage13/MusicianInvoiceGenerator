﻿using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            ExecuteNonQuery(insertString);
        }
        public void DeleteInvoiceGigs(int id)
        {
            string deleteString = $"DELETE FROM {table} WHERE InvoiceId = '{id}'";
            Debug.WriteLine(deleteString);
            ExecuteNonQuery(deleteString);
        }
        public void UpdateGig(int id, GigModel g)
        {
            string updateString = $"UPDATE {table} SET Details = '{g.Details}', Rate = '{g.Rate}' " +
                $"WHERE Id = '{g.id}'";
            Debug.WriteLine(updateString);
            ExecuteNonQuery(updateString);
        }
        public List<GigModel> GetGigByInvoice(int id)
        {
            List<GigModel> g = new List<GigModel>();
            string selectString = $"SELECT * FROM {table} WHERE " +
                $"InvoiceId = {id}";
            Debug.WriteLine(selectString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(selectString, connection);
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    g.Add(ReadGigRow(reader));
                }
                reader.Close();
                connection.Close();
            }
            return g;
        }
        private GigModel ReadGigRow(IDataRecord gigRecord)
        {
            return new GigModel(gigRecord.GetInt32(0), gigRecord.GetString(2), gigRecord.GetDecimal(3));
        }
    }
}
