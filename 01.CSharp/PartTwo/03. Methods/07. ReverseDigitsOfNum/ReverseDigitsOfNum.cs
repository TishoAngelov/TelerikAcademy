using System;

class ReverseDigitsOfNum
{
    // Write a method that reverses the digits of given decimal number. 
    //      Example: 256 -> 652

    static int ReverseNumber(int num)
    {
        string reversedNum = "";

        for (int i = num.ToString().Length - 1; i >= 0 ; i--)
        {
            reversedNum += num.ToString()[i];
        }

        return Convert.ToInt32(reversedNum);
    }

    static void Main()
    {
        Console.Write("Enter one integer number: ");
        int intNum = int.Parse(Console.ReadLine());        

        Console.WriteLine("The number {0} is reversed now! - {1}", intNum, ReverseNumber(intNum));

        Console.WriteLine();
    }
}