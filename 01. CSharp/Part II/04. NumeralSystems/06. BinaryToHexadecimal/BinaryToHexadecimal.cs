using System;
using System.Numerics;

class BinaryToHexadecimal
{
    // Write a program to convert binary numbers to hexadecimal numbers (directly).

    static void Main()
    {
        Console.WriteLine("Enter one binary number (only digits 0 and 1 allowed)");

        Console.Write("Binary number: ");
        BigInteger binNum = BigInteger.Parse(Console.ReadLine());

        string hexNum = "";

        while (binNum > 0)
        {
            int remainder = (int)(binNum % 10000);

            switch (remainder)
            {
                case 0:
                    hexNum += "0";
                    break;
                case 1:
                    hexNum += "1";
                    break;
                case 10:
                    hexNum += "2";
                    break;
                case 11:
                    hexNum += "3";
                    break;
                case 100:
                    hexNum += "4";
                    break;
                case 101:
                    hexNum += "5";
                    break;
                case 110:
                    hexNum += "6";
                    break;
                case 111:
                    hexNum += "7";
                    break;
                case 1000:
                    hexNum += "8";
                    break;
                case 1001:
                    hexNum += "9";
                    break;
                case 1010:
                    hexNum += "A";
                    break;
                case 1011:
                    hexNum += "B";
                    break;
                case 1100:
                    hexNum += "C";
                    break;
                case 1101:
                    hexNum += "D";
                    break;
                case 1110:
                    hexNum += "E";
                    break;
                case 1111:
                    hexNum += "F";
                    break;

                default:
                    Console.WriteLine("Incorrect number!\n");
                    return;
            }

            binNum = binNum / 10000;
        }        

        // printing the result in reversed order
        Console.WriteLine("\nHexadecimal representation");

        for (int i = hexNum.Length - 1; i >= 0; i--)
        {            
            Console.Write(hexNum[i]);
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}