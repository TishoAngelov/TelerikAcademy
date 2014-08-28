using System;
using System.Linq;

namespace _03.SomeAnimals
{
    public abstract class Animals : ISound
    {
        // Fields
        private int age;
        private string name;
        private string sex;

        // Properties
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        // Constructors
        public Animals(int age, string name, string sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        // Methods
        public void Says()
        {
            Console.WriteLine("Animals have differend sounds!");
        }

        public static void AvgAge(Animals[] someAnimals)
        {
            var groupedAnimals =  someAnimals.GroupBy(animal => animal.GetType());

            foreach (var animal in groupedAnimals)
            {
                Console.WriteLine("{0} - {1}", animal.Key.Name, animal.Average(x => x.Age));
            }
        }
    }
}