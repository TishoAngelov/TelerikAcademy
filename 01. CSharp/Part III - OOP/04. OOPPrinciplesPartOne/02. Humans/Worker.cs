using System;

namespace _02.Humans
{
    public class Worker : Human
    {
        // Fields
        private decimal weekSalary;
        private int workHoursPerDay;

        // Properties
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }

        // Constructors
        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
        {
            base.FirstName = firstName;
            base.LastName = lastName;

            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        // Methods
        public decimal MoneyPerHour()
        {
            // Assuming that the work week has 5 days
            int weekWorkDays = 5;
            
            return (this.weekSalary / weekWorkDays) / this.workHoursPerDay;
        }

        public override string ToString()
        {
            // Shorter string
            string result = string.Format("First name: {0}, Last name: {1}, Money per hour: {2}", 
                                            base.FirstName, base.LastName, Math.Round(MoneyPerHour(), 2));

            //// Too long for the console...
            //string result = string.Format("First name: {0}, Last name: {1}, Week sakary: {2}, Work hours per day: {3}, Money per hour: {4}",
            //                    base.FirstName, base.LastName, this.weekSalary, this.workHoursPerDay, Math.Round(MoneyPerHour(), 2));

            return result;
        }
    }
}