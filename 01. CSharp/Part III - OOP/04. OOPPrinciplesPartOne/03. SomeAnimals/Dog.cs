using System;

namespace _03.SomeAnimals
{
    public class Dog : Animals
    {
        // Constructors
        public Dog(int age, string name, string sex) : base(age, name, sex)
        {
        }

        // Methods
        public void Says()
        {
            Console.WriteLine("Dogs say bau-bau!");
        }
    }
}