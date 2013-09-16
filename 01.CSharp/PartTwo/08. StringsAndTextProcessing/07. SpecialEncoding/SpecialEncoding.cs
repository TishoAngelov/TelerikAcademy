using System;
using System.Text;

class SpecialEncoding
{
    /*
        Write a program that encodes and decodes a string using given
        encryption key (cipher). The key consists of a sequence of
        characters. The encoding/decoding is done by performing
        over the first letter of the string with the first of the
        key, the second – with the second, etc. When the last key
        character is reached, the next is the first.
    */

    static string givenCipher = "telerik";

    static string Encode(string text)
    {
        StringBuilder encodedText = new StringBuilder(text.Length / 2);
        int textChar = 0;

        while (true)
        {
            for (int cipChar = 0; cipChar < givenCipher.Length; cipChar++)
            {
                encodedText.Append((char)(text[textChar++] ^ givenCipher[cipChar]));

                if (textChar == text.Length)
                {
                    return encodedText.ToString();
                }
            }            
        }       
    }

    static string Decode(string encodedText)
    {
        string decodedText = Encode(encodedText);
        
        return decodedText.ToString();
    }

    static void Main()
    {
        string givenText = "Write a program that encodes and decodes a string using given\n"
                                + "encryption key (cipher). The key consists of a sequence of\n"
                                + "characters. The encoding/decoding is done by performing\n"
                                + "over the first letter of the string with the first of the\n"
                                + "key, the second – with the second, etc. When the last key\n"
                                + "character is reached, the next is the first.";

        Console.WriteLine("Given text:\n{0}", givenText);

        string encodedText = Encode(givenText);
        Console.WriteLine("\nEncoded text:\n{0}", encodedText);

        Console.WriteLine("\nDecoded text:\n{0}", Decode(encodedText));

        Console.WriteLine();
    }
}