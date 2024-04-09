using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class Invoice
    {
        public int invoiceNo; //must be unique
        public ContactDetails SenderContact;
        public BankDetails SenderBankDetails;
        public ContactDetails RecipientContact;
        public List<GigModel> Gigs;

        public DateTime InvoiceDate;
        public DateTime DueDate;

        public Invoice(ContactDetails senderContact, BankDetails senderBankDetails, ContactDetails recipientContact, List<GigModel> gigs,
            DateTime invoiceDate, DateTime dueDate)
        {
            SenderContact = senderContact;
            SenderBankDetails = senderBankDetails;
            RecipientContact = recipientContact;
            Gigs = gigs;
            InvoiceDate = invoiceDate;
            DueDate = dueDate;

            invoiceNo = InvoiceNumGenerator();
        }
        private int InvoiceNumGenerator()
        {
            //Needs to automatically modify string to ensure number is unique
            return Convert.ToInt32(InvoiceDate.Year.ToString() + InvoiceDate.Month.ToString() + InvoiceDate.Day.ToString());
        }
    }
}