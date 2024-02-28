using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicianInvoiceGenerator.Models;

namespace MusicianInvoiceGenerator.ViewModels
{
    class InvoicePreviewViewModel
    {
        //control -> XPS
        //XPS -> PDF via PDF printer drivers
        //invoice object exposed as variables for invoice display
        public Invoice Invoice { get; set; }

        public InvoicePreviewViewModel(Invoice i)
        {
            Invoice = i;
            InvoiceNumber = Invoice.invoiceNo;
            InvoiceDate = Invoice.InvoiceDate.ToString();
            DueDate = Invoice.DueDate.ToString();

            SenderName = Invoice.SenderContact.Name;
            SenderPhoneNo = Invoice.SenderContact.PhoneNumber;
            SenderL1 = Invoice.SenderContact.Line1;
            SenderL2 = Invoice.SenderContact.Line2;
            SenderTown = Invoice.SenderContact.Town;
            SenderPostcode = Invoice.SenderContact.Postcode;

            RecipientName = Invoice.RecipientContact.Name;
            RecipientPhoneNo = Invoice.RecipientContact.PhoneNumber;
            RecipientL1 = Invoice.RecipientContact.Line1;
            RecipientL2 = Invoice.RecipientContact.Line2;
            RecipientTown = Invoice.RecipientContact.Town;
            RecipientPostcode = Invoice.RecipientContact.Postcode;

            SortCode = Invoice.SenderBankDetails.SortCode;
            AccountNumber = Invoice.SenderBankDetails.AccountNumber;
        }

        //invoice details
        public string InvoiceNumber;
        public string InvoiceDate;
        public string DueDate;

        //Sender contact details
        public string SenderName;
        public string SenderPhoneNo;
        public string SenderL1;
        public string SenderL2;
        public string SenderTown;
        public string SenderPostcode;

        //Recipient contact details
        public string RecipientName;
        public string RecipientPhoneNo;
        public string RecipientL1;
        public string RecipientL2;
        public string RecipientTown;
        public string RecipientPostcode;

        //Bank Details
        public string SortCode;
        public string AccountNumber;

        //gigs list REDO LATER
        public List<string> Gigs;
    }
}
