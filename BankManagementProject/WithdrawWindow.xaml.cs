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

namespace BankManagementProject
{
    /// <summary>
    /// Interaction logic for WithdrawWindow.xaml
    /// </summary>
    public partial class WithdrawWindow : Window
    {
        public WithdrawWindow()
        {
            InitializeComponent();
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (AccountViewModel)this.DataContext;

            if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber) &&
                decimal.TryParse(WithdrawAmountTextBox.Text, out decimal amount))
            {
                // Call the method to withdraw the amount
                bool success = viewModel.Withdraw(accountNumber, amount);

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Withdrawal failed. Check account number and balance.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
