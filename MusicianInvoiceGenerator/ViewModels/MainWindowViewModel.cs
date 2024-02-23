using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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

        private void GenerateInvoice()
        {

        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
