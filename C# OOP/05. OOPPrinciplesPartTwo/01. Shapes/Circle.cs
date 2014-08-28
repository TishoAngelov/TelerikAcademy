using System;

namespace _01.Shapes
{
    // Define class Circle and suitable constructor so that at initialization height
    // must be kept equal to width and implement the CalculateSurface() method. 
    public class Circle : Shape
    {
        // Constructors
        public Circle(decimal width)
            : base(width, width)
        {
        }

        // Methods
        public override decimal CalculateSurface()
        {
            decimal radius = this.Width / 2;

            return (decimal)Math.PI * radius * radius;
        }
    }
}