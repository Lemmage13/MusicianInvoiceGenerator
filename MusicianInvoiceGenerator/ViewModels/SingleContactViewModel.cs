using MusicianInvoiceGenerator.Data;
using MusicianInvoiceGenerator.Models;
using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.ViewModels.ObservableObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicianInvoiceGenerator.ViewModels
{
    internal class SingleContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public SingleContactViewModel(ContactDetails c)
        {
            _contact = new ObservableContact(c);
            _senderNum = DBRelay.Instance.InvoicesUsingSender((int)c.Id).Count;
            _recipientNum = DBRelay.Instance.InvoicesUsingRecipient((int)c.Id).Count;
        }

        private ObservableContact _contact;
        public ObservableContact Contact
        {
            get { return _contact; }
            set { _contact = value; OnPropertyChanged(nameof(Contact)); }
        }
        private int _senderNum;
        public int SenderNum
        {
            get { return _senderNum; }
            set { _senderNum = value; OnPropertyChanged(nameof(SenderNum)); }
        }

        private int _recipientNum;
        public int RecipientNum
        {
            get { return _recipientNum; }
            set { _recipientNum = value; OnPropertyChanged(nameof(RecipientNum)); }
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ICommand? _modifyContactCmd;
        public ICommand ModifyContactCmd
        {
            get 
            {
                if (_modifyContactCmd == null)
                {
                    _modifyContactCmd = new RelayCommand(param => ModifyContact());
                }
                return _modifyContactCmd;
            }
        }
        public void ModifyContact()
        {
            if(MessageBox.Show("Modifying contact details can affect multiple invoices, are you sure this is what you want?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DBRelay.Instance.ModifyContact(Contact.Id, Contact.ToContact());
            }
        }
    }
}
