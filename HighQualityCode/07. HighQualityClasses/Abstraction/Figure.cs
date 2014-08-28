namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            string result = string.Format(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.", 
                this.GetType().Name, 
                this.CalculatePerimeter(), 
                this.CalculateSurface());
            
            return result;
        }
    }
}
