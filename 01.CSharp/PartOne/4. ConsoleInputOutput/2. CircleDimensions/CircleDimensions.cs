using System;

class CircleDimensions
{
    // Write a program that reads the radius r of a circle and prints its perimeter and area.

    static void Main()
    {
        Console.Write("Enter circle radius: ");
        float circleRadius = float.Parse(Console.ReadLine());

        float circlePerimeter = (float)(2 * Math.PI * circleRadius);
        Console.WriteLine("Circle perimeter: 2 * {0} * {1} = {2}", (float)Math.PI, circleRadius, circlePerimeter);

        float circleArea = (float)(Math.PI * circleRadius * circleRadius);
        Console.WriteLine("Circle area: {0} * {1}^2 = {2}", (float)Math.PI, circleRadius, circleArea);
        Console.WriteLine();
    }
}

