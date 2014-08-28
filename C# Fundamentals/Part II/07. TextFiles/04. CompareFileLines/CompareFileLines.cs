using System;
using System.IO;

class CompareFileLines
{
    // Write a program that compares two text files line by line and prints the number
    // of lines that are the same and the number of lines that are different.
    // Assume the files have equal number of lines.

    static void Main()
    {
        string firstFilePath = "../../firstFile.txt";
        string secFilePath = "../../secFile.txt";

        string sameLines = string.Empty;
        int sameLinesCounter = 0;
        int diffLinesCounter = 0;
        int lineCounter = 0;

        StreamReader firstFileReader = new StreamReader(firstFilePath);
        using (firstFileReader)
        {
            StreamReader secFileReader = new StreamReader(secFilePath);
            using (secFileReader)
            {
                string firstFileSingleLine = firstFileReader.ReadLine();
                string secFileSingleLine = secFileReader.ReadLine();

                // Assume the files have equal number of lines.
                while (secFileSingleLine != null)
                {                                        
                    lineCounter++;

                    if (firstFileSingleLine == secFileSingleLine)
                    {
                        sameLinesCounter++;
                        sameLines += lineCounter + " ";
                    }
                    else
                    {
                        diffLinesCounter++;
                    }

                    // reading another single line
                    firstFileSingleLine = firstFileReader.ReadLine();
                    secFileSingleLine = secFileReader.ReadLine();
                }
            }
        }

        Console.WriteLine("Total {0} lines.", lineCounter);
        Console.WriteLine("Same lines count: {0}", sameLinesCounter);
        Console.WriteLine("Same line numbers: {0}", sameLines);
        Console.WriteLine("Different lines count: {0}", diffLinesCounter);
        Console.WriteLine();
    }
}