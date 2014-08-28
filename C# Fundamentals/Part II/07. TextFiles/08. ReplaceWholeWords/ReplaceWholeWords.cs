using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

class ReplaceWholeWords
{
    // Modify the solution of the previous problem (07) to replace only whole words (not substrings).

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
        string createFilePath = "../../input.txt";
        CreateLargeFile.CreateTheLargeFile(createFilePath);         // using the project 00. Create120MBFile

        string inputFile = createFilePath;
        string outputFile = "output.txt";

        Console.WriteLine("\nReplacing... Please wait...\n");

        StreamReader reader = new StreamReader(inputFile);
        using (reader)
        {
            StreamWriter writer = new StreamWriter(outputFile);
            using (writer)
            {
                string readSingleLine = reader.ReadLine();

                while (readSingleLine != null)
                {
                    readSingleLine = Regex.Replace(readSingleLine, @"\bstart\b", "finish");
                    writer.WriteLine(readSingleLine);
                    readSingleLine = reader.ReadLine();
                }
            }
        }

        Console.WriteLine("Finish!");

        OpenResultFile(outputFile);
    }
}