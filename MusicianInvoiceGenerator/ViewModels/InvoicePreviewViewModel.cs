﻿using MusicianInvoiceGenerator.Models;
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
using MusicianInvoiceGenerator.Data;
using System;
using System.Diagnostics;

namespace MusicianInvoiceGenerator.ViewModels
{
    class InvoicePreviewViewModel : INotifyPropertyChanged
    {
        //This is a viewmodel that exposes properties from an associated invoice model for viewing as part of an invoice preview
        //It is responsible for exposing the required variables, and producing other variables that are required to be displayed on the invoice PDF
        //Also contains methods to modify the invoice based on the preview, or to save the invoice, both on user input (if the previewed invoice is acceptable)
        //This class binds to a control that defines the appearance of the invoice on the PDF

        public event PropertyChangedEventHandler? PropertyChanged;

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
            _recipientTown = Invoice.RecipientContact.Town;
            _recipientL1 = Invoice.RecipientContact.Line1;
            _recipientL2 = Invoice.RecipientContact.Line2;
            _recipientPostcode = Invoice.RecipientContact.Postcode;

            _sortCode = Invoice.SenderBankDetails.SortCode;
            _accountNumber = Invoice.SenderBankDetails.AccountNumber;

            _gigList = GetGigTxts(Invoice);
            _rateTotal = GetTotalRate(Invoice);

            _modify = 0;
        }
        public InvoicePreviewViewModel(StoredInvoice i, int mod)
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
            _recipientTown = Invoice.RecipientContact.Town;
            _recipientL1 = Invoice.RecipientContact.Line1;
            _recipientL2 = Invoice.RecipientContact.Line2;
            _recipientPostcode = Invoice.RecipientContact.Postcode;

            _sortCode = Invoice.SenderBankDetails.SortCode;
            _accountNumber = Invoice.SenderBankDetails.AccountNumber;

            _gigList = GetGigTxts(Invoice);
            _rateTotal = GetTotalRate(Invoice);

            _modify = mod; //0 for save invoice, 1 for no modifications, 2 for save modifications
        }
        private string GetTotalRate(Invoice i)
        {
            decimal totalRate = 0;
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
        private int _modify;
        public int Modify
        {
            get { return _modify; }
            set { _modify = value; OnPropertyChanged(nameof(Modify)); }
        }
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
        //Save vs modify invoice command binding is determined by a datatrigger in the view
        private ICommand? _saveInvoiceCmd;
        public ICommand SaveInvoiceCmd
        {
            get
            {
                if (_saveInvoiceCmd == null)
                {
                    _saveInvoiceCmd = new RelayCommand(param => SaveInvoice());
                }
                return _saveInvoiceCmd;
            }
        }
        private ICommand? _modifyInvoiceCmd;
        public ICommand ModifyInvoiceCmd
        {
            get
            {
                if (_modifyInvoiceCmd == null)
                {
                    _modifyInvoiceCmd = new RelayCommand(param => ModifyInvoice((StoredInvoice)Invoice));
                }
                return _modifyInvoiceCmd;
            }
        }
        private ICommand? _openInvoiceDoc;
        public ICommand OpenInvoiceDoc
        {
            get
            {
                if (_openInvoiceDoc == null)
                {
                    _openInvoiceDoc = new RelayCommand(param => OpenInvoiceDocViewer());
                }
                return _openInvoiceDoc;
            }
        }
        #region Methods
        //Saves invoice that is being previewed - calls dataRelay class to manage data access so that tables are added to in the right order
        private void SaveInvoice()
        {
            if (MessageBox.Show("Are you sure all details in the invoice are correct?", "Are you sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Save invoice to database
                DBRelay.Instance.SaveInvoice(Invoice);
                //open doc viewer window for generated invoice
                OpenInvoiceDocViewer();
                //close MainWindow and PreviewWindow TBA (possibly not here)
            }
        }
        //modifies the invoice that is being viewed - calls datarelay class to manage database modification
        private void ModifyInvoice(StoredInvoice i)
        {
            if (MessageBox.Show("Are you sure all details in the invoice are correct?", "Are you sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //check details for off-target effects
                bool changeSenderId = WillChangeId(i.SenderContact, i.invoiceNo);
                bool changeRecipientId = WillChangeId(i.RecipientContact, i.invoiceNo);

                //if id is not to be changed and contact cannot be modified without off-target effects, the user should be prompted
                if ((!changeSenderId && !DBRelay.Instance.CanDeleteContact((int)i.SenderContact.Id, i.invoiceNo)) | (!changeRecipientId && !DBRelay.Instance.CanDeleteContact((int)i.RecipientContact.Id, i.invoiceNo)))
                {
                    Debug.WriteLine("One Id has been modified to a non-existing contact that will have off-target effects");
                    //ask user whether to add or modify contacts
                    //if yes - no change
                    //if no - both change id bools set to true
                    switch (MessageBox.Show("Modifying these contact details will result in multiple invoices being modified. " +
                        "Do you want to change these contacts for all invoices?",
                        "Warning!", MessageBoxButton.YesNoCancel))
                    {
                        case MessageBoxResult.Yes:
                            Debug.WriteLine("invoice modified changing multiple invoices");
                            DBRelay.Instance.UpdateInvoice(i, changeSenderId, changeRecipientId);
                            break;
                        case MessageBoxResult.No:
                            Debug.WriteLine("invoice modified changing only its own FK Ids");
                            changeSenderId = true;
                            changeRecipientId = true;
                            DBRelay.Instance.UpdateInvoice(i, changeSenderId, changeRecipientId);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Debug.WriteLine("no off target effects detected");
                    DBRelay.Instance.UpdateInvoice(i, changeSenderId, changeRecipientId);
                }
            }
        }
        private bool WillChangeId(ContactDetails c, int iN)
        {
            //if entry already exists for contact details, contact id can be changed with no off-target effects
            bool changeId = DBRelay.Instance.DoesContactExist(c);
            Debug.WriteLine(c.Name + " change id " + changeId);
            return changeId;
        }
        //opens window with a docviewer so that the invoice can be seen in document format (and possibly printed to pdf)
        private void OpenInvoiceDocViewer()
        {
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
