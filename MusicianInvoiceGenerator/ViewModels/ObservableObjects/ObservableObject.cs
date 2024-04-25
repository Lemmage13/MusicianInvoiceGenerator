using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.ViewModels.ObservableObjects
{
    public class ObservableObject : INotifyPropertyChanged
    {
        //base observable object class can be inherited from to tidy up other observable objects of the below boilerplate
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
