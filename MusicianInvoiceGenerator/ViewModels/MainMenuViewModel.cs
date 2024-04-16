using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private void OpenSettings()
        {
            throw new NotImplementedException();
        }
        private void OpenInvoiceView()
        {
            throw new NotImplementedException();
        }
    }
}
