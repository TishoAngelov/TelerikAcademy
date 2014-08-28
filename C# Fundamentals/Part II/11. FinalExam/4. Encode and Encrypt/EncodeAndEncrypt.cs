using System;
using System.Text;
using System.Text.RegularExpressions;

class EncodeAndEncrypt
{

    static string Encrypt(string mess, string cyp)
    {
        StringBuilder encodedText = new StringBuilder();
        int textChar = 0;

        if (mess.Length < cyp.Length)
        {
            int maxLen = 0;
            string temp = string.Empty;
            int cipChar = 0;
            StringBuilder result = new StringBuilder();

            while (maxLen < cyp.Length)
            {
                for (int messChar = 0; messChar < mess.Length; messChar++)
                {
                    if (maxLen == cyp.Length)
                    {
                        break;
                    }
                    char messageChar = (char)(mess[messChar] - 'A');
                    char cipherChar = (char)(cyp[cipChar++] - 'A');


                    encodedText.Append((char)((messageChar ^ cipherChar) + 'A'));

                    maxLen++;
                }

                mess = encodedText.ToString();
                result.Append(encodedText);

                encodedText = new StringBuilder();



            }

            return result.ToString();
        }
        else
        {
            while (true)
            {
                for (int cipChar = 0; cipChar < cyp.Length; cipChar++)
                {
                    char messageChar = (char)(mess[textChar++] - 'A');
                    char cipherChar = (char)(cyp[cipChar] - 'A');


                    encodedText.Append((char)((messageChar ^ cipherChar) + 'A'));

                    if (textChar == mess.Length)
                    {
                        return encodedText.ToString();
                    }
                }
            }
        }

    }

    static string Encode(string str)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < str.Length - 1; i++)
        {
            int counter = 1;


            if ((str[i + 1] == str[i]))
            {
                while (str[i + 1] == str[i])
                {
                    counter++;
                    if (i + 1 < str.Length - 1)
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                result.Append(counter);
                result.Append(str[i]);
                i++;
                result.Append(str[i]);
            }
            else
            {
                result.Append(str[i]);

                if (i == str.Length - 2)
                {
                    result.Append(str[str.Length - 1]);
                }
            }

        }

        string asd = string.Empty;

        asd = result.ToString();

        for (int i = 0; i < asd.Length - 1; i++)
        {
            if (asd[i] == '2')
            {
                asd = asd.Replace(asd[i], asd[i + 1]);
            }
        }

        return asd;
    }


    static string cypher;
    static string message;
    static string cypherText;

    static void Main()
    {
        Console.WriteLine(Encode("BBBBBBA"));
        message = Console.ReadLine();
        cypher = Console.ReadLine();

        cypherText = Encrypt(message, cypher);



        StringBuilder temp = new StringBuilder();

        temp.Append(cypherText);
        temp.Append(cypher);

        string encodedText = Encode(temp.ToString());




        Console.WriteLine("{0}{1}", encodedText, cypher.Length);
    }
}