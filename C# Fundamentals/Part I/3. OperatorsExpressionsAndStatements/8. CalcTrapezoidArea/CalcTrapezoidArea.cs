using System;

class CalcTrapezoidArea
{
   //  Write an expression that calculates trapezoid's area by given sides a and b and height h.

    static void Main()
    {
        float trapSideA = 0f;
        float trapSideB = 0f;
        float trapHeight = 0f;
        float trapArea = 0f;

        Console.WriteLine("Please enter dimensions for side A, B and the height of a trapezoid:");
        Console.Write("Side A = ");
        trapSideA = float.Parse(Console.ReadLine());
        Console.Write("Side B = ");
        trapSideB = float.Parse(Console.ReadLine());
        Console.Write("Height = ");
        trapHeight = float.Parse(Console.ReadLine());        
        trapArea = (trapSideA + trapSideB) * trapHeight / 2;
        Console.WriteLine("Trapezoid area = {0}", trapArea);
        Console.WriteLine();
    }
}

