﻿using MusicianInvoiceGenerator.Data;
using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.Views;

namespace MusicianInvoiceGenerator.ViewModels.ObservableObjects
{
    public class ObservableInvoice : ObservableObject
    {
        private StoredInvoice invoice;
        public ObservableInvoice(StoredInvoice i)
        {
            invoice = i;
            _invoiceNumber = i.invoiceNo;
            _senderContact = new ObservableContact(i.SenderContact);
            _sortCode = i.SenderBankDetails.SortCode;
            _accountNumber = i.SenderBankDetails.AccountNumber;
            _recipientContact = new ObservableContact(i.RecipientContact);
            _gigs = new ObservableCollection<ObservableGig>();
            foreach (GigModel g in  i.Gigs)
            {
                _gigs.Add(new ObservableGig(g));
            }
            _date = i.InvoiceDate;
            _due = i.DueDate;
            _paid = i.Paid;
        }
        private int _invoiceNumber;
        public string InvoiceNumber
        {
            get { return _invoiceNumber.ToString(); }
            set { _invoiceNumber = Convert.ToInt32(value); OnPropertyChanged(nameof(InvoiceNumber)); }
        }
        private ObservableContact _senderContact;
        public ObservableContact SenderContact
        {
            get { return _senderContact; }
            set { _senderContact = value; OnPropertyChanged(nameof(SenderContact)); }
        }
        private string _sortCode;
        public string SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; OnPropertyChanged(nameof(SortCode)); }
        }
        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; OnPropertyChanged(nameof(AccountNumber)); }
        }
        private ObservableContact _recipientContact;
        public ObservableContact RecipientContact
        {
            get { return _recipientContact; }
            set { _recipientContact = value; OnPropertyChanged(nameof(RecipientContact)); }
        }
        private ObservableCollection<ObservableGig> _gigs;
        public ObservableCollection<ObservableGig> Gigs
        {
            get { return _gigs; }
            set { _gigs = value; OnPropertyChanged(nameof(Gigs)); }
        }
        private DateTime _date;
        public DateTime Date
        {
            get {  return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        private DateTime _due;
        public DateTime Due
        {
            get { return _due; }
            set { _due = value; OnPropertyChanged(nameof(Due)); OnPropertyChanged(nameof(PaidState)); }
        }
        private bool _paid;
        public bool Paid
        {
            get { return _paid; }
            set { _paid = value; UpdateInvoicePaid(); OnPropertyChanged(nameof(Paid)); OnPropertyChanged(nameof(PaidState)); }
        }
        private ICommand? _modifyCmd;
        public ICommand ModifyCmd
        {
            get
            {
                if (_modifyCmd == null)
                {
                    _modifyCmd = new RelayCommand(param => ModifyInvoice());
                }
                return _modifyCmd;
            }
        }
        private ICommand? _deleteCmd;
        public ICommand DeleteCmd
        {
            get
            {
                if (_deleteCmd == null)
                {
                    _deleteCmd = new RelayCommand(param => DeleteInvoice());
                }
                return _deleteCmd;
            }
        }
        private void ModifyInvoice()
        {
            Debug.WriteLine("Modify " + InvoiceNumber);
            MainWindowViewModel vm = new MainWindowViewModel(invoice);
            MainWindow w = new MainWindow();
            w.DataContext = vm;
            w.Show();
        }
        private void DeleteInvoice()
        {
            Debug.WriteLine("Delete " + InvoiceNumber);
            throw new NotImplementedException();
        }
        private void UpdateInvoicePaid()
        {
            InvoiceDataAccess da = new InvoiceDataAccess();
            da.UpdatePaid(_invoiceNumber, Paid);
        }
        public int PaidState
        {
            get
            {
                if (Paid) { return 0; } //invoice is paid
                if (DateTime.Now < Due) { return 1; } //invoice is not paid, but not overdue
                return 2; //invoice is not paid and overdue
            }
        }
        public decimal TotalRate
        {
            get 
            {
                decimal r = 0;
                foreach(ObservableGig g in Gigs)
                {
                    r += g.Rate;
                } 
                return r;
            }
        }
    }
}
