using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class GigModel
    {
        public string Details;
        public decimal Rate;

        public GigModel(string details, decimal rate)
        {
            Details = details;
            Rate = rate;
        }
    }
}
