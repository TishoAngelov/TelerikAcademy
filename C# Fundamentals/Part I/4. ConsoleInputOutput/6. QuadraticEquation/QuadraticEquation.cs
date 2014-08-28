using System;

class QuadraticEquation
{
    // Write a program that reads the coefficients a, b and c of a quadratic
    // equation ax2+bx+c=0 and solves it (prints its real roots).

    static void Main()
    {
        Console.WriteLine("Enter coefficients (coef > 0) for the quadtratic equation: {0}ax^2 + bx + c = 0", Environment.NewLine);
        Console.Write("a = ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("b = ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("c = ");
        float c = float.Parse(Console.ReadLine());

        float discriminant = (float)(b * b + (-4) * a * c);
        Console.WriteLine("{0}{1}x^2 + {2}x + {3} = 0 {4}D = {5}",Environment.NewLine, a, b, c, Environment.NewLine, discriminant);

        float rootX1 = (float)((-b - Math.Sqrt(discriminant))/ (2 * a));
        float rootX2 = (float)((-b + Math.Sqrt(discriminant)) / (2 * a));
        if (discriminant > 0)
        {
            Console.WriteLine("The roots are: {0}x1 = {1}, x2 = {2}.", Environment.NewLine, rootX1, rootX2);
        }
        else if (discriminant == 0)
        {
            Console.WriteLine("The roots are: {0}x1 = x2 = {1}.", Environment.NewLine, rootX1);
        }
        else
        {
            Console.WriteLine("There are no real roots!");
        }
        Console.WriteLine();
    }
}