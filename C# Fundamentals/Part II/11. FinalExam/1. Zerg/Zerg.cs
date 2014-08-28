using System;
using System.Numerics;

class Zerg
{
    static void Main()
    {
        string[] alphabet = { "Rawr",
                                "Rrrr",
                                "Hsst",
                                "Ssst",
                                "Grrr",
                                "Rarr",
                                "Mrrr",
                                "Psst",
                                "Uaah",
                                "Uaha",
                                "Zzzz",
                                "Bauu",
                                "Djav",
                                "Myau",
                                "Gruh" };


        string input = Console.ReadLine();
        string[] words = new string[input.Length / 4];
        int counter = 0;
        int wordsIndex = 0;

        for (int i = 0; i < input.Length; i++)
        {
            counter++;

            words[wordsIndex] += input[i];

            if (counter >= 4)
            {
                counter = 0;
                wordsIndex++;
            }            
        }

        Array.Reverse(words);
        ///////////////////////////////////////////////
        BigInteger sum = 0;

        for (int i = 0; i < words.Length; i++)
        {
            //Console.Write(sepearated[i] + " ");


            for (int j = 0; j < alphabet.Length; j++)
            {
                if (i == 0)
                {
                    if (words[i] == alphabet[j])
                    {
                        sum += j;
                    }
                }
                else
                {
                    if (words[i] == alphabet[j])
                    {
                        sum += j * (BigInteger)Math.Pow(15, i);
                    }
                }

            }
        }


        Console.WriteLine(sum);

    }
}