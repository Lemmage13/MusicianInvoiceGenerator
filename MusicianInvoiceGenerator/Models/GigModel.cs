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
        public double Rate;

        public GigModel(string details, double rate)
        {
            Details = details;
            Rate = rate;
        }
    }
}
