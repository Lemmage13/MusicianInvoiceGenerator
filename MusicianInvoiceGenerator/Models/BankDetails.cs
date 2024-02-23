using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class BankDetails
    {
        public string SortCode;
        public string AccountNumber;
        public BankDetails(string sortCode, string accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}
