using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class StoredInvoice : Invoice
    {
        public StoredInvoice(int id, ContactDetails senderContact, BankDetails senderBankDetails, ContactDetails recipientContact, 
            List<GigModel> gigs, DateTime invoiceDate, DateTime dueDate, bool paid) : base(senderContact, senderBankDetails, 
            recipientContact, gigs, invoiceDate, dueDate)
        {
            invoiceNo = id;
            SenderContact = senderContact;
            SenderBankDetails = senderBankDetails;
            RecipientContact = recipientContact;
            Gigs = gigs;
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
            Paid = paid;
        }
    }
}
