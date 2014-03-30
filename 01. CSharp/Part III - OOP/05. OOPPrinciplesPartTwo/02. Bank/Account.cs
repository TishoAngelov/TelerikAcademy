using System;

namespace _02.Bank
{
    public abstract class Account
    {
        // Fields
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        // Properties
        public Customer Customer
        {
            get { return this.customer; }
            protected set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set { this.interestRate = value; }
        }

        // Constructors
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        // Methods
        public virtual decimal CalcInterestAmount(int months)
        {
            return months * this.InterestRate;
        }
    }
}