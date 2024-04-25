using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Models
{
    public class StoredInvoice : Invoice
    {
        //StoredInvoice is a representation of an invoice that is stored in the database, it inherits from Invoice
        //This class simplifies logic detemining whether an invoice is stored or not
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
