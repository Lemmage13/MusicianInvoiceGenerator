using MusicianInvoiceGenerator.Data;
using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.ObservableObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class InvoiceViewViewModel : INotifyPropertyChanged
    {
        //This viewmodel is responsible for fetching and exposing database entries for viewing, modifying, and deleting
        //it is designed to only load 10 invoices at a time for pagination of the view


        public event PropertyChangedEventHandler? PropertyChanged;

        DBRelay dB = new DBRelay();

        bool? paidFilter;

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { 
                if(_startDate == _endDate.AddYears(-1))
                {
                    _endDate = value.AddYears(1);
                    OnPropertyChanged(nameof(EndDate));
                }
                _startDate = value; 
                OnPropertyChanged(nameof(StartDate)); UpdateInvoices(); }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(nameof(EndDate)); UpdateInvoices(); }
        }
        private int _paidFilterIndex;
        public int PaidFilterIndex
        {
            get { return _paidFilterIndex; }
            set { _paidFilterIndex = value;
                switch (_paidFilterIndex)
                {
                    case 0: paidFilter = null; break;
                    case 1: paidFilter = true; break;
                    case 2: paidFilter = false; break;
                    default: paidFilter = null; break;
                }
                OnPropertyChanged(nameof(PaidFilterIndex));
                UpdateInvoices();
            }
        }
        private ObservableCollection<ObservableInvoice> _invoices;
        public ObservableCollection<ObservableInvoice> Invoices
        {
            get { return _invoices; }
            set { _invoices = value; OnPropertyChanged(nameof(Invoices)); }
        }

        int page;
        int pageSize = 10;

        //default values display first 10 invoices from current year
        public InvoiceViewViewModel()
        {
            page = 1;
            _startDate = new DateTime(DateTime.Now.Year, 1, 1);
            _endDate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            _invoices = MakeInvoicesObservable(dB.GetInvoices(page, pageSize, StartDate, EndDate, paidFilter));
        }
        //converts StoredInvoice objects retrieved from the database to observable to expose their variables
        private ObservableCollection<ObservableInvoice> MakeInvoicesObservable(List<StoredInvoice> invoices)
        {
            ObservableCollection<ObservableInvoice> oI = new ObservableCollection<ObservableInvoice>();
            foreach (StoredInvoice i in invoices)
            {
                oI.Add(new ObservableInvoice(i));
            }
            return oI;
        }
        //regenerates current page of invoices to update values to represent the database
        protected void UpdateInvoices()
        {
            Invoices = MakeInvoicesObservable(dB.GetInvoices(page,pageSize,StartDate,EndDate,paidFilter));
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}