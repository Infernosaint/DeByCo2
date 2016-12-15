using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank1 = new Bank("SUPERBANK");
            Customer customer1 = bank1.newCustomer("Mads");
            Account account1 = bank1.newAccount(customer1, 2000);
            Account account2 = bank1.newAccount(customer1, 0);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            bank1.move(300, account1, account2);
            string statement1 = bank1.makeStatement(customer1, account1);
            Console.WriteLine(statement1);
            //Account acount1 = new Account(100);
            //Customer patrick = new Customer("Patrick", 1);
            //Account acount2 = new Account(60);
            //Customer søren = new Customer("Søren", 2);
            //Bank nordea = new Bank("Nordea");
            //nordea.MakeStatement(acount1, patrick);
            //nordea.MakeStatement(acount2, søren);
            ////nordea.MakeStatement(acount2, patrick);
            ////nordea.Move(120, acount1, acount2);
            //nordea.Move(80, acount1, acount2);
            Console.ReadLine();
        }
    }
}
