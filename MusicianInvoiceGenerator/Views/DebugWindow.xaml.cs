using MusicianInvoiceGenerator.ViewModels;
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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MusicianInvoiceGenerator.Data;
using MusicianInvoiceGenerator.Models;

namespace MusicianInvoiceGenerator.Views
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void MainWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel VM = new MainWindowViewModel();
            MainWindow MW = new MainWindow();
            MW.DataContext = VM;
            MW.Show();
        }

        private void TestDBBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactsDataAccess testDA = new ContactsDataAccess();
            testDA.AddContact(new ContactDetails("Test", "07*******", "l1", "l2", "town", "PC11 1AA"));
            OutputTBlock.Text = "Count: " + testDA.Count();
        }

        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}