using System;

class CheckDigitsOfInt
{
    // Write an expression that checks for given integer if its
    // third digit (right-to-left) is 7. E. g. 1732 -> true.

    static void Main()
    {
        int intNum = 0;
        int checkDigit = 7; // must be 1 digit

        Console.Write("Enter 1 number with 3 digits or more: ");
        intNum = int.Parse(Console.ReadLine());
        if ((intNum / 100) % 10 == checkDigit)
        {
            Console.WriteLine("The third digit (right-to-left) IS 7!\n\n");
        }
        else
        {
            Console.WriteLine("The third digit (right-to-left) IS NOT 7!");
            Console.WriteLine();
        }
    }
}