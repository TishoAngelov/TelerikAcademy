using System;

class FindACertainBit
{
    // Write a boolean expression for finding if the bit 3
    // (counting from 0) of a given integer is 1 or 0.

    static void Main()
    {
        int intNum = 0;
        int mask = 1 << 3;
        int bitThree = 0;

        Console.Write("Please enter 1 number: ");
        intNum = int.Parse(Console.ReadLine());
        bitThree = (intNum & mask) != 0 ? 1 : 0;
        Console.WriteLine("\nThe binary code of the number {0} is {1} and so =>", intNum, Convert.ToString(intNum, 2).PadLeft(4, '0'));
        Console.WriteLine("=> the bit three (counting from 0) of the number {0} is {1}.", intNum, bitThree);
        Console.WriteLine();
    }
}
