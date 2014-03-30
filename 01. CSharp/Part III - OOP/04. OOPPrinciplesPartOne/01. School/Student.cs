using System;

namespace _01.School
{
    public class Student : People
    {
        // Fields
        private int classNumber;

        // Properties
        public int ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }

        // Constructors
        public Student(string firstName, string lastName, int classNumber)
        {
            base.FirstName = firstName;
            base.LastName = lastName;

            this.classNumber = classNumber;
        }
    }
}