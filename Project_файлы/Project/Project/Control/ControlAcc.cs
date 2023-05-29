using Project.Data;
using Project.Model;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Control
{
    public class ControlAcc
    {
        LocalDatabase database;

        public ControlAcc()
        {
            database = LocalDatabase.GetInstance();
        }

        public List<AccountItemViewModel> GetAccountList()
        {
            List<AccountItemViewModel> accountsVM = new List<AccountItemViewModel>();
            var accounts = database.GetAccounts().OrderByDescending(a => a.Amount).ToList();
            foreach (var item in accounts)
            {
                var account = new AccountItemViewModel(item);
                accountsVM.Add(account);
            }

            return accountsVM;
        }

        internal void SaveAccount(string name, double initialAmount)
        {
            database.AddAccount(name, initialAmount);
        }

        internal void Delete(object account)
        {
            database.DeleteAccount((AccountItemViewModel)account);
        }
    }
}
