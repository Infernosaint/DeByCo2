using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Customer
    {
        private string name;
        private int ID;
        private List<Account> accounts;

        public Customer(string name, int ID)
        {
            accounts = new List<Account>();
            this.name = name;
            this.ID = ID;
        }

        public void AddAcount(Account account)
        {
           Contract.Requires<AccountExeption>(accounts.Contains(account) == false);
           accounts.Add(account);
           
        }

        public String getName()
        {
            return name;
        }
        

        public List<Account> getAccounts()
        {
            return accounts;
        }

        public class AccountExeption : ArgumentException
        {
            public AccountExeption() : base("The account is already set up")
            {
            }
        }
    }
}
