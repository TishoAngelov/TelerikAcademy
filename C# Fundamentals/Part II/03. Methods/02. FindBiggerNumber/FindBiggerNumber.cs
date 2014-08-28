using System;

class FindBiggerNumber
{
    // Write a method GetMax() with two parameters that returns the 
    // bigger of two integers.Write a program that reads 3 integers from
    // the console and prints the biggest of them using the method GetMax().

    static int GetMax(int num1, int num2)
    {
        return num1 > num2 ? num1 : num2;
    }

    static void Main()
    {
        Console.WriteLine("Enter three numbers (integer)");

        Console.Write("First number: ");
        int firstNum = int.Parse(Console.ReadLine());

        Console.Write("Second number: ");
        int secondNum = int.Parse(Console.ReadLine());

        Console.Write("Third number: ");
        int thirdNum = int.Parse(Console.ReadLine());

        if (firstNum == secondNum && secondNum == thirdNum)
        {
            Console.WriteLine("The numbers are euqal!");
            Console.WriteLine("{0} = {0} = {0}", firstNum);
        }
        else
        {
            int tempBiggerNum = GetMax(firstNum, secondNum);

            Console.WriteLine("The bigger number is: {0}", GetMax(tempBiggerNum, thirdNum));
        }        

        Console.WriteLine();
    }
}