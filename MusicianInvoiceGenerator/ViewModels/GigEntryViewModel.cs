using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.ViewModels.ObservableObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class GigEntryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;



        public ObservableCollection<ObservableGig> Gigs { get; set; }

        public GigEntryViewModel()
        {
            Gigs = new ObservableCollection<ObservableGig> { new ObservableGig() };
        }
        public GigEntryViewModel(List<GigModel> gs)
        {
            Gigs = new ObservableCollection<ObservableGig>();
            foreach(GigModel g in gs)
            {
                Gigs.Add(new ObservableGig(g));
            }
        }
        private ICommand? _addGig;
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
            Gigs.Add(new ObservableGig());
        }
        public List<GigModel> MakeModel()
        {
            List<GigModel> model = new List<GigModel>();
            foreach(ObservableGig gig in Gigs)
            {
                model.Add(new GigModel(gig.Details, Convert.ToDecimal(gig.Rate)));
            }
            return model;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
