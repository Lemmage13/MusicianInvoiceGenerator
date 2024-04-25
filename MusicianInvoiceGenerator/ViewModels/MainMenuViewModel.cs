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
        //This viewmodel contains logic for opening other windows from the main menu, as well as any other functionality the main menu will require

        //MainWindow being opened here will be opened empty for values to be input by the user to generate a new invoice
        // MainWindow -> InvoicePreviewWindow -> save invoice and DocViewerWindow
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
        //InvoiceView will show a list of invoices in a datagrid, they each have buttons to delete/modify/view
        //View: InvoiceViewWindow -> InvoicePreviewWindow (no option to save/modify)
        //Modify: InvoiceViewWindow -> MainWindow -> InvoicePreviewWindow -> update database and DocViewerWindow
        //Delete: MessageBox -> delete invoice from database
        //see ObservableInvoice for more details
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
