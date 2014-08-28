using System;

namespace _02.Bank
{
    public class LoanAcc : Account, IDepositable
    {
        // Constructors
        public LoanAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalcInterestAmount(int months)
        {
            int freeMonths = 0;

            if (this.Customer is IndividualCust)
            {
                freeMonths = 3;
            }
            else if (this.Customer is CompanyCust)
            {
                freeMonths = 2;
            }

            if (months <= freeMonths)
            {
                return 0M;
            }

            return base.CalcInterestAmount(months - freeMonths);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}