using System;

class PrintASCIITable
{
    /*
    Find online more information about ASCII (American Standard Code for Information
    Interchange) and write a program that prints the entire ASCII table of characters on the console.
    */

    static void Main()
    {
        char symbol;

        Console.WriteLine("Some information about ASCII table:\n\n" +
                            "The American Standard Code for Information Interchange (ASCII) is a character-encoding " +
                            "scheme originally based on the English alphabet. ASCII codes represent text in computers, " +
                            "communications equipment, and other devices that use text. ASCII includes definitions for " +
                            "128 characters: 33 are non-printing control characters that affect how text and space are " +
                            "processed and 95 printable characters. ASCII was the most commonly used character encoding " +
                            "on the World Wide Web until December 2007, when it was surpassed by UTF-8.\n\n");
        Console.WriteLine("Here it is the ASCII table:\n\n");
        Console.WriteLine("Dec code -> ASCII Symbol\n");
        for (int decValue = 0; decValue <= 127; decValue++)
        {
            symbol = (char)decValue;
            Console.WriteLine("{0} -> {1}", decValue, symbol);
        }
    }
}