using MusicianInvoiceGenerator.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            invoiceNo = InvoiceNumGenerator(invoiceDate);
        }
        public Invoice(int id, ContactDetails senderContact, BankDetails senderBankDetails, ContactDetails recipientContact, List<GigModel> gigs,
            DateTime invoiceDate, DateTime dueDate)
        {
            invoiceNo = id;
            SenderContact = senderContact;
            SenderBankDetails = senderBankDetails;
            RecipientContact = recipientContact;
            Gigs = gigs;
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
        }
        private protected int InvoiceNumGenerator(DateTime iDate)
        {
            string numGen = $"{iDate.ToString("yyyy")}{iDate.ToString("MM")}{iDate.ToString("dd")}0";
            int invoiceNo = Convert.ToInt32(numGen);
            while(!VerifyInvoiceNumber(invoiceNo))
            {
                invoiceNo++;
            }
            Debug.WriteLine(invoiceNo.ToString());
            return invoiceNo;
        }
        private bool VerifyInvoiceNumber(int i)
        {
            InvoiceDataAccess da = new InvoiceDataAccess();
            return da.InvoiceIdAvailable(i);
        }
    }
}