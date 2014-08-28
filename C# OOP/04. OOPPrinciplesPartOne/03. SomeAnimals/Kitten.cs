using System;

namespace _03.SomeAnimals
{
    public class Kitten : Cats
    {
        // Fields
        private const string Sex = "female";

        // Constructors
        public Kitten(int age, string name) : base(age, name, Sex)
        {
        }
    }
}