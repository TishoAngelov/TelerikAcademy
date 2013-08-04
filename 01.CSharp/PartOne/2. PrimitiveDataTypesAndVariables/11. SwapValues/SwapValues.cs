using System;

class SwapValues
{
    //Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

    static void Main()
    {
        int firstNum = 5;
        int secondNum = 10;
        int tempNum = 0;

        Console.WriteLine("Before the swap:");
        Console.WriteLine("First number is {0} and second number is {1}.", firstNum, secondNum);

        tempNum = firstNum;
        firstNum = secondNum;
        secondNum = tempNum;

        Console.WriteLine("\nAfter the swap:");
        Console.WriteLine("First number is {0} and second number is {1}.\n\n", firstNum, secondNum);
    }
}
