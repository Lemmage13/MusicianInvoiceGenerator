using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicianInvoiceGenerator.Models;

namespace MusicianInvoiceGenerator.Data
{
    public class DBRelay
    {
        private InvoiceDataAccess invoiceDataAccess;
        private ContactsDataAccess contactsDataAccess;
        private GigDataAccess gigDataAccess;

        public DBRelay()
        {
            invoiceDataAccess = new InvoiceDataAccess();
            contactsDataAccess = new ContactsDataAccess();
            gigDataAccess = new GigDataAccess();
        }
        public void SaveInvoice(Invoice invoice)
        {
            //get or save contacts
            int senderContactId = SetContact(invoice.SenderContact);
            int recipientContactId = SetContact(invoice.RecipientContact);
            //save invoice
            VerifyId(invoice.invoiceNo);
            invoiceDataAccess.AddInvoice(invoice, senderContactId, recipientContactId);
            //save gigs
            foreach(GigModel g in invoice.Gigs)
            {
                gigDataAccess.AddGig(g, invoice);
            }
            Debug.WriteLine($"Invoice added, Id: {invoice.invoiceNo}");
        }
        public List<Invoice> GetInvoices(int page, int pagesize, DateTime startDate)
        {
            return invoiceDataAccess.GetInvoices(new InvoiceViewStringBuilder(page, pagesize, startDate));
        }
        private int SetContact(ContactDetails contact)
        {
            int id = contactsDataAccess.FindContact(contact) ?? contactsDataAccess.AddContact(contact);
            return id;
        }
        private void VerifyId(int id)
        {
            if (!invoiceDataAccess.InvoiceIdAvailable(id))
            {
                throw new Exception("Invoice Id already in use at point of addition");
            }
        }
    }
}