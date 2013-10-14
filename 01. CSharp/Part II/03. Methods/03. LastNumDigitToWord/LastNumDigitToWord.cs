using System;

class LastNumDigitToWord
{
    // Write a method that returns the last digit of given integer as an English word.
    //     Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

    static string NumToWord(int num)
    {
        string digitToWord = "";

        switch (num % 10)       // gets the last digit
        {
            case 0:
                digitToWord = "zero";
                break;
            case 1:
                digitToWord = "one";
                break;
            case 2:
                digitToWord = "two";
                break;
            case 3:
                digitToWord = "three";
                break;
            case 4:
                digitToWord = "four";
                break;
            case 5:
                digitToWord = "five";
                break;
            case 6:
                digitToWord = "six";
                break;
            case 7:
                digitToWord = "seven";
                break;
            case 8:
                digitToWord = "eight";
                break;
            case 9:
                digitToWord = "nine";
                break;
        }

        return digitToWord;
    }

    static void Main()
    {
        Console.Write("Enter 1 number: ");
        int intNum = int.Parse(Console.ReadLine());

        Console.WriteLine("Last digit: {0}", NumToWord(intNum));

        Console.WriteLine();
    }
}