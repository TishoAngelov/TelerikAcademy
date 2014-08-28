namespace Humans
{
    using System;

    public class Human
    {
        private string name;
        private Sex sex;
        private int age;

        public Human(int age)
        {
            this.Age = age;

            if (age % 2 == 0)
            {
                this.Name = "Guy";
                this.Sex = Sex.Male;
            }
            else
            {
                this.Name = "Girl";
                this.Sex = Sex.Female;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Sex Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}
