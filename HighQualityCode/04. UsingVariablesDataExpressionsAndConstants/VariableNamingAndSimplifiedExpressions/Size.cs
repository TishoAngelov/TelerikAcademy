namespace VariableNamingAndSimplifiedExpressions
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public static Size Rotate(Size size, double angle)
        {
            double sin = Math.Abs(Math.Sin(angle));
            double cos = Math.Abs(Math.Cos(angle));

            double widthAfterRotation = (cos * size.Width) + (sin * size.Height);
            double heightAfterRotation = (sin * size.Width) + (cos * size.Height);

            Size afterRotation = new Size(widthAfterRotation, heightAfterRotation);

            return afterRotation;
        }
    }
}
