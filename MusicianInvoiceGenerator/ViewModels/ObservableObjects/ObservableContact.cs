using MusicianInvoiceGenerator.Models;

namespace MusicianInvoiceGenerator.ViewModels.ObservableObjects
{
    public class ObservableContact : ObservableObject
    {
        //ObservableContact takes a contactdetails object and exposes it for views using propertychanged calls
        public ObservableContact(ContactDetails c) 
        {
            _name = c.Name;
            _phoneNumber = c.PhoneNumber;
            _line1 = c.Line1;
            _line2 = c.Line2;
            _town = c.Town;
            _postCode = c.Postcode;
        }
        public ContactDetails ToContact()
        {
            return new ContactDetails(Name, PhoneNumber, Line1, Line2, Town, PostCode);
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }
        private string _line1;
        public string Line1 
        { 
            get { return _line1; } 
            set { _line1 = value; OnPropertyChanged(nameof(Line1)); } 
        }
        private string _line2;
        public string Line2 
        { 
            get { return _line2; } 
            set { _line2 = value; OnPropertyChanged(nameof(Line2)); } 
        }
        private string _town;
        public string Town 
        { 
            get { return _town; }
            set { _town = value; OnPropertyChanged(nameof(Town)); }
        }
        private string _postCode;
        public string PostCode 
        { 
            get { return _postCode; }
            set { _postCode = value; OnPropertyChanged(nameof(PostCode)); }
        }
    }
}
