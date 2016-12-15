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
            bool running = true;
            while (running)
            {
                Console.WriteLine("T for transfer, S for statement");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.T)
                {
                    Console.WriteLine();
                    Console.WriteLine("How must would you like to transfer from account 1 to 2?");
                    string input = Console.ReadLine();
                    double amount;
                    if (double.TryParse(input, out amount))
                    {
                        bank1.move(amount, account1, account2);
                    }
                    else
                    {
                        Console.WriteLine("Amount must consist of numbers");
                    }
                }
                else if (key == ConsoleKey.S)
                {
                    string statement1 = bank1.makeStatement(customer1, account1);
                    Console.WriteLine(statement1);

                }
                else if (key == ConsoleKey.E)
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Not a valid input, try again");
                }
            }
            
            
            Console.ReadLine();
        }
    }
}
