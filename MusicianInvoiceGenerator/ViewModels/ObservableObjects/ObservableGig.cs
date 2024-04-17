using MusicianInvoiceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.ViewModels.ObservableObjects
{
    public class ObservableGig : ObservableObject
    {
        public ObservableGig(GigModel g) 
        {
            _details = g.Details;
            _rate = g.Rate;
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
    }
}
