using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Bank
    {
        private string name;
        private int lastCustomerID;
        private int lastAccountNumber;
        private List<Customer> customers { get; set; }
        private List<Account> accounts { get; set; }

        public Bank(string name)
        {
            this.name = name;
            accounts = new List<Account>();
            customers = new List<Customer>();
            lastCustomerID = 0;
        }

        public void move(Double amount, Account source, Account target)
        {
            Contract.Requires(amount > 0);
            Movement movement = source.Withdraw(amount);
            target.Deposit(movement);
        }

        public Account newAccount(Customer customer, double initialBalance)
        {
            Account account = new ContractStuff.Account(++lastAccountNumber,initialBalance);
            customer.AddAcount(account);
            return account;
        }

        public Customer newCustomer(String name)
        {
            Customer customer = new ContractStuff.Customer(name, ++lastCustomerID);
            customers.Add(customer);
            return customer;
        }

        public String makeStatement(Customer customer, Account account)
        {
            String statement = "";
            if (customer.getAccounts().Contains(account))
            {
                
                statement += "Name: " + customer.getName() + ".\n";
                statement += "Account Number: " + account.getAccountNumber() + ".\n\n";
                double initialBalance = account.getInitialBalance();
                statement += "Initial Balance: " + initialBalance.ToString() + ".\n";
                double newBalance = initialBalance;
                foreach (Movement movement in account.getMovements())
                {
                    newBalance += movement.amount;
                    statement += movement.amount + " : " + newBalance.ToString() + "\n";
                }
            }
            else
            {
                statement += "That account does not belong to that customer";
            }
            return statement;

        }
       
    }
}
