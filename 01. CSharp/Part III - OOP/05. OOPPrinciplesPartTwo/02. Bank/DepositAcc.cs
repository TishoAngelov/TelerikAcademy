using System;

namespace _02.Bank
{
    public class DepositAcc : Account, IDepositable, IWithdrawable
    {
        // Constructors
        public DepositAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalcInterestAmount(int months)
        {
            int minBalance = 0;
            int maxBalance = 1000;

            if (minBalance <= this.Balance && this.Balance <= maxBalance)
            {
                return 0M;
            }

            return base.CalcInterestAmount(months);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                throw new InvalidOperationException("You are out of money! You can't withdraw more money!!!");
            }

            this.Balance -= amount;
        }
    }
}