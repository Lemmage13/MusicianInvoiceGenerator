using MusicianInvoiceGenerator.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;

namespace MusicianInvoiceGenerator.ViewModels
{
    class BankDetailEntryViewModel : INotifyPropertyChanged
    {
        //This is a viewmodel that connects to a control that can display/modify bank detail information
        //It also can take this information and use it to make a model class of the corresponding type
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _sortCode;
        public string SortCode
        {
            get { return _sortCode; }
            set
            {
                _sortCode = value;
                OnPropertyChanged(nameof(SortCode));
            }
        }
        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set 
            {
            _accountNumber = value;
            OnPropertyChanged(nameof(AccountNumber));
            }
        }
        public BankDetailEntryViewModel()
        {
            _sortCode = string.Empty;
            _accountNumber = string.Empty;
        }
        public BankDetailEntryViewModel(BankDetails c)
        {
            _sortCode = c.SortCode;
            _accountNumber = c.AccountNumber;
        }
        public BankDetails MakeModel()
        {
            return new BankDetails(SortCode, AccountNumber);
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
