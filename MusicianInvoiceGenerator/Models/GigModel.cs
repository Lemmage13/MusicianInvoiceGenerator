using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class GigModel
    {
        public double Rate;
        public string Details;

        public GigModel()
        {
            Rate = 0;
            Details = string.Empty;
        }
    }
}
