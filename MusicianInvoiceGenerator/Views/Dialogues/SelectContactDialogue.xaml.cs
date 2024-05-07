using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicianInvoiceGenerator.Views.Dialogues
{
    /// <summary>
    /// Interaction logic for SelectContactDialogue.xaml
    /// </summary>
    public partial class SelectContactDialogue : Window
    {
        public SelectContactDialogue()
        {
            InitializeComponent();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
