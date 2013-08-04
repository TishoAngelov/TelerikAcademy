using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class IndexesOfWord
{
    // Write a program that creates an array containing all letters from the alphabet (A-Z). 
    // Read a word from the console and print the index of each of its letters in the array.

    static void Main()
    {
        char[] letters = new char[26];

        Console.WriteLine("The array with lettes:");

        for (int i = 0, num = 65; i < 26; i++, num++)
        {
            letters[i] = (char)num;
            Console.WriteLine("   Letter[{0}] = {1}", i, (char)num);
        }
        
        Console.Write("\nEnter a word : ");
        string word = Console.ReadLine();

        word = word.ToUpper(); // Convert the word in capital letters

        bool hasFound = false;

        Console.WriteLine("\nThe letters and their indexes:");

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i].Equals(letters[j]))
                {
                    hasFound = true;
                    Console.WriteLine("The letter {0} has index {1}", word[i], j);
                }
            }
            if (!hasFound)
            {
                Console.WriteLine("The character {0} is not a letter !!!", word[i]);
            }
            hasFound = false;
        } 

        Console.WriteLine();
    }
}