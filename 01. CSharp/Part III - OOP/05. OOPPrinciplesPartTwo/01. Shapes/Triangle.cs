using System;

namespace _01.Shapes
{
    // Define two new classes Triangle and Rectangle that implement the virtual method and return the 
    // surface of the figure (height*width for rectangle and height*width/2 for triangle). 
    public class Triangle : Shape
    {
        // Constructors
        public Triangle(decimal width, decimal height)
            : base(width, height)
        {
        }

        // Methods
        public override decimal CalculateSurface()
        {
            return this.Height * this.Width / 2;
        }
    }
}