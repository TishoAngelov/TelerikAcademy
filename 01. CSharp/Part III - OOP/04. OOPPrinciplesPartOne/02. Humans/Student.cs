using System;

namespace _02.Humans
{
    public class Student : Human
    {
        // Fields
        private int grade;

        // Properties
        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        // Constructors
        public Student(string firstName, string lastName, int grade)
        {
            base.FirstName = firstName;
            base.LastName = lastName;

            this.grade = grade;
        }

        // Methods
        public override string ToString()
        {
            string result = string.Format("First name: {0}, Last name: {1}, Grade: {2}", base.FirstName, base.LastName, this.grade);

            return result;
        }
    }
}