using System;
using System.Collections.Generic;

class KaspichanNumbers
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        List<string> digits = new List<string>();

        for (int i = 0; i < 256; i++)
        {
            string temp = "";
            if (i > 25)
            {
                int first = i / 26 - 1;
                temp += (char)(first + 'a');
            }
            

            int sec = i % 26;
            temp += (char)(sec + 'A');
            digits.Add(temp);
        }

        string result = "";

        if (n == 0)
        {
            Console.WriteLine("A");
        }

        while (n != 0)
        {
            result = (digits[(int)(n % 256)]) + result;
            n = n / 256;
        }        

        Console.WriteLine(result);
    }
}