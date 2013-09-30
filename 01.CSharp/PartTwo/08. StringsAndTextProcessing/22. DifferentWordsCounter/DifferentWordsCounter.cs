using System;

class DifferentWordsCounter
{
    // Write a program that reads a string from the console and lists all different
    // words in the string along with information how many times each word is found.

    static void Main()
    {
        string givenText = "aaa bb aa bb aa cc cc";
        Console.WriteLine("Given text: {0}\n", givenText);

        string result = string.Empty;

        string[] split = givenText.Split(' ');

        for (int i = 0; i < split.Length; i++)
        {
            int counter = 1;

            if (split[i] != ".")
            {
                result += split[i] + " - ";
            }

            for (int j = i + 1; j < split.Length; j++)
            {
                if (split[j].Equals(split[i]) && split[i] != ".")
                {
                    counter++;
                    split[j] = split[j].Replace(split[j].ToString(), ".");
                }
            }

            if (split[i] != ".")
            {
                result += counter + "\n";
            }
        }

        Console.WriteLine(result);
    }
} 