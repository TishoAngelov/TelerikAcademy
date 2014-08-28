using System;

namespace _03.SomeAnimals
{
    // Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
    class Tests
    {
        public static void Main()
        {
            Dog doggy = new Dog(4, "doggy", "male");
            doggy.Says();
            Console.WriteLine();

            Kitten kitt = new Kitten(3, "kitten");
            kitt.Says();
            Console.WriteLine();

            Frog froggy = new Frog(20, "froggy", "female");
            froggy.Says();
            Console.WriteLine();

            Console.WriteLine();
            Animals[] aLotOfAnimals = 
                {
                    new Kitten(5, "Pesho 1"),
                    new Frog(12, "Pesho 2", "female"),
                    new Frog(3, "Pesho 3", "male"),
                    new Dog(66, "Pesho 4", "female"),
                    new Kitten(9, "Pesho 5"),
                    new Frog(1, "Pesho 6", "female"),
                    new Frog(0, "Pesho 7", "male"),
                    new Dog(30, "Pesho 8", "male"),
                    new Kitten(11, "Pesho 9"),
                    new Frog(6, "Pesho 10", "female"),
                    new Frog(8, "Pesho 11", "male"),
                    new Dog(8, "Pesho 12", "female"),
                    new Kitten(10, "Pesho 13"),
                };

            Animals.AvgAge(aLotOfAnimals);
        }
    }
}