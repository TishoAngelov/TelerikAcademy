using System;
using System.Text;

namespace _04.Persons
{
    // Create a class Person with two fields – name and age. Age can be left
    // unspecified (may contain null value. Override ToString() to display the 
    // information of a person and if age is not specified – to say so.
    public class Person
    {
        // Fields
        private string name;
        private sbyte? age;

        // Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public sbyte? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        // Constructors
        public Person()
        {
        }

        public Person(string name, sbyte? age)
        {
            this.Name = name;
            this.Age = age;
        }

        // Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("\tPerson\n");
            result.AppendFormat("Name: {0}\n", this.Name ?? "<unknown>");
            result.AppendFormat("Age: {0}\n", this.Age == null ? "<unknown>" : this.Age.ToString());

            result.AppendFormat(Environment.NewLine);            

            return result.ToString();
        }
    }
}