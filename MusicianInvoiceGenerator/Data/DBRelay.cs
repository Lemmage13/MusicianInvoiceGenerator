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
        /// <summary>
        /// Singleton class that handles access to the other database classes
        /// This class ensures that database modifications are made in a logical order
        /// </summary>

        private static DBRelay instance;
        private static readonly object threadlock = new object();
        public static DBRelay Instance
        {
            get{
                if (instance == null)
                {
                    lock (threadlock)
                    {
                        if (instance == null)
                        {
                            instance = new DBRelay();
                        }
                    }
                }
                return instance;
            }
        }

        private InvoiceDataAccess invoiceDataAccess;
        private ContactsDataAccess contactsDataAccess;
        private GigDataAccess gigDataAccess;

        public event EventHandler DBUpdate;

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
        public void UpdateInvoice(StoredInvoice invoice)
        {
            contactsDataAccess.UpdateContact((int)invoice.SenderContact.Id, invoice.SenderContact);
            contactsDataAccess.UpdateContact((int)invoice.RecipientContact.Id, invoice.RecipientContact);

            invoiceDataAccess.UpdateInvoice(invoice);

            //Old gigs deleted to be replaced with modified gigs
            gigDataAccess.DeleteInvoiceGigs(invoice.invoiceNo);
            foreach (GigModel g in invoice.Gigs)
            {
                gigDataAccess.AddGig(g, invoice);
            }
            Debug.WriteLine("Invoice Modified,Id: " + invoice.invoiceNo);
            DBModified();
        }
        public void DeleteInvoice(StoredInvoice invoice)
        {
            gigDataAccess.DeleteInvoiceGigs(invoice.invoiceNo);

            invoiceDataAccess.DeleteEntry(invoice.invoiceNo);

            if(CanDeleteContact((int)invoice.SenderContact.Id, invoice.invoiceNo)) { contactsDataAccess.DeleteEntry((int)invoice.SenderContact.Id); }
            if (CanDeleteContact((int)invoice.RecipientContact.Id, invoice.invoiceNo)) { contactsDataAccess.DeleteEntry((int)invoice.RecipientContact.Id); }
            DBModified();
        }
        private bool CanDeleteContact(int cid, int iid)
        {
            List<int> ids = invoiceDataAccess.GetIdsUsingContact(cid);
            foreach (int id in ids)
            {
                if(id != iid)
                {
                    return false;
                }
            }
            return true;
        }
        private void DBModified()
        {
            DBUpdate?.Invoke(typeof(DBRelay), EventArgs.Empty);
        }
        public List<StoredInvoice> GetInvoices(int page, int pagesize, DateTime startDate, DateTime endDate, bool? paid)
        {
            return invoiceDataAccess.GetInvoices(new InvoiceViewStringBuilder(page, pagesize, startDate, endDate, paid));
        }
        public List<ContactDetails> GetContacts(int page, int pagesize, string contains)
        {
            return contactsDataAccess.GetContacts();
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