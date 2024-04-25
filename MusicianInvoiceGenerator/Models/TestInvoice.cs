using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    internal class TestInvoice : Invoice
    {
        //Test invoice is a class used during testing to simplify invoice generation and produce consistent results
        public TestInvoice() : base(new ContactDetails("sender", "07*******", "sl1", "sl2", "stown", "SD11 1AA"),
            new BankDetails("010101", "1100110011"),
            new ContactDetails("recipient", "07*******", "rl1", "rl2", "rtown", "RP11 1AA"),
            new List<GigModel> { new GigModel("test details", 100) },
            DateTime.Today,
            DateTime.Today.AddDays(30))
        {
            invoiceNo = InvoiceNumGenerator(DateTime.Today);
        }
    }
}
