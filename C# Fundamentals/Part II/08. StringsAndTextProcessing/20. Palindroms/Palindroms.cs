using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;    

class ExtractPalindroms
{
    // Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    static void CheckWord(string str)
    {
        bool isPalindrom = true;
        string checkedWord = RemoveEmptySpaces(str).ToLower();

        for (int i = 0; i < checkedWord.Length / 2; i++)
        {
            if (checkedWord[i] != checkedWord[checkedWord.Length - i - 1])
            {
                isPalindrom = false;
                break;
            }
        }

        if (isPalindrom)
        {
            Console.WriteLine("{0}\n", str.Trim());
        }
    }

    public static string RemoveEmptySpaces(string str)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                sb.Append(str[i]);
            }
        }

        return sb.ToString();
    }

    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        string text = "ABBA lamal exe";
        string[] separators = { ".", ",", "!", " ", "?", ":", ";", "—", "-", "\"", "'" };
        string[] separatedWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<string> words = new List<string>();

        for (int i = 0; i < separatedWords.Length; i++)
        {
            StringBuilder sb = new StringBuilder();

            for (int j = i; j < separatedWords.Length; j++)
            {
                sb.Append(separatedWords[j]);
                sb.Append(" ");
                words.Add(sb.ToString());
            }
        }

        Console.WriteLine("Palindroms in the text:");

        for (int i = 0; i < words.Count; i++)
        {
            CheckWord(words[i]);
        }

        Console.WriteLine();
    }
}