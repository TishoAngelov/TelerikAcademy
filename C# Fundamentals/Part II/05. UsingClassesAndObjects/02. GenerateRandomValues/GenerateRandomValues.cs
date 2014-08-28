using System;

class GenerateRandomValues
{
    // Write a program that generates and prints to the 
    // console 10 random values in the range [100, 200].

    static void Main()
    {
        uint rndValuesCount = 10;
        Console.WriteLine("{0} random values in the range [100, 200]", rndValuesCount);
        Console.WriteLine(new string('=', 45));

        Random rndValue = new Random();
        int minRange = 100;     // including 100
        int maxRange = 201;     // not including 201

        for (int i = 1; i <= rndValuesCount; i++)
        {
            Console.WriteLine("{0}.  {1}", i, rndValue.Next(minRange, maxRange));
        }

        Console.WriteLine();
    }
}