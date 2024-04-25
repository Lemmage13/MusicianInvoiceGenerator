using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace MusicianInvoiceGenerator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private StoredInvoice? invoice;

        private ContactEntryViewModel _senderContact;
        public ContactEntryViewModel SenderContact
        {
            get { return _senderContact; }
            set
            {
                _senderContact = value;
                OnPropertyChanged(nameof(SenderContact));
            }
        }
        private ContactEntryViewModel _recipientContact;
        public ContactEntryViewModel RecipientContact
        {
            get { return _recipientContact; }
            set
            {
                _recipientContact = value;
                OnPropertyChanged(nameof(RecipientContact));
            }
        }
        private BankDetailEntryViewModel _bankDetails;
        public BankDetailEntryViewModel BankDetails
        {
            get { return _bankDetails; }
            set
            {
                _bankDetails = value;
                OnPropertyChanged(nameof(BankDetails));
            }
        }
        private GigEntryViewModel _gigEntry;
        public GigEntryViewModel GigEntry
        {
            get { return _gigEntry; }
            set
            {
                _gigEntry = value;
                OnPropertyChanged(nameof(GigEntry));
            }
        }
        private DateTime _invoiceDate;
        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                _invoiceDate = value;
                OnPropertyChanged(nameof(InvoiceDate));
                if (!dueDateModified)
                {
                    _dueDate = value.AddDays(30);
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }
        private bool dueDateModified = false;
        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                dueDateModified = true;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public MainWindowViewModel()
        {
            _senderContact = new ContactEntryViewModel();
            _recipientContact = new ContactEntryViewModel();
            _bankDetails = new BankDetailEntryViewModel();
            _gigEntry = new GigEntryViewModel();
            _invoiceDate = DateTime.Now;
            _dueDate= InvoiceDate.AddDays(30);
        }
        public MainWindowViewModel(StoredInvoice i)
        {
            invoice = i;
            _senderContact = new ContactEntryViewModel(invoice.SenderContact);
            _recipientContact = new ContactEntryViewModel(invoice.RecipientContact);
            _bankDetails= new BankDetailEntryViewModel(invoice.SenderBankDetails);
            _gigEntry = new GigEntryViewModel(invoice.Gigs);
            _invoiceDate = invoice.InvoiceDate;
            _dueDate= invoice.DueDate;
        }
        private ICommand? _previewInvoice;
        public ICommand PreviewInvoice
        {
            get
            {
                if(_previewInvoice == null)
                {
                    if(invoice != null) { _previewInvoice = new RelayCommand(param => OpenPreviewWindowModify()); return _previewInvoice; }
                    _previewInvoice = new RelayCommand(param => OpenPreviewWindowCreate(), pred => CanGenerateInvoice());
                }
                return _previewInvoice;
            }
        }
        private bool CanGenerateInvoice()
        {
            if (SenderContact.Name == String.Empty) { return false; }
            if (RecipientContact.Name == String.Empty) { return false; }
            if (BankDetails.SortCode == String.Empty || BankDetails.AccountNumber == String.Empty) { return false; }
            return true;
        }
        private void OpenPreviewWindowModify()
        {
            InvoicePreviewViewModel prevVM = new InvoicePreviewViewModel(UpdateStoredInvoiceValues(invoice), 1);
            InvoicePreviewWindow prevWindow = new InvoicePreviewWindow();
            prevWindow.DataContext = prevVM;
            prevWindow.Show();
        }
        private StoredInvoice UpdateStoredInvoiceValues(StoredInvoice i)
        {
            i.SenderContact = SenderContact.MakeModel((int)i.SenderContact.Id);
            i.SenderBankDetails = BankDetails.MakeModel();
            i.RecipientContact = RecipientContact.MakeModel((int)i.RecipientContact.Id);
            i.Gigs = GigEntry.MakeModel();
            i.InvoiceDate = InvoiceDate;
            i.DueDate = DueDate;

            return i;
        }
        private void OpenPreviewWindowCreate()
        {
            InvoicePreviewViewModel prevVM = new InvoicePreviewViewModel(new Invoice(SenderContact.MakeModel(), BankDetails.MakeModel(), RecipientContact.MakeModel(), GigEntry.MakeModel(), InvoiceDate, DueDate));
            InvoicePreviewWindow prevWindow = new InvoicePreviewWindow();
            prevWindow.DataContext = prevVM;
            prevWindow.Show();
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
