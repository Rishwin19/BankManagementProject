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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankManagementProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BankManagementWindow : Window
    {
        public NewAccountWindow frmNewAccountWindow = new NewAccountWindow();
        public EditAccountWindow frmEditAccountWindow = new EditAccountWindow();

        public BankManagementWindow()
        {
            InitializeComponent();
            this.DataContext = AccountConfig.accountVeiwModel;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmNewAccountWindow.Show();
            NewAccountWindow newAccount = (NewAccountWindow)AccountConfig.newAccountWindow;
            AccountConfig.accountVeiwModel.NewWindowClose = newAccount.WindowClose;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                var viewModel = (AccountViewModel)this.DataContext;

                if (viewModel.editAccount != null)
                {
                    var editWindow = new EditAccountWindow();
                    editWindow.ShowDialog();
            }
                else
                {
                     MessageBox.Show("Please select an account to edit.", "No Account Selected", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
                
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var depositWindow = new DepositWindow();
            depositWindow.DataContext = this.DataContext; // Set the same DataContext to access the ViewModel
            depositWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
                var withdrawWindow = new WithdrawWindow();
                withdrawWindow.DataContext = this.DataContext; // Bind to the same ViewModel
                withdrawWindow.ShowDialog();
           

        }
    }
}
