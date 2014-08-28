using System;

class SquareRoot
{
    // Write a program that reads an integer number and calculates and prints
    // its square root. If the number is invalid or negative, print "Invalid number".
    // In all cases finally print "Good bye". Use try-catch-finally.

    static void Main()
    {
        Console.Write("Enter one positive integer number: ");

        try
        {
            int intNum = int.Parse(Console.ReadLine());

            if (intNum < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double squareRoot = Math.Sqrt(intNum);
            Console.WriteLine("Square root of {0} is {1}.", intNum, squareRoot);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number. Please enter non null value.");
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number. Please enter positive number.");
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid number. Please enter a valid number.");
        }

        catch (OverflowException)
        {
            Console.WriteLine("Invalid number. Please enter a number in the range 0 - {0}", int.MaxValue);
        }

        finally
        {
            Console.WriteLine("Goodbye.");
        }

        Console.WriteLine();
    }
}