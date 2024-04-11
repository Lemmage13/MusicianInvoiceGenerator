using MusicianInvoiceGenerator.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Media;
using MusicianInvoiceGenerator.Views.Controls;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using MusicianInvoiceGenerator.Views;
using System.Windows.Input;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.ViewModels.Functionality;

namespace MusicianInvoiceGenerator.ViewModels
{
    class InvoicePreviewViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        //control -> XPS
        //XPS -> PDF via PDF printer drivers
        //invoice object exposed as variables for invoice display
        public Invoice Invoice { get; set; }

        public InvoicePreviewViewModel(Invoice i)
        {
            Invoice = i;
            _invoiceNumber = Invoice.invoiceNo;
            _invoiceDate = Invoice.InvoiceDate.ToString("dd/MM/yyyy");
            _dueDate = Invoice.DueDate.ToString("dd/MM/yyyy");

            _senderName = Invoice.SenderContact.Name;
            _senderPhoneNo = Invoice.SenderContact.PhoneNumber;
            _senderL1 = Invoice.SenderContact.Line1;
            _senderL2 = Invoice.SenderContact.Line2;
            _senderTown = Invoice.SenderContact.Town;
            _senderPostcode = Invoice.SenderContact.Postcode;

            _recipientName = Invoice.RecipientContact.Name;
            _recipientPhoneNo = Invoice.RecipientContact.PhoneNumber;
            _recipientL1 = Invoice.RecipientContact.Line1;
            _recipientL2 = Invoice.RecipientContact.Line2;
            _recipientTown = Invoice.RecipientContact.Town;
            _recipientPostcode = Invoice.RecipientContact.Postcode;

            _sortCode = Invoice.SenderBankDetails.SortCode;
            _accountNumber = Invoice.SenderBankDetails.AccountNumber;

            _gigList = GetGigTxts(Invoice);
            _rateTotal = GetTotalRate(Invoice);

        }
        private string GetTotalRate(Invoice i)
        {
            double totalRate = 0;
            foreach (GigModel g in i.Gigs)
            {
                totalRate += g.Rate;
            }
            return totalRate.ToString();
        }
        private List<GigTxt> GetGigTxts(Invoice i)
        {
            List<GigTxt> gigTxtList = new List<GigTxt>();
            foreach (GigModel g in i.Gigs)
            {
                gigTxtList.Add(new GigTxt(g.Details, g.Rate.ToString()));
            }
            return gigTxtList;
        }

        #region Invoice Details
        //invoice details
        private int _invoiceNumber;
        public int InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                if (_invoiceNumber != value)
                {
                    _invoiceNumber = value;
                    OnPropertyChanged(nameof(InvoiceNumber));
                }
            }
        }
        private string _invoiceDate;
        public string InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                if (_invoiceDate != value)
                {
                    _invoiceDate = value;
                    OnPropertyChanged(nameof(InvoiceDate));
                }
            }
        }
        private string _dueDate;
        public string DueDate
        {
            get { return _dueDate; }
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }
        private string _senderName;
        public string SenderName
        {
            get { return _senderName; }
            set
            {
                if (_senderName != value)
                {
                    _senderName = value;
                    OnPropertyChanged(nameof(SenderName));
                }
            }
        }
        private string _senderPhoneNo;
        public string SenderPhoneNo
        {
            get { return _senderPhoneNo; }
            set
            {
                if (_senderPhoneNo != value)
                {
                    _senderPhoneNo = value;
                    OnPropertyChanged(nameof(SenderPhoneNo));
                }
            }
        }
        private string _senderL1;
        public string SenderL1
        {
            get { return _senderL1; }
            set
            {
                if (_senderL1 != value)
                {
                    _senderL1 = value;
                    OnPropertyChanged(nameof(SenderL1));
                }
            }
        }
        private string _senderL2;
        public string SenderL2
        {
            get { return _senderL2; }
            set
            {
                if (_senderL2 != value)
                {
                    _senderL2 = value;
                    OnPropertyChanged(nameof(SenderL2));
                }
            }
        }
        private string _senderTown;
        public string SenderTown
        {
            get { return _senderTown; }
            set
            {
                if (_senderTown != value)
                {
                    _senderTown = value;
                    OnPropertyChanged(nameof(SenderTown));
                }
            }
        }
        private string _senderPostcode;
        public string SenderPostcode
        {
            get { return _senderPostcode; }
            set
            {
                if (_senderPostcode != value)
                {
                    _senderPostcode = value;
                    OnPropertyChanged(nameof(SenderPostcode));
                }
            }
        }
        private string _recipientName;
        public string RecipientName
        {
            get { return _recipientName; }
            set
            {
                if (_recipientName != value)
                {
                    _recipientName = value;
                    OnPropertyChanged(nameof(RecipientName));
                }
            }
        }
        private string _recipientPhoneNo;
        public string RecipientPhoneNo
        {
            get { return _recipientPhoneNo; }
            set
            {
                if (_recipientPhoneNo != value)
                {
                    _recipientPhoneNo = value;
                    OnPropertyChanged(nameof(RecipientPhoneNo));
                }
            }
        }
        private string _recipientL1;
        public string RecipientL1
        {
            get { return _recipientL1; }
            set
            {
                if (_recipientL1 != value)
                {
                    _recipientL1 = value;
                    OnPropertyChanged(nameof(RecipientL1));
                }
            }
        }
        private string _recipientL2;
        public string RecipientL2
        {
            get { return _recipientL2; }
            set
            {
                if (_recipientL2 != value)
                {
                    _recipientL2 = value;
                    OnPropertyChanged(nameof(RecipientL2));
                }
            }
        }
        private string _recipientTown;
        public string RecipientTown
        {
            get { return _recipientTown; }
            set
            {
                if (_recipientTown != value)
                {
                    _recipientTown = value;
                    OnPropertyChanged(nameof(RecipientTown));
                }
            }
        }
        private string _recipientPostcode;
        public string RecipientPostcode
        {
            get { return _recipientPostcode; }
            set
            {
                if (_recipientPostcode != value)
                {
                    _recipientPostcode = value;
                    OnPropertyChanged(nameof(RecipientPostcode));
                }
            }
        }
        private string _sortCode;
        public string SortCode
        {
            get { return _sortCode; }
            set
            {
                if (_sortCode != value)
                {
                    _sortCode = value;
                    OnPropertyChanged(nameof(SortCode));
                }
            }
        }
        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (_accountNumber != value)
                {
                    _accountNumber = value;
                    OnPropertyChanged(nameof(AccountNumber));
                }
            }
        }
        #endregion

        public class GigTxt
        {
            public event PropertyChangedEventHandler? PropertyChanged;
            public GigTxt(string details, string rate)
            {
                _details = details;
                _rate = rate;
            }

            private string _details;
            public string Details
            {
                get { return _details; }
                set
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
            private string _rate;
            public string Rate
            {
                get { return _rate; }
                set
                {
                    _rate = value;
                    OnPropertyChanged(nameof(Rate));
                }
            }

            protected void OnPropertyChanged([CallerMemberName] string? name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        private List<GigTxt> _gigList;
        public List<GigTxt> GigList
        {
            get { return _gigList; }
            set
            {
                _gigList = value;
                OnPropertyChanged(nameof(GigList));
            }
        }
        private string _rateTotal;
        public string RateTotal
        {
            get { return _rateTotal; }
            set
            {
                _rateTotal = value;
                OnPropertyChanged(nameof(RateTotal));
            }
        }
        private ICommand _generateInvoice;
        public ICommand GenerateInvoice
        {
            get
            {
                if (_generateInvoice == null)
                {
                    _generateInvoice = new RelayCommand(param => CreateInvoice());
                }
                return _generateInvoice;
            }
        }
        #region Methods
        private void CreateInvoice()
        {
            //Save invoice to database <<TBA>>
            //open doc viewer window for generated invoice
            DocViewWindow DocView = new DocViewWindow();
            DocView.DocViewer.Document = MakeInvoiceDocument();
            DocView.Show();
        }
        private FixedDocument MakeInvoiceDocument()
        {
            InvoicePreviewControl control = new InvoicePreviewControl();
            control.DataContext = this;
            ControlToFixedDoc docConverter = new ControlToFixedDoc();
            FixedDocument invoice = docConverter.ControlToXPS(control);
            return invoice;
        }
        #endregion
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
