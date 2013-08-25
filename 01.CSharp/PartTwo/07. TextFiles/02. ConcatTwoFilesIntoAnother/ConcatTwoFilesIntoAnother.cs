using System;
using System.IO;

class ConcatTwoFilesIntoAnother
{
    // Write a program that concatenates two text files into another text file.

    static void FirstSolution()
    {
        StreamReader firstFileReader = new StreamReader("../../firstFile.txt");
        string firstFileContent = string.Empty;
        using (firstFileReader)
        {
            firstFileContent = firstFileReader.ReadToEnd();
        }

        StreamReader secFileReader = new StreamReader("../../secFile.txt");
        string secFileContent = string.Empty;
        using (secFileReader)
        {
            secFileContent = secFileReader.ReadToEnd();
        }

        StreamWriter thirdFileWriter = new StreamWriter("../../thirdFile.txt");
        using (thirdFileWriter)
        {
            thirdFileWriter.WriteLine(firstFileContent);
            thirdFileWriter.WriteLine(secFileContent);
        }
    }

    static void SecondSolution()
    {
        StreamReader firstFileReader = new StreamReader("../../firstFile.txt");
        string firstFileContent = string.Empty;
        using (firstFileReader)
        {
            firstFileContent = firstFileReader.ReadToEnd();

            StreamWriter thirdFileWriter = new StreamWriter("../../thirdFile.txt");
            using (thirdFileWriter)
            {
                thirdFileWriter.WriteLine(firstFileContent);
            }
        }

        StreamReader secFileReader = new StreamReader("../../secFile.txt");
        string secFileContent = string.Empty;
        using (secFileReader)
        {
            secFileContent = secFileReader.ReadToEnd();

            StreamWriter thirdFileWriter = new StreamWriter("../../thirdFile.txt", true);
            using (thirdFileWriter)
            {
                thirdFileWriter.WriteLine(secFileContent);
            }
        }
    }

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
        string thirdFilePath = ".../../thirdFile.txt";

        Console.WriteLine("First solution");
        Console.WriteLine(new string('=', 50));
        FirstSolution();
        PrintFileContent(thirdFilePath);

        Console.WriteLine("Second solution");
        Console.WriteLine(new string('=', 50));
        SecondSolution();
        PrintFileContent(thirdFilePath);       
    }
}
