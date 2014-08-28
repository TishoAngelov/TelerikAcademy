namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle()
        {
            this.Width = 0;
            this.Height = 0;
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }      

        public double Width
        {
            get 
            { 
                return this.width; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The {0} should have positive width.", this.GetType().Name));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get 
            { 
                return this.height; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The {0} should have positive height.", this.GetType().Name));
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
