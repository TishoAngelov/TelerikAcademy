using System;

class HexadecimalToDecimal
{
    // Write a program to convert hexadecimal numbers to their decimal representation.

    static void Main()
    {
        Console.WriteLine("Enter one hexadecimal number.");
        Console.WriteLine("Only symbols from 0-9 and A-F allowed.");

        Console.Write("Hex number: ");
        string hexNum = Console.ReadLine();

        int decNum = 0;

        for (int i = 0; i < hexNum.Length; i++)
        {
            int pow = (int)Math.Pow(16, i);

            switch (hexNum[hexNum.Length - 1 - i].ToString().ToUpper())
            {
                case "A":
                    decNum += 10 * pow;
                    break;

                case "B":
                    decNum += 11 * pow;
                    break;

                case "C":
                    decNum += 12 * pow;
                    break;

                case "D":
                    decNum += 13 * pow;
                    break;

                case "E":
                    decNum += 14 * pow;
                    break;

                case "F":
                    decNum += 15 * pow;
                    break;

                default:
                    decNum += Convert.ToInt32(hexNum[hexNum.Length - 1 - i] - 48) * pow;
                    break;
            }            
        }

        Console.WriteLine("Decimal representation: {0}", decNum);
        Console.WriteLine();
    }
}