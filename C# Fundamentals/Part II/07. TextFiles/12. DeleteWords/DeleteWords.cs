using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;

class DeleteWords
{
    // Write a program that removes from a text file all words listed in
    // given another text file. Handle all possible exceptions in your methods.

    static void Main()
    {
        string listedWordsPath = "../../listedWords.txt";
        string givenTextPath = "../../text.txt";

        string[] listedWords;
        string result = string.Empty;

        Console.WriteLine("Listed words");

        try
        {
            StreamReader listedWordsReader = new StreamReader(listedWordsPath);
            using (listedWordsReader)
            {
                listedWords = listedWordsReader.ReadToEnd().Split('\n', ' ');

                for (int i = 0; i < listedWords.Length; i++)
                {
                    listedWords[i].Trim();
                    Console.Write(listedWords[i] + " ");
                }

                Console.WriteLine();
            }

            StreamReader givenTextReader = new StreamReader(givenTextPath);
            using (givenTextReader)
            {
                result = givenTextReader.ReadToEnd();

                for (int i = 0; i < listedWords.Length; i++)
			    {
                    result = Regex.Replace(result, @"\b" + listedWords[i] + @"\b", string.Empty);
			    }                

                Console.WriteLine();
            }
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

        Console.WriteLine("After removing listed words");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine(result);
        Console.WriteLine();
    }
}