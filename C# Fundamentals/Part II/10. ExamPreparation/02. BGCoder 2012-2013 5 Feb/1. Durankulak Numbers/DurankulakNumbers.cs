using System;
using System.Numerics;

class DurankulakNumbers
{
    static string[] alphabet = new string[168];
    static BigInteger sum = 0;

    private static void FillAlphabet()
    {
        int index = 0;

        for (int i = 'A'; i <= 'Z'; i++)
        {
            alphabet[index] = ((char)i).ToString();
            index++;
        }

        for (int i = 'a'; i <= 'f'; i++)
        {
            string smaller = ((char)i).ToString();

            for (int j = 'A'; j <= 'Z'; j++)
            {
                string bigger = ((char)j).ToString();

                alphabet[index] = smaller + bigger;
                index++;

                if (index == 168)
                {
                    break;
                }
            }
        }
    }

    static void Main()
    {
        FillAlphabet();

        //for (int i = 0; i < alphabet.Length; i++)
        //{
        //    Console.WriteLine(alphabet[i] + " " + i);
        //}
        //for (int i = 0; i < alphabet.Length; i++)
        //{
        //    Console.Write(alphabet[i] + " ");
        //}

        string input = Console.ReadLine();
        string[] sepearated = new string[input.Length];

        //if (input.Length % 2 == 0)
        //{
            
        //}
        //else
        //{
        //    sepearated = new string[(input.Length + 1) / 2];

        //    //sepearated[s] = " ";

        //    //for (int i = input.Length - 1; i > 1; i -= 2)
        //    //{
        //    //    sepearated[s] = ((char)input[i - 1]).ToString() + ((char)input[i]).ToString();
        //    //    s++;
        //    //}
        //}

        int s = 0;

        for (int i = input.Length - 1; i >= 0; i -= 2)
        {
            if (i - 1 >= 0)
            {
                if (input[i - 1] >= 'A' && input[i - 1] <= 'Z')
                {
                    sepearated[s] = ((char)input[i]).ToString();
                   // s++;
                    
                   // sepearated[s] = ((char)input[i - 1]).ToString();
                    i++;
                }
                else
                {
                    sepearated[s] = ((char)input[i - 1]).ToString() + ((char)input[i]).ToString();
                }
                
            }
            else
            {
                sepearated[s] = ((char)input[i]).ToString();
            }

            s++;

            if (s >= sepearated.Length)
            {
                break;
            }
        }
        
        for (int i = 0; i < sepearated.Length; i++)
        {
            //Console.Write(sepearated[i] + " ");
            

            for (int j = 0; j < alphabet.Length; j++)
            {
                if (i == 0)
                {
                    if (sepearated[i] == alphabet[j])
                    {
                        sum += (ulong)j;
                    }
                }
                else
                {
                    if (sepearated[i] == alphabet[j])
                    {
                        sum += (ulong)j * (BigInteger)Math.Pow(168, i);
                    }
                }
                
            }
        }

        Console.WriteLine(sum);
    }
}