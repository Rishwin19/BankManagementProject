using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementProject
{
    public static class AccountConfig
    {
        public static AccountViewModel accountVeiwModel = null;
        public static NewAccountWindow newAccountWindow = null;

        static AccountConfig()
        {
            accountVeiwModel = new AccountViewModel();
            newAccountWindow = new NewAccountWindow();
        }
    }
}
