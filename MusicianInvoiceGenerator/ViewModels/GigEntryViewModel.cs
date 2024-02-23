using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class GigEntryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;



        public ObservableCollection<GigTxt> Gigs { get; set; }

        public GigEntryViewModel()
        {
            Gigs = new ObservableCollection<GigTxt> { new GigTxt( new GigModel()) };
        }
        private ICommand _addGig;
        public ICommand AddGig
        {
            get
            {
                if (_addGig == null)
                {
                    _addGig = new RelayCommand(param => NewGig());
                }
                return _addGig;
            }
        }
        private void NewGig()
        {
            Gigs.Add(new GigTxt(new GigModel()));
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //nested class to hold user entry without causing type errors -- MUST BE VALIDATED before model is updated
        public class GigTxt : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;

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
            private GigModel GigModel;

            public GigTxt(GigModel model)
            {
                GigModel = model;
                _details = GigModel.Details;
                _rate = GigModel.Rate.ToString();
            }
            protected void OnPropertyChanged([CallerMemberName] string? name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
