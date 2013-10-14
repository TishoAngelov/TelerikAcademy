using System;
using System.IO;

class HTML
{
    /*
        Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 
        <html>
          <head><title>News</title></head>
          <body><p><a href="http://academy.telerik.com">Telerik
            Academy</a>aims to provide free real-world practical
            training for young people who want to turn into
            skillful .NET software engineers.</p></body>
        </html>
    */

    static void Main()
    {
        string someStr;
        StreamReader input = new StreamReader("Telerik.html");

        Console.WriteLine("HTML file content:");

        using (input)
        {
            someStr = input.ReadToEnd();
            Console.WriteLine(someStr);
        }

        int startIndex = someStr.IndexOf('<');
        int endIndex = someStr.IndexOf('>');

        while (startIndex != -1)
        {
            someStr = someStr.Remove(startIndex, endIndex - startIndex + 1);

            startIndex = someStr.IndexOf('<');
            endIndex = someStr.IndexOf('>');
        }

        someStr = someStr.Replace("\r", "");
        someStr = someStr.Replace("\t", "");
        someStr = someStr.Trim();

        Console.WriteLine("\nThe contents without tags: \n{0}\n", someStr);

        Console.WriteLine();
    }
}