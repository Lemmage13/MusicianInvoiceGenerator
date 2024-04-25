using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.ViewModels.ObservableObjects
{
    //ObservableGig takes a contactdetails object and exposes it for views using propertychanged calls
    public class ObservableGig : ObservableObject
    {
        public ObservableGig(GigModel g) 
        {
            _details = g.Details;
            _rate = g.Rate;
        }
        public ObservableGig()
        {
            _details = String.Empty;
            _rate = 0;
        }
        private string _details;
        public string Details 
        {  
            get { return _details; }
            set { _details = value; OnPropertyChanged(nameof(Details)); }
        }
        private decimal _rate;
        public decimal Rate
        {
            get { return _rate; }
            set { _rate = value; OnPropertyChanged(nameof(Rate)); }
        }
        public string StringRate
        {
            get
            {
                return _rate.ToString();
            }
        }
    }
}
