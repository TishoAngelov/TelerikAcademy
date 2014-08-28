using System;

class Dictionary
{
    /*
        A dictionary is stored as a sequence of text lines containing words and their explanations. 
        Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
            .NET – platform for applications from Microsoft
            CLR – managed execution environment for .NET
            namespace – hierarchical organization of classes
    */

    static void Main()
    {
        string[] dictionary = { ".NET – platform for applications from Microsoft",
                                "CLR – managed execution environment for .NET",
                                "namespace – hierarchical organization of classes" };

        Console.WriteLine("Dictionary");
        Console.WriteLine(new string('=', 40));

        Console.Write("Enter a word: ");
        string word = Console.ReadLine().Trim();

        for (int i = 0; i < dictionary.Length; i++)
        {
            if (dictionary[i].Substring(0, word.Length).Equals(word))
            {
                Console.WriteLine("Explanation: {0}", dictionary[i].Replace(word + " – ", string.Empty));                

                break;
            }

            if (i == dictionary.Length - 1)
            {
                Console.WriteLine("The word is not in the dictionary!");
            }
        }

        Console.WriteLine();
    }
}