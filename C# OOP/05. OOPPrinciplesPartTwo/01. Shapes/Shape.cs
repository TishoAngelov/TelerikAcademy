using System;

namespace _01.Shapes
{
    // Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    public abstract class Shape
    {
        // Fields
        private decimal width;
        private decimal height;

        // Properties
        public decimal Width
        {
            get { return this.width; }
            private set { this.width = value; }
        }

        public decimal Height
        {
            get { return this.height; }
            private set { this.height = value; }
        }

        // Constructors
        public Shape(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        // Methods
        public abstract decimal CalculateSurface();
    }
}