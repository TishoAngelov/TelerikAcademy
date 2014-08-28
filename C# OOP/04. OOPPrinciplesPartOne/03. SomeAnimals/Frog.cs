using System;

namespace _03.SomeAnimals
{
    public class Frog : Animals
    {
        // Constructors
        public Frog(int age, string name, string sex) : base(age, name, sex)
        {
        }

        // Methods
        public void Says()
        {
            Console.WriteLine("Frogs say quak-quak!");
        }
    }
}