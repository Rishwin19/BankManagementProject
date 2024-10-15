using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    internal class AccountMemoryRepo : IAccountRepo
    {
        public ObservableCollection<Account> accounts = new ObservableCollection<Account>()
        {
            new Account
            {
               AccountNumber = 1234,
                Name = "rishwin",
                Balance = 10000,
                TransacationCount = 0,
                Email = "rishin@gmail.com",
                Address = "trivandrum",
                InterestPercentage = 0,
                IsActive = true,
                LastTransactionDate = DateTime.Now,
            }
        };
        public void Create(Account account)
        {          
            accounts.Add(account);
            ReadAllAccount();
        }

        public void Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public void Deposit(Account account, decimal amount)
        {
            var existingAccount = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount.Balance += amount;
                existingAccount.TransacationCount++; 
                existingAccount.LastTransactionDate = DateTime.Now;
            }
            else
            {
                throw new Exception("Account not found.");
            }
        }

        public ObservableCollection<Account> ReadAllAccount()
        {
            return accounts;
        }

        public Account Update(Account account)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(Account account, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
