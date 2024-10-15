using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    public interface IAccountRepo
    {
        void Create(Account account);
        Account Update(Account account);
        void Delete(Account account);

        void Deposit(Account account, decimal amount);

        void Withdraw(Account account, decimal amount);

        ObservableCollection<Account> ReadAllAccount();
    }
}
