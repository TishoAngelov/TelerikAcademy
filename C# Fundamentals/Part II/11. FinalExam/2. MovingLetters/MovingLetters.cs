using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        char[] separators = { ' ' };

        string input = Console.ReadLine();
        string[] splitInput = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder[] words = new StringBuilder[splitInput.Length];

        for (int i = 0; i < splitInput.Length; i++)
		{
            words[i] = new StringBuilder(splitInput.Length);

            words[i].Append(splitInput[i]);
		}


        
        


        string extractedLett = ExtractLetters(words);

        int currK;

        for (int i = 0; i < extractedLett.Length; i++)
        {
            char currChar = extractedLett[i];

            if (currChar <= 'Z')
            {
                currK = currChar - 'A' + 1;
            }
            else
            {
                currK = currChar - 'a' + 1;
            }

            while (currK >= extractedLett.Length)
            {
                currK = currK - extractedLett.Length; 
            }

            extractedLett = extractedLett.Remove(i, 1);

            int nextPos = currK + i;

            while (nextPos > extractedLett.Length)
            {
                nextPos = nextPos - extractedLett.Length - 1;
            }

            extractedLett = extractedLett.Insert(nextPos, currChar.ToString());
        }

        Console.WriteLine(extractedLett);
        
    }

    static string ExtractLetters(StringBuilder[] str)
    {
        int strLen = 0;

        for (int i = 0; i < str.Length; i++)
        {
            strLen += str[i].Length;
        }

        StringBuilder result = new StringBuilder(strLen);

        while (strLen > 0)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() != "")
	            {
                    result.Append(str[i].ToString(), str[i].Length - 1, 1);


                    str[i] = str[i].Remove(str[i].Length - 1, 1);
                    strLen--;
	            }                
            }
        }

        return result.ToString();
    }
}