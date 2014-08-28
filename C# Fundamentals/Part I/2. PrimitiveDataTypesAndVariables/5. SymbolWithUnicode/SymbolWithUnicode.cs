using System;

class SymbolWithUnicode
{
    /*
    Declare a character variable and assign it with the symbol that
    has Unicode code 72. Hint: first use the Windows Calculator to
    find the hexadecimal representation of 72.
    */

    static void Main()
    {
        char hexUnicode = '\u0048';

        Console.WriteLine("The symbol that has Unicode code 72 is {0}.\n\n", hexUnicode);
    }
}

