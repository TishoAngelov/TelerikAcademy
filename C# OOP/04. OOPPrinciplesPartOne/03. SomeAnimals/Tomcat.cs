using System;

namespace _03.SomeAnimals
{
    public class Tomcat : Cats
    {
        // Fields
        private const string Sex = "male";

        // Constructors
        public Tomcat(int age, string name) : base(age, name, Sex)
        {
        }
    }
}