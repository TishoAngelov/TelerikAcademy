using System;

namespace _02.Bank
{
    public class MortgageAcc : Account, IDepositable
    {
        // Constructors
        public MortgageAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        // Methods
        public override decimal CalcInterestAmount(int months)
        {
            int bonusMonths = 0;

            if (this.Customer is CompanyCust)
            {
                bonusMonths = 12;

                if (months <= bonusMonths)
                {
                    return base.CalcInterestAmount(months) / 2;
                }
                else
                {
                    return (base.CalcInterestAmount(bonusMonths) / 2) +         // 12 months with bonus +
                            (base.CalcInterestAmount(months - bonusMonths));    // the rest without bonus
                }
            }
            else if (this.Customer is IndividualCust)
            {
                bonusMonths = 6;

                if (months <= bonusMonths)
                {
                    return 0M;
                }
            }

            return base.CalcInterestAmount(months - bonusMonths);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}