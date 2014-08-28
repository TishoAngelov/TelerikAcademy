using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefix
{
    // Write a program that deletes from a text file all words that start with 
    // the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

    static void Main()
    {
        string filePath = "../../text.txt";
        StringBuilder result = new StringBuilder();

        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            string readSingleLine = reader.ReadLine();

            while (readSingleLine != null)
            {
                readSingleLine = Regex.Replace(readSingleLine, @"\btest\w*\b", string.Empty);

                result.Append(readSingleLine);
                result.Append(Environment.NewLine);

                readSingleLine = reader.ReadLine();
            }
        }

        Console.WriteLine(result);
        Console.WriteLine();
    }
}