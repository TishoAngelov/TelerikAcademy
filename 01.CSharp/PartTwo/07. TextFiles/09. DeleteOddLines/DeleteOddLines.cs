using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class DeleteOddLines
{
    // Write a program that deletes from given text file all odd lines. The result should be in the same file.

    public static void OpenResultFile(string path)
    {
        Thread.Sleep(2000);
        Console.WriteLine("The file with the result will be opened for you after 3 seconds!\n");

        Console.WriteLine("==================== 3 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 2 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 1 ====================\n\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("Goodbye. :)\n");
        Console.Beep(); Console.Beep(); Console.Beep();

        Process.Start(path);
    }

    static void Main()
    {
        string filePath = "file.txt";
        int linesToWrite = 33;

        // writing to a file
        StreamWriter writeTheFile = new StreamWriter(filePath);
        using (writeTheFile)
        {
            for (int i = 1; i <= linesToWrite; i++)
            {
                if (i % 2 == 0)
                {
                    writeTheFile.WriteLine("I am even line. I am invincible!");
                }
                else
                {
                    writeTheFile.WriteLine("I am odd line. If you don't see me I am deleted ;(!");
                }
            }
        }

        Console.WriteLine("The file has been created!");

        // deleting odd lines
        string result = "";
        int lineCounter = 1;
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {            
            string readSingleLine = reader.ReadLine();
            
            while (readSingleLine != null)
            {
                if (lineCounter % 2 == 0)
                {
                    result += readSingleLine;
                    result += "\r\n";
                }
                //else                               to add empty line at deleted one
                //{
                //    result += "\r\n";
                //}

                readSingleLine = reader.ReadLine();
                lineCounter++;
            }
        }

        Console.WriteLine("Odd lines deleted!");

        // rewriting the file
        StreamWriter overwriteFile = new StreamWriter(filePath);
        using (overwriteFile)
        {
            overwriteFile.Write(result);
        }

        OpenResultFile(filePath);
    }
}