namespace OrganizingStraightLineCode
{
    using System;

    public class Chef
    {
        public Bowl GetBowl()
        {
            // ... 
            Bowl bowl = new Bowl();

            return bowl;
        }

        public Carrot GetCarrot()
        {
            // ...
            Carrot carrot = new Carrot();

            return carrot;
        }

        public Potato GetPotato()
        {
            // ...
            Potato potato = new Potato();

            return potato;
        }
        
        public void Cook(Bowl bowl, Vegetable[] vegetables)
        {
            foreach (var vegetable in vegetables)
            {
                this.Peel(vegetable);
                this.Cut(vegetable);
                bowl.Add(vegetable);
            }
        }

        private void Cut(Vegetable vegetable)
        {
            // ...
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }
    }
}
