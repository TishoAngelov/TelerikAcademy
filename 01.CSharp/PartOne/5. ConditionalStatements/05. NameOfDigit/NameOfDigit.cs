using System;

class NameOfDigit
{
    // Write program that asks for a digit and depending on the input
    // shows the name of that digit (in English) using a switch statement.

    static void Main()
    {
        int intDigit = 0;   // Should be 1 digit
        string digitName = "";

        do
        {
            Console.Clear();
            Console.Write("Enter a number (positive) with 1 digit: ");
            intDigit = int.Parse(Console.ReadLine());
        } while (intDigit < 0 || intDigit > 9);

        switch (intDigit)
        {
            case 0:
                digitName = "zero";
                break;
            case 1:
                digitName = "one";
                break;
            case 2:
                digitName = "two";
                break;
            case 3:
                digitName = "three";
                break;
            case 4:
                digitName = "four";
                break;
            case 5:
                digitName = "five";
                break;
            case 6:
                digitName = "six";
                break;
            case 7:
                digitName = "seven";
                break;
            case 8:
                digitName = "eight";
                break;
            case 9:
                digitName = "nine";
                break;            
        }
        Console.WriteLine("{0} - {1}", intDigit, digitName);
        Console.WriteLine();
    }
}

