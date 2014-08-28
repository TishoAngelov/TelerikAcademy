using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

class CountListedWordsInFile
{
    /*
        Write a program that reads a list of words from a file words.txt and finds how many
        times each of the words is contained in another file test.txt. The result should be
        written in the file result.txt and the words should be sorted by the number of their
        occurrences in descending order. Handle all possible exceptions in your methods.
    */

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
        string wordsPath = "../../words.txt";
        string testPath = "../../test.txt";
        string resultPath = "result.txt";

        string[] listedWords;
        string result = string.Empty;

        Console.WriteLine("Listed words");

        try
        {
            // Reading the listed words
            StreamReader wordsReader = new StreamReader(wordsPath);
            using (wordsReader)
            {
                listedWords = wordsReader.ReadToEnd().Split('\n', ' ');

                for (int i = 0; i < listedWords.Length; i++)
                {
                    listedWords[i].Trim();
                    Console.Write(listedWords[i] + " ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            // Reading the test file and count the matching words
            int[] values = new int[listedWords.Length];

            StreamReader testReader = new StreamReader(testPath);
            using (testReader)
            {
                result = testReader.ReadToEnd();

                for (int i = 0; i < listedWords.Length; i++)
                {
                    values[i] += Regex.Matches(result, @"\b" + listedWords[i] + @"\b").Count;
                }

                Console.WriteLine("Counting finished.\n");
            }

            // Sorting (ascending)
            Array.Sort(values, listedWords);

            // Writing the result in result.txt 
            StreamWriter resultWriter = new StreamWriter(resultPath);
            using (resultWriter)
            {
                // Writing the result in descending order
                for (int i = listedWords.Length - 1; i >= 0; i--)
                {
                    resultWriter.WriteLine("{0}: {1} times", listedWords[i], values[i]);
                }

                Console.WriteLine("Result is saved in result.txt.\n");
            }

            // Auto open the result
            OpenResultFile(resultPath);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();
    }
}