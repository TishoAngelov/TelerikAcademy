using System;

class HexadecimalToBinary
{
    // Write a program to convert hexadecimal numbers to binary numbers (directly).

    static void Main()
    {
        Console.WriteLine("Enter one hexadecimal number.");
        Console.WriteLine("Only symbols from 0-9 and A-F allowed.");

        Console.Write("Hex number: ");
        string hexNum = Console.ReadLine();

        string binNum = "";

        for (int i = 0; i < hexNum.Length; i++)
        {
            switch (hexNum[i].ToString().ToUpper())
            {
                case "0":
                    binNum += "0000";
                    break;
                case "1":
                    binNum += "0001 ";
                    break;
                case "2":
                    binNum += "0010 ";
                    break;
                case "3":
                    binNum += "0011 ";
                    break;
                case "4":
                    binNum += "0100 ";
                    break;
                case "5":
                    binNum += "0101 ";
                    break;
                case "6":
                    binNum += "0110 ";
                    break;
                case "7":
                    binNum += "0111 ";
                    break;
                case "8":
                    binNum += "1000 ";
                    break;
                case "9":
                    binNum += "1001 ";
                    break;
                case "A":
                    binNum += "1010 ";
                    break;
                case "B":
                    binNum += "1011 ";
                    break;
                case "C":
                    binNum += "1100 ";
                    break;
                case "D":
                    binNum += "1101 ";
                    break;
                case "E":
                    binNum += "1110 ";
                    break;
                case "F":
                    binNum += "1111 ";
                    break;

                default:
                    Console.WriteLine("Incorrect number!\n");
                    return;
            }
        }

        Console.WriteLine("Binary representation: {0}", binNum);

        Console.WriteLine();
    }
}