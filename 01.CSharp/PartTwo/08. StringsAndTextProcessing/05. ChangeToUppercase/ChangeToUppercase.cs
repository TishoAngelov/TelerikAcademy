using System;
using System.Text;

class ChangeToUppercase
{
    /*
        You are given a text. Write a program that changes the text in all regions surrounded
        by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example

            We are living in a <upcase>yellow submarine</upcase>.
            We don't have <upcase>anything</upcase> else.

        The expected result:

        We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
    */

    static string ApplyUpcaseTags(string text)
    {
        string[] upcaseTag = { "<upcase>", "</upcase>" };
        string[] splitedText = text.Split(upcaseTag, StringSplitOptions.None);      // Removing the upcase tags.

        StringBuilder textToUpper = new StringBuilder();

        for (int i = 0; i < splitedText.Length; i++)
        {
            if ((i + 1) % 2 == 0)                                   // Adding 1 to avoid the 0 % 2 at start.
            {
                textToUpper.Append(splitedText[i].ToUpper());
            }
            else
            {
                textToUpper.Append(splitedText[i]);
            }
        }

        return textToUpper.ToString();
    }

    static void Main()
    {
        string firstText = "We are living in a <upcase>yellow submarine</upcase>.\n"
                                + "We don't have <upcase>anything</upcase> else.";
        Console.WriteLine("First given text:\n{0}", firstText);

        Console.WriteLine("\nText to upper (using the tags):");
        Console.WriteLine(ApplyUpcaseTags(firstText));

        string secondText = "<upcase>We are</upcase> living in a <upcase>yellow submarine</upcase>.\n"
                        + "We don't have <upcase>anything</upcase> else.";
        Console.WriteLine("\nSecond given text:\n{0}", secondText);

        Console.WriteLine("\nText to upper (using the tags):");
        Console.WriteLine(ApplyUpcaseTags(secondText));

        Console.WriteLine();
    }
}