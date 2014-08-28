using System;
using System.Collections.Generic;
using System.Text;

class ConsoleJustification
{
    static int charsPerLine;

    static void Main()
    {
        int initialLines = int.Parse(Console.ReadLine());
        charsPerLine = int.Parse(Console.ReadLine());

        List<string> words = new List<string>();

        for (int i = 0; i < initialLines; i++)
        {
            string[] currLineWords = Console.ReadLine().Split(new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries);
            words.AddRange(currLineWords);
        }

        string result = string.Empty;
        string singleLine = string.Empty;

        int currLength = 0;
        int remainingChars = charsPerLine;

        for (int i = 0; i < words.Count; i++)
        {
            currLength += words[i].Length + 1;
            
            if (currLength <= charsPerLine + 1)
            {
                if (i == 0)
                {
                    remainingChars -= words[i].Length + 1;
                    singleLine += words[i];
                }
                else
                {
                    remainingChars -= words[i].Length + 1;
                    singleLine += " ";
                    singleLine += words[i];
                }

                if (i >= words.Count - 1)
                {
                    if (!LineHasOneWord(singleLine))
                    {
                        singleLine = AddSpaces(singleLine.Trim(), remainingChars + 1);
                        result += singleLine;
                    }
                    else
                    {
                        result += singleLine;
                    }
                }
            }
            else
            {
                remainingChars++;
                singleLine = singleLine.Trim();

                if (!LineHasOneWord(singleLine))
                {
                    singleLine = AddSpaces(singleLine, remainingChars);
                }

                result += singleLine + "\n";

                i--;
                currLength = 0;
                remainingChars = charsPerLine;

                singleLine = string.Empty;
            }            
        }

        result = result.Replace("\n ", "\n");

        Console.WriteLine(result);
    }

    private static bool LineHasOneWord(string str)
    {
        string[] asd = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (asd.Length == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private static string AddSpaces(string line, int remainings)
    {
        StringBuilder result = new StringBuilder();
        string temp = line;

        int i = 0;

        if (remainings == 0)
        {
            return line;
        }

        while ((remainings > 0) && (result.Length < charsPerLine))
        {
            if (temp[i].ToString() == " ")
            {
                result.Append("  ");
                remainings--;
                i++;

                while (temp[i] == ' ')
                {
                    result.Append(" ");
                    i++;
                }
            }
            else
            {
                result.Append(temp[i]);
                i++;
            }

            if (temp.Length <= i)
            {
                temp = result.ToString();
                result = new StringBuilder();
                i = 0;
            }
   
        }

        for (; i < temp.Length; i++)
        {
            result.Append(temp[i]);
        }

        return result.ToString();
    }
}