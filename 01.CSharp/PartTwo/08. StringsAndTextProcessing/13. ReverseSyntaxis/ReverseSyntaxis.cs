using System;
using System.Text;

class ReverseSyntaxis
{
    // Write a program that reverses the words in given sentence.
	// Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".

    static void Main()
    {
        string givenSentence = "C# is not C++, not PHP and not Delphi!";
        Console.WriteLine("Given sentence: {0}\n", givenSentence);        

        char[] separators = { ' ', ',', '.', '!', '?' };
        string[] words = givenSentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        string[] wordsArray = givenSentence.Split(' ');
        StringBuilder reversedSentence = new StringBuilder(givenSentence.Length);

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] != wordsArray[i])
            {
                reversedSentence.Append(words[words.Length - 1 - i]);
                reversedSentence.Append(wordsArray[i][wordsArray[i].Length - 1]);
                reversedSentence.Append(' ');
            }
            else
            {
                reversedSentence.Append(words[words.Length - 1 - i]);
                reversedSentence.Append(' ');
            }
        }

        Console.WriteLine("The reversed sentence is: {0}", reversedSentence);

        Console.WriteLine();
    }
}