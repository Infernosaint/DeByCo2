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

        public double balance
        {
            get
            {
                double sudoBalance = 0;
                sudoBalance += initialBalance;
                foreach (Movement movement in movements)
                {
                    sudoBalance += movement.amount;
                }
                return sudoBalance;
            }
        }

        public Account(int accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.initialBalance = initialBalance;
            movements = new List<Movement>();
        }

        public Movement Withdraw(double amount)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(amount <= balance);
            Movement movement = new Movement(-amount);
            movements.Add(movement);
            return movement;
        }

        public void Deposit(Movement movement)
        {
            movements.Add(movement);
        }
        public int getAccountNumber()
        {
            return accountNumber;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.balance >= 0, "The Desired amount exceded the Balance. The withdrawal is canceled");
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
