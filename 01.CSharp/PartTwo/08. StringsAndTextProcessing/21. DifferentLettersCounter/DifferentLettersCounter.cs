using System;

class DifferentLettersCounter
{
    // Write a program that reads a string from the console and prints all different
    // letters in the string along with information how many times each letter is found. 

    static void Main()
    {
        string givenText = "Write a program that reads a string from the console and prints all different";
        Console.WriteLine("Given text: {0}\n", givenText);

        givenText = givenText.ToLower();

        char[] aaa = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                             'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        string result = string.Empty;

        for (int i = 0; i < aaa.Length; i++)
        {
            bool found = false;
            int counter = 0;
            
            for (int j = 0; j < givenText.Length; j++)
            {
                if (givenText[j].Equals(aaa[i]) && !found)
                {
                    result += aaa[i] + " - ";
                    found = true;
                }
                if (givenText[j].Equals(aaa[i]))
                {

                    counter++;
                }
                
            }

            if (found)
            {
                result += counter + "\n";
            }            
        }

        Console.WriteLine(result);

        Console.WriteLine();
    }
}