using System;

class Quoted_Escaped_Strings
{
    /*
    Declare two string variables and assign them with following value:
    The "use" of quotations causes difficulties.
    Do the above in two different ways: with and without using quoted strings.
    */

    static void Main()
    {
        string quotedString = @"The ""use"" of quotations causes difficulties.";
        string escapedString = "The \"use\" of quotations causes difficulties.";

        Console.WriteLine("Assign quoted string: @\"The \"\"use\"\" of quotations causes difficulties.\"");
        Console.WriteLine("Assign escaped string: \"The \\\"use\\\" of quotations causes difficulties.\"");
        Console.WriteLine("\nThe result is the same:");
        Console.WriteLine("Using quoted string: {0}", quotedString);
        Console.WriteLine("Using escaped string: {0}\n\n", escapedString);
    }
}