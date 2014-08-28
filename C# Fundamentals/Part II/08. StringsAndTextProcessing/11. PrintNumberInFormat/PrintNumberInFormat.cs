using System;

class PrintNumberInFormat
{
    // Write a program that reads a number and prints it as a decimal number, hexadecimal
    // number, percentage and in scientific notation. Format the output aligned right in 15 symbols.

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.WriteLine("{0, 23} {1,15:D}", "To decimal:", number);

        Console.WriteLine("{0, 23} {1,15:X}", "To hexadecimal:", number);
        
        Console.WriteLine("{0, 23} {1,15:P}", "To percentage:", number);

        Console.WriteLine("{0, 23} {1,15:E}", "To scientific notation:", number);

        Console.WriteLine();
    }
}