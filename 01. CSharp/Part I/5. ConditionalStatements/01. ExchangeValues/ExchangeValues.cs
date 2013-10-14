using System;

class ExchangeValues
{
    // Write an if statement that examines two integer variables and
    // exchanges their values if the first one is greater than the second one.

    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNum = int.Parse(Console.ReadLine());

        if (firstNum > secondNum)
        {
            Console.WriteLine("{0} > {1} and we must exchange their values.", firstNum, secondNum);
            int temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;
           
            Console.WriteLine("First number = {0}" +
                "{1}Second number = {2}", firstNum,Environment.NewLine, secondNum);
        }
        else
        {
            Console.WriteLine("First number isn't greater so we don't need to exchange them!");
        }
        Console.WriteLine();
    }
}