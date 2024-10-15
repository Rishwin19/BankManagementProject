using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankManagementProject
{
    public delegate void DWindowClose();
   
    public class AccountViewModel : INotifyPropertyChanged
    {
        public DWindowClose NewWindowClose;
        public DWindowClose EditWindowClose;
        public IAccountRepo _repo = new AccountMemoryRepo();
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        private Account _account;

        public Account Account
        {
            get { return _account; }
            set { 
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }

        private Account _editAccount;

        public Account editAccount
        {
            get { return _editAccount; }
            set { _editAccount = value;
                OnPropertyChanged(nameof(editAccount));
            }
        }

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }




        public ICommand createCommand { get; }
        public ICommand EditCommand { get; }
        public AccountViewModel()
        {
            this.Account = new Account
            {
                AccountNumber = 000,
                Name = "",
                Balance = 0,
                Email = "",
                IsActive = false,
                InterestPercentage = 0,
                TransacationCount = 0,
                LastTransactionDate = DateTime.MinValue,
            };
            



            createCommand = new RelayCommand(CreateAccount);
            EditCommand = new RelayCommand(UpdateAccount);
            
        }
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _repo.ReadAllAccount();
            }
        }
        void CreateAccount()
        {
            Account newAccount = new Account
            {
                AccountNumber = Account.AccountNumber,
                Name = Account.Name,
                Balance = Account.Balance,
                TransacationCount = Account.TransacationCount,
                LastTransactionDate = Account.LastTransactionDate,
                InterestPercentage = Account.InterestPercentage,
                Address = Account.Address,
                Email = Account.Email,
                IsActive = Account.IsActive,
                Type = Account.Type,
            };

            _repo.Create(newAccount);
       
            if (NewWindowClose != null)
            {
                NewWindowClose();
            }
        }

        void UpdateAccount()
        {
            editAccount = Accounts.FirstOrDefault();
            editAccount = new Account
            {
                AccountNumber = editAccount.AccountNumber,
                Name = editAccount.Name,
                Balance = editAccount.Balance,
                TransacationCount = editAccount.TransacationCount,
                LastTransactionDate = editAccount.LastTransactionDate,
                InterestPercentage = editAccount.InterestPercentage,
                Address = editAccount.Address,
                Email = editAccount.Email,
                IsActive = editAccount.IsActive,

            };
            

            _repo.Update(editAccount);
            this.editAccount = this.editAccount;


            if (EditWindowClose != null)
            {
                EditWindowClose();
            }


        }
        public bool Deposit(int accountNumber, decimal amount)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null && amount > 0)
            {
                account.Balance += amount; // Ensure that Balance is decimal
                OnPropertyChanged(nameof(Accounts)); // Notify the UI about the change
                return true;
            }
            return false; // Account not found or invalid amount
        }
        public bool Withdraw(int accountNumber, decimal amount)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null && account.Balance >= amount)
            {
                account.Balance -= amount;
                // Notify that the Accounts collection has changed, if necessary
                return true;
            }
            return false;
        }


    }


}
