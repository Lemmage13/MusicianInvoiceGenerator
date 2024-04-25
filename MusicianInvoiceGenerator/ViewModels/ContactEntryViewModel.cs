using MusicianInvoiceGenerator.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicianInvoiceGenerator.ViewModels
{
    public class ContactEntryViewModel : INotifyPropertyChanged
    {
        //This is a viewmodel that connects to a control that can display/modify contact detail information
        //It also can take this information and use it to make a model class of the corresponding type
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        private string _line1;
        public string Line1
        {
            get { return _line1; }
            set
            {
                _line1 = value;
                OnPropertyChanged(nameof(Line1));
            }
        }
        private string _line2;
        public string Line2
        {
            get { return _line2; }
            set
            {
                _line2 = value;
                OnPropertyChanged(nameof(Line2));
            }
        }
        private string _town;
        public string Town
        {
            get { return _town; }
            set
            {
                _town = value;
                OnPropertyChanged(nameof(Town));
            }
        }

        private string _postCode;
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged(nameof(PostCode));
            }
        }
        public ContactEntryViewModel()
        {
            _name = string.Empty;
            _phoneNumber = string.Empty;
            _line1 = string.Empty;
            _line2 = string.Empty;
            _town = string.Empty;
            _postCode = string.Empty;
        }
        public ContactEntryViewModel(ContactDetails c)
        {
            _name = c.Name;
            _phoneNumber = c.PhoneNumber;
            _line1 = c.Line1;
            _line2 = c.Line2;
            _town = c.Town;
            _postCode = c.Postcode;
        }
        public ContactDetails MakeModel()
        {
            return new ContactDetails(Name, PhoneNumber, Line1, Line2, Town, PostCode);
        }
        public ContactDetails MakeModel(int id)
        {
            return new ContactDetails(id, Name, PhoneNumber, Line1, Line2, Town, PostCode);
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
