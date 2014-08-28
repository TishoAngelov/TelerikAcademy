// Create a console application that calculates and prints the square of the number 12345.

using System;

class Program
{
    static void Main()
    {
        int number = 12345;

        Console.WriteLine(number + "^2 = " + Math.Pow(number, 2));
    }
}