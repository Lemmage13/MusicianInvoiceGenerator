using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    //BankDetails is an object representing the bank details of the sender of an invoice
    //it is a separate object that is not stored in the database as it may need some security logic in the future
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
