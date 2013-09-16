﻿using System;
using System.Text.RegularExpressions;

class ExtractSentences
{
    /*
        Write a program that extracts from a given text all sentences containing given word.
		    Example: The word is "in". The text is:
                We are living in a yellow submarine. We don't have anything else. Inside the
                submarine is very tight. So we are drinking all the day. We will move out of
                it in 5 days.
            The expected result is:
                We are living in a yellow submarine.
                We will move out of it in 5 days.
        Consider that the sentences are separated by "." and the words – by non-letter symbols.
    */

    static void Main()
    {
        string givenText = "We are living in a yellow submarine. We don't have anything else.\n"
                             + "Inside the submarine is very tight. So we are drinking all\n"
                             + "the day. We will move out of it in 5 days.";
        Console.WriteLine("Given text:\n{0}\n", givenText);

        string[] sentences = givenText.Split('.');
        string givenWord = "in";

        for (int i = 0; i < sentences.Length; i++)
        {
            if (Regex.IsMatch(sentences[i], @"\b" + givenWord + @"\b", RegexOptions.IgnoreCase))
            {
                Console.Write(sentences[i] + ".");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}