using System;

class GreatestFromFiveNums
{
    // Write a program that finds the greatest of given 5 variables.

    static void Main()
    {
        Console.WriteLine("Enter five numbers:");
        Console.Write("1: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("2: ");
        int secondNum = int.Parse(Console.ReadLine());
        Console.Write("3: ");
        int thirdtNum = int.Parse(Console.ReadLine());
        Console.Write("4: ");
        int fourthNum = int.Parse(Console.ReadLine());
        Console.Write("5: ");
        int fifthNum = int.Parse(Console.ReadLine());

        int greatestNum = firstNum;

        if (greatestNum < secondNum)
        {
            greatestNum = secondNum;
        }
        if (greatestNum < thirdtNum)
        {
            greatestNum = thirdtNum;
        }
        if (greatestNum < fourthNum)
        {
            greatestNum = fourthNum;
        }
        if (greatestNum < fifthNum)
        {
            greatestNum = fifthNum;
        }
        Console.WriteLine("The greatest number is: {0}.", greatestNum);
        Console.WriteLine();
    }
}
