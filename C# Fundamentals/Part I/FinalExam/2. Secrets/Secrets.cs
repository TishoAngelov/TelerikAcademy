using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
       
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger specialSum = 0;
        BigInteger tempNum = N;

        byte [] asd = N.ToByteArray();
        int len = N.ToString().Length;
        
        string []alphabet = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

       
        for (int i = 1; i <= N.ToString().Length; i++)
        {
            len = N.ToString().Length;
            tempNum = N;

            if (i == 1)
            {               
                tempNum = BigInteger.Remainder(tempNum, 10);                    
            
                do
                {
                    tempNum = BigInteger.Divide(N, BigInteger.Pow(10, (i - 1)));
                    len--;
                    if (len == 1)
                    {
                        break; 
                    }
                } while (len != 2);

                if (len == 2)
                {
                    tempNum = BigInteger.Remainder(tempNum, 10);
                }
            }

            if ((i % 2) == 0)
            {
                specialSum += BigInteger.Multiply(BigInteger.Pow(tempNum, 2), i);
            }
            else
            {
                specialSum += BigInteger.Multiply(tempNum, BigInteger.Pow(i, 2));
            }
            
            
        }        

        int lastDigit = (int)(BigInteger.Remainder(specialSum, 10));       
        
        // divide by letters in alphabet

        BigInteger R = BigInteger.Remainder(specialSum, 26);
        int sumR = (int)R + 1;
        int br = 1;

        // secret alpha

        string secretAlpha = "";
        
        for (int i = 1; i <= lastDigit; i++)
        {
            if (i == 1)
            {
                secretAlpha += alphabet[sumR];
            }
            else
            {
                if (br + sumR >= 27)
                {
                    br = 0;
                    sumR = 1;
                }

                secretAlpha += alphabet[sumR + br];
                
                br++;
            }
            
        }

        Console.WriteLine(specialSum);

        if (secretAlpha.Equals(""))
        {
            Console.WriteLine("{0} has no secret alpha-sequence", N);
        }
        else
        {
            Console.WriteLine(secretAlpha);
        }

    }
}