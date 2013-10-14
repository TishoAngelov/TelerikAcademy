using System;

class Nullable_Int_Double
{
    /*
    Create a program that assigns null values to an integer and to double
    variables. Try to print them on the console, try to add some values
    or the null literal to them and see the result.
    */

    static void Main()
    {
        int? intNumber = null;
        double? doubleNumber = null;

        Console.WriteLine("The value of integer number is: {0}", intNumber);
        Console.WriteLine("The value of double number is: {0}", doubleNumber);

        intNumber +=  4;
        doubleNumber += 2.124;

        Console.WriteLine("\nAfter assigning a null value:\n");
        Console.WriteLine("The value of integer number is: {0}", intNumber);
        Console.WriteLine("The value of double number is: {0}", doubleNumber);
        Console.WriteLine();
    }
}

