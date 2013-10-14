using System;
using System.IO;

class PrintOddLines
{
    // Write a program that reads a text file and prints on the console its odd lines.

    static void Main()
    {
        StreamReader reader = new StreamReader("test.txt");
        using (reader)
        {
            string oneLine = reader.ReadLine();
            int lineCounter = 0;

            Console.WriteLine("Odd lines");
            Console.WriteLine(new string('=', 20));

            while (oneLine != null)
            {
                lineCounter++;

                if (lineCounter % 2 != 0)
                {
                    Console.WriteLine(oneLine);
                }

                oneLine = reader.ReadLine();
            }
        }        

        Console.WriteLine();
    }
}