using System;

namespace _03.SomeAnimals
{
    // The class is abstract to prohibit making instance of it.
    public abstract class Cats : Animals
    {
        // Constructors
        public Cats(int age, string name, string sex) : base(age, name, sex)
        {
        }

        // Methods
        public void Says()
        {
            Console.WriteLine("Cats say miau-miau!");
        }
    }
}