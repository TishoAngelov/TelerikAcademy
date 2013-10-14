using System;

class ReplaceBitOfIntNum
{
    // We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence
    // of operators that modifies n to hold the value v at the position p from the binary representation of n.
	// Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
	// n = 5 (00000101), p=2, v=0 -> 1 (00000001)

    static void Main()
    {
        int intNum = 0;
        int valueOfBit = 0; // Only 0 or 1
        int positionOfBit = 0;
        int replacedNum = 0;

        Console.Write("Please enter 1 number: ");
        intNum = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Please enter value of bit (only 0 or 1): ");
            valueOfBit = int.Parse(Console.ReadLine());

            if ((valueOfBit == 0) || (valueOfBit == 1))
            {
                Console.WriteLine("Correct value!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You have entered the value {0}. That is incorrect value!", valueOfBit);
                Console.WriteLine("Enter only 0 or 1 for the value!");
                Console.WriteLine();
            }                                
        } while ((valueOfBit != 0) && (valueOfBit != 1));

        Console.Write("Enter a position of a bit that you want to replace: ");
        positionOfBit = int.Parse(Console.ReadLine());

        if (valueOfBit == 1)
        {
            valueOfBit = 1 << positionOfBit;
            replacedNum = intNum | valueOfBit;
        }

        if (valueOfBit == 0)
        {
            valueOfBit = ~(1 << positionOfBit);
            replacedNum = intNum & valueOfBit;
        }

        Console.WriteLine("You replaced the bit {0} of the number {1} ({2})!",
            positionOfBit, intNum, Convert.ToString(intNum, 2).PadLeft(positionOfBit + 1, '0'));
        Console.WriteLine("The replaced number is {0} ({1})", replacedNum, Convert.ToString(replacedNum, 2));
        Console.WriteLine();
    }
}
