using MusicianInvoiceGenerator.Data;
using MusicianInvoiceGenerator.ViewModels.ObservableObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicianInvoiceGenerator.Models;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class InvoiceViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        DBRelay dB = new DBRelay();

        private List<ObservableInvoice> _invoices;
        public List<ObservableInvoice> Invoices
        {
            get { return _invoices; }
            set { _invoices = value; OnPropertyChanged(nameof(Invoices)); }
        }

        int page;
        int pageSize = 10;

        public InvoiceViewViewModel() 
        {
            page = 1;
            _invoices = MakeInvoicesObservable(dB.GetInvoices(page, pageSize, new DateTime(2024,1,1)));
        }
        private List<ObservableInvoice> MakeInvoicesObservable(List<Invoice> invoices)
        {
            List<ObservableInvoice> oI = new List<ObservableInvoice>();
            foreach(Invoice i in  invoices)
            {
                oI.Add(new ObservableInvoice(i));
            }
            return oI;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}