using System;
using System.Collections.Generic;

class DecimalToBinary
{
    // Write a program to convert decimal numbers to their binary representation.
    
    static void Main()
    {
        Console.Write("Enter one decimal number: ");
        int decNum = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nBinary representation");

        if (decNum == 0)
        {
            Console.Write(0);
        }
        // for positive numbers
        else if (decNum > 0)
        {
            List<int> toBinary = new List<int>();

            while (decNum > 0)
            {
                toBinary.Add(decNum % 2);
                decNum = decNum / 2;
            }

            toBinary.Reverse();

            // print the result
            for (int i = 0; i < toBinary.Count; i++)
            {
                Console.Write(toBinary[i]);
            }
        }
        // for negative numbers
        else
        {
            decNum++;
            decNum = Math.Abs(decNum);

            int[] binArr = new int[32];
            int arrTempLength = 31;

            while (decNum > 0)
            {
                binArr[arrTempLength] = decNum % 2;                
                decNum = decNum / 2;
                arrTempLength--;
            }

            // print the result
            for (int j = 0; j < 32; j++)
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
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}