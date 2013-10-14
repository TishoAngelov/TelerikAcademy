using System;
using System.Collections.Generic;

class ShortToBinary
{
    // Write a program that shows the binary representation
    // of given 16-bit signed integer number (the C# type short).

    static void Main()
    {
        Console.Write("Enter one decimal number (from {0} to {1}): ", short.MinValue, short.MaxValue);
        short decNum = short.Parse(Console.ReadLine());

        Console.WriteLine("\nBinary representation");

        if (decNum == 0)
        {
            Console.Write("0000 0000 0000 0000");
        }
        // for positive numbers
        else if (decNum > 0)
        {
            List<int> toBinary = new List<int>();

            while (decNum > 0)
            {
                toBinary.Add(decNum % 2);
                decNum = (short)(decNum / 2);
            }

            // print the result
            int fourBitsCounter = 0;

            for (int i = 15; i >= 0; i--)
            {
                if (i < toBinary.Count)
                {
                    Console.Write(toBinary[i]);
                }
                else
                {
                    Console.Write("0");
                }

                fourBitsCounter++;

                if (fourBitsCounter == 4)
                {
                    Console.Write(" ");
                    fourBitsCounter = 0;
                }                
            }
        }
        // for negative numbers
        else
        {
            decNum++;
            decNum = Math.Abs(decNum);

            short[] binArr = new short[16];
            int arrTempLength = 15;

            while (decNum > 0)
            {
                binArr[arrTempLength] = (short)(decNum % 2);
                decNum = (short)(decNum / 2);
                arrTempLength--;
            }

            // print the result
            int fourBitsCounter = 0;

            for (int j = 0; j < 16; j++)
            {
                if (binArr[j] == 0)
                {
                    binArr[j] = 1;
                }
                else
                {
                    binArr[j] = 0;
                }

                Console.Write(binArr[j]);

                fourBitsCounter++;

                if (fourBitsCounter == 4)
                {
                    Console.Write(" ");
                    fourBitsCounter = 0;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}