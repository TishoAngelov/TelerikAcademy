using System;
using System.IO;

class InsertLineNumbering
{
    // Write a program that reads a text file and inserts line numbers in
    // front of each of its lines. The result should be written to another text file.

    static void PrintFileContent(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        string fileContent = string.Empty;
        using (reader)
        {
            fileContent = reader.ReadToEnd();
            Console.WriteLine(fileContent);
        }
    }

    static void Main()
    {
        string firstFilePath = "../../firstFile.txt";
        string firstFileContent = string.Empty;

        StreamReader firstFileReader = new StreamReader(firstFilePath);
        using (firstFileReader)
        {
            string oneLine = firstFileReader.ReadLine();
            int lineCounter = 0;
            
            while (oneLine != null)
            {
                lineCounter++;
                firstFileContent += "Line " + lineCounter + ":  " + oneLine + "\n";     // faster with StringBuilder but
                                                                                        // shorter to write with string
                oneLine = firstFileReader.ReadLine();
            }
        }

        string secFilePath = "../../secFile.txt";

        StreamWriter secFileWriter = new StreamWriter(secFilePath);
        using (secFileWriter)
        {
            secFileWriter.Write(firstFileContent);
        }

        // printing the result
        Console.WriteLine("Original file content");
        Console.WriteLine(new string('=', Console.WindowWidth));
        PrintFileContent(firstFilePath);
        Console.WriteLine();

        Console.WriteLine("After adding line numbering and saving to a new file");
        Console.WriteLine(new string('=', Console.WindowWidth));
        PrintFileContent(secFilePath);
    }
}