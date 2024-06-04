using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicianInvoiceGenerator.ViewModels.ObservableObjects;
using System.Windows.Controls;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class ContactsBookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ContactsBookViewModel()
        {
            _page = 1;
            _contacts = MakeContactsObservable(DBRelay.Instance.GetContacts(Page, pageSize, null));
        }

        private int pageSize = 10;

        //Event handler for key down event in textbox (intended for contacts dialogue window)
        //public void TBKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        Debug.WriteLine("Enter Pressed");
        //    }
        //}
        private string? _searchString;
        public string? SearchString
        {
            get
            {
                if (_searchString == String.Empty)
                {
                    return null;
                }
                return _searchString;
            }
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        private ICommand? _searchContactsCmd;
        public ICommand SearchContactsCmd
        {
            get
            {
                if(_searchContactsCmd == null)
                {
                    _searchContactsCmd = new RelayCommand(param => SearchContacts());
                }
                return _searchContactsCmd;
            }
        }
        //Method to search and display contacts based on entered value in textbox in ContactsBook dialogue window
        private void SearchContacts()
        {
            Contacts = MakeContactsObservable(DBRelay.Instance.GetContacts(Page, pageSize, SearchString));
        }
        private ObservableContact? _selected;
        public ObservableContact? Selected
        {
            get
            {
                if(_selected == null) { return null; }
                return _selected;
            }
            set { _selected = value;
                OnPropertyChanged(nameof(Selected)); }
        }
        private ObservableCollection<ObservableContact> _contacts;
        public ObservableCollection<ObservableContact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; OnPropertyChanged(nameof(Contacts));}
        }
        private void UpdateContacts()
        {
            Contacts = MakeContactsObservable(DBRelay.Instance.GetContacts(Page, pageSize, null));
        }
        private ObservableCollection<ObservableContact> MakeContactsObservable(List<ContactDetails> cds)
        {
            ObservableCollection<ObservableContact> oC = new ObservableCollection<ObservableContact>();
            foreach (ContactDetails c in cds)
            {
                oC.Add(new ObservableContact(c));
            }
            return oC;
        }
        private int _page;
        public int Page
        {
            get { return _page; }
            set { _page = value; OnPropertyChanged(nameof(Page)); }
        }
        private ICommand? _nextPage;
        public ICommand NextPage
        {
            get
            {
                if (_nextPage == null)
                {
                    _nextPage = new RelayCommand(param => TurnPage(Convert.ToInt32(param)), pred => CanTurnPage(Convert.ToInt32(pred)));
                }
                return _nextPage;
            }
        }
        //Updates page to new value and updates invoices based on this
        private void TurnPage(int n)
        {
            Page += n;
            UpdateContacts();
        }
        private bool CanTurnPage(int n)
        {
            if (Page + n <= 0) { return false; }
            if (Contacts.Count < pageSize && n > 0) { return false; }
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
