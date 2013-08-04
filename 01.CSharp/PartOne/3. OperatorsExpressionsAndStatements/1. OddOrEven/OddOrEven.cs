using System;

class OddOrEven
{
    // Write an expression that checks if given integer is odd or even.

    static void Main()
    {
        int intNum = 0;
        string OddOrEven = "";

        do
        {
            Console.WriteLine("---- For exit enter \"0\" ----\n");
            Console.Write("Please enter 1 number: ");
            intNum = int.Parse(Console.ReadLine());

            OddOrEven = intNum % 2 == 0 ? "even" : "odd"; // Can be done with if construction too.

            Console.WriteLine("The number {0} is {1}.", intNum, OddOrEven);
        } while (intNum != 0);

        Console.WriteLine();
    }
}

