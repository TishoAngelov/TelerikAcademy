using System;

namespace _02.Bank
{
    public abstract class Customer
    {
        // Fields
        private string name;

        // Properties
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        // Constructors
        public Customer(string name)
        {
            this.Name = name;
        }
    }
}