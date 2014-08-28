using System;

namespace _01.Shapes
{
    // Write a program that tests the behavior of  the CalculateSurface() method 
    // for different shapes (Circle, Rectangle, Triangle) stored in an array.
    public class ShapesTest
    {
        public static void Main()
        {
            Shape[] shapes = {
                                new Triangle(3M, 5.3M),
                                new Rectangle(4M, 7M),
                                new Circle(3M)                               
                             };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine("Surface = " + shape.CalculateSurface());
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}