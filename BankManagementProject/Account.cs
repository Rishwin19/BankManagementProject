using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public Decimal Balance { get; set; }
        public string Type { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int InterestPercentage { get; set; }
        public int TransacationCount { get; set; }
        public DateTime LastTransactionDate { get; set; }
        
        public decimal Amount { get; set; }

           

    }
}
