using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class GigModel
    {
        public int? id;
        public string Details;
        public decimal Rate;

        public GigModel(string details, decimal rate)
        {
            Details = details;
            Rate = rate;
        }
        public GigModel(int id, string details, decimal rate)
        {
            this.id = id;
            this.Details = details;
            this.Rate = rate;
        }
    }
}