using System;
using System.Numerics;
using System.Text;
// 17:40
class NineGagNumbers
{
    static BigInteger sum = 0;

    static void Main()
    {
        string input = Console.ReadLine();
        string result = string.Empty;

        int umn = 0;

        string currDigit = string.Empty;
        //Console.WriteLine("\n sled tva");

        for (int i = 0; i < input.Length; i++)
        {

            currDigit += input[i].ToString();
            
            switch (currDigit.ToString())
            {
                case "-!": // 0
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "**": // 1
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "!!!": // 2
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;                    

                case "&&": // 3
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "&-": // 4
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "!-": // 5
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "*!!!": // 6
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "&*!": // 7
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;

                case "!!**!-": // 8
                    result += currDigit + "a";
                    currDigit = string.Empty;
                    break;
                default:
                    break;
            }
        }

        string[] separated = result.Split(new string[]{ "a" }, StringSplitOptions.RemoveEmptyEntries);

        umn = separated.Length - 1;

        for (int i = 0; i < separated.Length; i++)
        {
            //Console.WriteLine(separated[i]);

            switch (separated[i])
            {
                case "-!": // 0
                    umn--;
                    break;

                case "**": // 1
                    sum += 1 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "!!!": // 2
                    sum += 2 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "&&": // 3
                    sum += 3 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "&-": // 4
                    sum += 4 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "!-": // 5
                    sum += 5 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "*!!!": // 6
                    sum += 6 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "&*!": // 7
                    sum += 7 * BigInteger.Pow(9, umn);
                    umn--;
                    break;

                case "!!**!-": // 8
                    sum += 8 * BigInteger.Pow(9, umn);
                    umn--;
                    break;
            }
        }

        Console.WriteLine(sum);
    }
}