using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    // Write a program to convert decimal numbers to their hexadecimal representation.

    static void Main()
    {
        Console.Write("Enter one decimal number (positive): ");
        int decNum = int.Parse(Console.ReadLine());

        Console.WriteLine("\nHexadecimal representation");

        if (decNum == 0)
        {
            Console.Write(0);
        }
        // for positive numbers
        else if (decNum > 0)
        {
            List<string> toHex = new List<string>();

            while (decNum > 0)
            {
                switch (decNum % 16)
                {
                    case 10:
                        toHex.Add("A");
                        break;

                    case 11:
                        toHex.Add("B");
                        break;

                    case 12:
                        toHex.Add("C");
                        break;

                    case 13:
                        toHex.Add("D");
                        break;

                    case 14:
                        toHex.Add("E");
                        break;

                    case 15:
                        toHex.Add("F");
                        break;

                    default:
                        toHex.Add((decNum % 16).ToString());
                        break;
                }
                
                decNum = decNum / 16;
            }

            toHex.Reverse();

            // print the result
            for (int i = 0; i < toHex.Count; i++)
            {
                Console.Write(toHex[i]);
            }
        }
        else
        {
            Console.WriteLine("Incorrect number!");
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}