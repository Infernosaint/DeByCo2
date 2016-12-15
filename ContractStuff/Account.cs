using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Account
    {
        private int accountNumber;
        private List<Movement> movements;
        private double initialBalance;

        public double balance;

        

        public Account(int accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            this.initialBalance = initialBalance;
            movements = new List<Movement>();
        }

        public Movement withdraw(double amount)
        {
            Contract.Requires(amount > 0, "Use a positive number above 0");
            Contract.Requires<moneyException>(amount <= balance, "Balance is too low");
            Movement movement = new Movement(-amount);
            movements.Add(movement);
            balance += (-amount);
            return movement;
        }

        public void Deposit(Movement movement)
        {
            movements.Add(movement);
            balance += (movement.amount);
        }
        public int getAccountNumber()
        {
            return accountNumber;
        }
        public double getBalance()
        {
            return balance;
        }
        private double getCalculatedBalance()
        {
            double calcBalance = 0;
            calcBalance += initialBalance;
            foreach (Movement movement in movements)
            {
                calcBalance += movement.amount;
            }
            return calcBalance;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
           Contract.Invariant(this.balance == this.getCalculatedBalance(), "The Desired amount exceded the Balance. The withdrawal is canceled");
        }

        

        internal double getInitialBalance()
        {
            return initialBalance;
        }

        internal List<Movement> getMovements()
        {
            return movements;
        }

        public class moneyException : ArgumentOutOfRangeException
        { 
            public moneyException() : base("The Desired amount exceded the Balance. The withdrawal is canceled")
            {
            }
        }
    }
}
