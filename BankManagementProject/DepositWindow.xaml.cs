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
    /// Interaction logic for DepositWindow.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        public DepositWindow()
        {
            InitializeComponent();
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the input is parsed correctly to decimal
            if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber) &&
                decimal.TryParse(DepositAmountTextBox.Text, out decimal amount) && amount > 0)
            {
                var viewModel = (AccountViewModel)this.DataContext; // Assuming DataContext is set correctly

                // Find the account by account number
                var account = viewModel.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    account.Balance += amount; // Update the balance directly
                    MessageBox.Show("Deposit successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Account not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid account number and amount.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
