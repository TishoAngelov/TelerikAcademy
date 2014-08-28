using System;
using System.Numerics;

class SumArrayDigits
{
    /*
        Write a method that adds two positive integer numbers represented as
        arrays of digits (each array element arr[i] contains a digit; the last
        digit is kept in arr[0]). Each of the numbers that will be added
        could have up to 10 000 digits.
    */

    static BigInteger AddNumbers(BigInteger num1, BigInteger num2)
    {
        if (num1.ToString().Length < num2.ToString().Length)
        {
            BigInteger tempNum = num1;

            num1 = num2;
            num2 = tempNum;
        }

        char[] longerArr = num1.ToString().ToCharArray();       // Inserting the number in char array
        Array.Reverse(longerArr);

        char[] shorterArr = num2.ToString().ToCharArray();      // Inserting the number in char array
        Array.Reverse(shorterArr);

        byte[] summedNum = new byte[longerArr.Length + 1];        

        for (int i = 0; i < shorterArr.Length; i++)
        {
            byte rest = 0;
            byte digitInMind = 0;        // We can have only 0 or 1 in mind because we sum the digits from 0 to 9

            // If the sum of the current digits is bigger than 10, we will
            // have 1 in mind. In the other case we will just sum them.
            if ((Convert.ToInt32(longerArr[i]) +                // Subtract 96 because it sum the ASCII codes and we have two
                Convert.ToInt32(shorterArr[i]) - 96) > 9)       // numbers. They ASCII code of the numbers starts from 48. So 2x48
            {
                digitInMind = 1;
                rest = (byte)((Convert.ToInt32(longerArr[i]) + Convert.ToInt32(shorterArr[i]) - 96) % 10);                
            }
            else
            {
                rest = (byte)(Convert.ToInt32(longerArr[i]) + Convert.ToInt32(shorterArr[i] - 96));
            }

            summedNum[i] += rest;                   // Add the result to cell in the summed array
            summedNum[i + 1] += digitInMind;        // Add the "1" in mind to next cell in the summed array
        }

        // Adding the rest digits of the longer num
        // when shorter num has no more digits.
        for (int i = shorterArr.Length; i < longerArr.Length; i++)
        {
            summedNum[i] = (byte)(longerArr[i] - 48);
        }

        Array.Reverse(summedNum);       // Reversing the number to get in the correct order

        string result = "";

        // Putting every digit in 1 string
        for (int i = 0; i < summedNum.Length; i++)
        {
            result += summedNum[i];
        }

        return BigInteger.Parse(result);       // Convert and return the string as number. Also removes the 0 in front.
    }

    static void Main()
    {
        Console.WriteLine("Enter two POSITIVE numbers");

        Console.Write("First number: ");
        BigInteger firstNum = BigInteger.Parse(Console.ReadLine());

        Console.Write("Second number: ");
        BigInteger secondNum = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine("Sum = " + AddNumbers(firstNum, secondNum));

        Console.WriteLine();
    }
}