using System;

class TwoDivisions_SameTime
{
    // Write a boolean expression that checks for given integer if
    // it can be divided (without remainder) by 7 and 5 in the same time.

    static void Main()
    {
        int intNum = 0;
        int firstDivisor = 5;
        int secondDivisor = 7;
        bool isNumDivided = false;

        Console.Write("Please enter 1 number: ");
        intNum = int.Parse(Console.ReadLine());
        isNumDivided = (intNum % firstDivisor == 0 && intNum % secondDivisor == 0) ? true : false; // Can be done with if construction too.        
        Console.WriteLine("Is {0} divided by {1} and {2} (without remainder) ? -> {3}\n\n", intNum, firstDivisor, secondDivisor, isNumDivided);
    }
}

