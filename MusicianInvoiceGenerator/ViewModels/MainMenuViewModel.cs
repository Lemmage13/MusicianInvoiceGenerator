using MusicianInvoiceGenerator.ViewModels.Commands;
using MusicianInvoiceGenerator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicianInvoiceGenerator.ViewModels
{
    class MainMenuViewModel
    {
        private void OpenMainWindow()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            MainWindow w = new MainWindow();
            w.DataContext = vm;
            w.Show();
        }
        private ICommand? _openMainWindowCmd;
        public ICommand OpenMainWindowCmd
        {
            get
            {
                if( _openMainWindowCmd == null)
                {
                    _openMainWindowCmd = new RelayCommand(param => OpenMainWindow());
                }
                return _openMainWindowCmd;
            }
        }
        private void OpenSettings()
        {
            throw new NotImplementedException();
        }
        private ICommand? _openSettingsCmd;
        public ICommand OpenSettingsCmd
        {
            get
            {
                if ( _openSettingsCmd == null)
                {
                    _openSettingsCmd = new RelayCommand(param => OpenSettings());
                }
                return _openSettingsCmd;
            }
        }
        private void OpenInvoiceView()
        {
            InvoiceViewViewModel vm = new InvoiceViewViewModel();
            InvoiceViewWindow w = new InvoiceViewWindow();
            w.DataContext = vm;
            w.Show();
        }
        private ICommand? _openInvoiceViewCmd;
        public ICommand OpenInvoiceViewCmd
        {
            get
            {
                if(_openInvoiceViewCmd == null)
                {
                    _openInvoiceViewCmd = new RelayCommand(param => OpenInvoiceView());
                }
                return _openInvoiceViewCmd;
            }
        }
    }
}
