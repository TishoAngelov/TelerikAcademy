using System;

class ExtractAndPrintBit
{
    // Write an expression that extracts from a given integer i the
    // value of a given bit number b. Example: i=5; b=2 -> value=1.

    static void Main()
    {
        int intNum = 0;
        int bitPosition = 0;
        int mask = 1;
        int valueOfExtractedBit = 0;

        Console.Write("Please enter 1 number: ");
        intNum = int.Parse(Console.ReadLine());
        Console.Write("Please enter a position of a bit that you want to extract: ");
        bitPosition = int.Parse(Console.ReadLine());
        valueOfExtractedBit = (intNum >> bitPosition) & mask;
        Console.WriteLine("\nThe binary code of the number {0} is {1} and so =>",
            intNum, Convert.ToString(intNum, 2).PadLeft(1 + bitPosition, '0'));
        Console.WriteLine("Position of the bit: {0}", bitPosition);
        Console.WriteLine("Value of the extracted bit: {0}", valueOfExtractedBit);
        Console.WriteLine();
    }
}