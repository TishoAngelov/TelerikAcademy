using System;

class IsABitOne_AtPosition
{
    // Write a boolean expression that returns if the bit at position p (counting from 0)
    // in a given integer number v has value of 1. Example: v=5; p=1 -> false.

    static void Main()
    {
        int intNum = 0;
        int bitPosition = 0;
        int mask = 1;
        bool isValueOne = false;

        Console.Write("Please enter 1 number: ");
        intNum = int.Parse(Console.ReadLine());
        Console.Write("Please enter a position of a bit that you want to check: ");
        bitPosition = int.Parse(Console.ReadLine());
        mask = mask << bitPosition;
        isValueOne = (intNum & mask) != 0 ? true : false;
        Console.WriteLine("\nThe binary code of the number {0} is {1} and so =>", intNum, Convert.ToString(intNum, 2).PadLeft(1 + bitPosition, '0'));
        Console.WriteLine("Position of the bit: {0}", bitPosition);
        Console.WriteLine("Value of the bit is 1? -> {0}", isValueOne);
        Console.WriteLine();
    }
}