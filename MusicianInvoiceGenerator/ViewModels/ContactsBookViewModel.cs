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

namespace MusicianInvoiceGenerator.ViewModels
{
    public class ContactsBookViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ContactsBookViewModel()
        {
            List<ContactDetails> cds = new DBRelay().GetContacts(0,0,String.Empty);
            _contacts = new ObservableCollection<ObservableContact>();
            foreach (ContactDetails c in cds)
            {
                _contacts.Add(new ObservableContact(c));
            }
        }

        //Event handler for key down event in textbox (intended for contacts dialogue window)
        //public void TBKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        Debug.WriteLine("Enter Pressed");
        //    }
        //}
        private ICommand? _searchContactsCmd;
        public ICommand SearchContactsCmd
        {
            get
            {
                if(_searchContactsCmd == null)
                {
                    _searchContactsCmd = new RelayCommand(param => EnterTextBox());
                }
                return _searchContactsCmd;
            }
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
            set { _contacts = value; OnPropertyChanged(nameof(Contacts)); }
        }
        //Method to search and display contacts based on entered value in textbox in ContactsBook dialogue window
        private void EnterTextBox()
        {
            Debug.WriteLine("TextBox Enter Pressed");
        }
        private void SearchContacts()
        {
            throw new NotImplementedException();
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
