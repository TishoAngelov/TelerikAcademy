using System;

class ShowSign
{
    // Write a program that shows the sign (+ or -) of the product of three real
    // numbers without calculating it. Use a sequence of if statements.

    static void Main()
    {
        int minusSignCounter = 0;
        float[] realNum = new float[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter real number: ");
            realNum[i] = float.Parse(Console.ReadLine());

            if (realNum[i] < 0)
            {
                minusSignCounter++;
            }
        }

        if (minusSignCounter % 2 == 0)
        {
            Console.WriteLine("The sign of the product is plus.");
        }
        else
        {
            Console.WriteLine("The sign of the product is minus.");
        }

        Console.WriteLine();
    }
}

