using System;

class EnterNumbers
{
    /*
        Write a method ReadNumber(int start, int end) that enters an integer number in given
        range [start…end]. If an invalid number or non-number text is entered, the method
        should throw an exception. Using this method write a program that enters 10 numbers:
			    a1, a2, … a10, such that 1 < a1 < … < a10 < 100
    */

    static int numCounter = 1;

    static int ReadNumber(int start, int end)
    {
        int num = 0;

        while (true)
        {
            Console.Write("\nNumber {0} = ", numCounter);

            try
            {
                num = int.Parse(Console.ReadLine());

                if (num <= start || num >= end)
                {                    
                    throw new ArgumentOutOfRangeException();
                }

                numCounter++;
                return num;
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number. Please enter non null value.");
            }

            catch (FormatException)
            {
                Console.WriteLine("Not a number. Please enter a valid number.");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Invalid number. The number is ot of Int32 range.");
            }
        }
    }

    static void Main()
    {
        int start = 1;
        int end = 100;

        int numbersCount = 10;
        int[] numbers = new int[numbersCount];
        Console.WriteLine("Enter {0} numbers", numbersCount);

        for (int i = 0; i < numbersCount; i++)
        {
            try
            {
                numbers[i] = ReadNumber(start, end);
                start = numbers[i];
            }
            catch (ArgumentOutOfRangeException)
            {
                i--;
                Console.WriteLine("Please enter a number in the range {0} - {1}", start, end - 1);
                Console.WriteLine("a1, a2, .. a10, such that 1 < a1 < .. < a10 < 100");
            }
        }

        Console.WriteLine("Goodbye!");
        Console.WriteLine();
    }
}