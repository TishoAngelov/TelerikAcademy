using System;
using System.Text;

namespace _01.ExtMethodSubstringForSB
{
    // Implement an extension method Substring(int index, int length) for the class StringBuilder
    // that returns new StringBuilder and has the same functionality as Substring in the class String.
    public static class ExtMethodSubstringForSB
    {
        public static StringBuilder Substring(this StringBuilder sbInput, int startIndex, int length = 1)
        {
            if (startIndex < 0 ||
                length < 0 || length + startIndex > sbInput.Length)
            {
                throw new IndexOutOfRangeException("Index or length out of range!");
            }

            StringBuilder substring = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                substring.Append(sbInput[startIndex + i]);
            }

            return substring;
        }

        static void Main()
        {
            StringBuilder input = new StringBuilder();
            input.Append("TELERIK");

            StringBuilder output = input.Substring(2);
            Console.WriteLine(output);          // L

            output = input.Substring(2, 5);
            Console.WriteLine(output);          // LERIK

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception will be thrown now!");
            Console.WriteLine();
            Console.ResetColor();

            output = input.Substring(2, 6);     // Throws exception    
        }
    }
}