using System;

class AnyNumSysToAnyNumSys
{
    // Write a program to convert from any numeral system of given
    // base s to any other numeral system of base d (2 ≤ s, d ≤  16).

    static int ConvertSBaseSysToDec(string inputNum, int fromSBaseSys)
    {
        // convert the number to decimal numeral system
        int decNum = 0;

        for (int i = inputNum.Length - 1; i >= 0; i--)
        {
            int currDigit = Convert.ToInt32(inputNum[inputNum.Length - i - 1]) - '0';

            if (currDigit <= 9)
            {
                decNum += currDigit * (int)Math.Pow(fromSBaseSys, i);
            }
            else
            {
                currDigit -= 7;
                decNum += currDigit * (int)Math.Pow(fromSBaseSys, i);
            }
        }

        return decNum;
    }

    static string ConvertDecToDBase(int decNum, int toDBaseSys)
    {
        //Convert to d base number
        string result = "";

        while (decNum > 0)
        {
            switch (decNum % toDBaseSys)
            {
                case 0: result += "0"; break;
                case 1: result += "1"; break;
                case 2: result += "2"; break;
                case 3: result += "3"; break;
                case 4: result += "4"; break;
                case 5: result += "5"; break;
                case 6: result += "6"; break;
                case 7: result += "7"; break;
                case 8: result += "8"; break;
                case 9: result += "9"; break;
                case 10: result += "A"; break;
                case 11: result += "B"; break;
                case 12: result += "C"; break;
                case 13: result += "D"; break;
                case 14: result += "E"; break;
                case 15: result += "F"; break;
            }

            decNum = decNum / toDBaseSys;
        }

        // reversing the number
        string tempResult = "";
        for (int i = result.Length - 1; i >= 0; i--)
        {
            tempResult += result[i];
        }
        result = tempResult;

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter numeral system you want to convert from (2 <= s <= 16)");
        Console.Write("s = ");
        int sBaseSys = int.Parse(Console.ReadLine());        

        Console.Write("Enter one ({0}) base number (positive): ", sBaseSys);
        string sBaseNum = Console.ReadLine().ToUpper();

        // check if the number is correct for defined numeral system
        for (int i = 0; i < sBaseNum.Length; i++)
        {
            int currDigit = sBaseNum[i] - '0';

            if (currDigit < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nPlease enter positive numbers only!\n");

                Console.ResetColor();

                return;
            }

            if (currDigit <= 9)
            {
                if (currDigit >= sBaseSys)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nIncorrect number for ({0}) numeral system!!!\n", sBaseSys);

                    Console.ResetColor();

                    return;
                }
            }
            else if(currDigit + '0'< 'A' || currDigit + '0' > 'F')
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nIncorrect number for ({0}) numeral system!!!\n", sBaseSys);

                Console.ResetColor();

                return;
            }
            else if (currDigit - 7 >= sBaseSys)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nIncorrect number for ({0}) numeral system!!!\n", sBaseSys);

                Console.ResetColor();

                return;
            }            
        }

        Console.WriteLine("\nEnter numeral system you want to convert to (2 <= d <= 16)");
        Console.Write("d = ");
        int dBaseSys = int.Parse(Console.ReadLine());

        int decNum = 0;
        string dBaseNum = "";

        // check if numeral systems are in correct range [2 - 16]
        if (sBaseSys < 2 || dBaseSys < 2 || sBaseSys > 16 || dBaseSys > 16)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("The numeral systems should be in the range [2 - 16]!!!\n");

            Console.ResetColor();

            return;
        }
        else
        {
            decNum = ConvertSBaseSysToDec(sBaseNum, sBaseSys);
            dBaseNum = ConvertDecToDBase(decNum, dBaseSys);
        }

        // printing the final result
        Console.WriteLine("\nAfter converting");
        Console.WriteLine(new string('=', 35));
        Console.WriteLine("{0}({1}) = {2}(10) = {3}({4})\n", sBaseNum, sBaseSys, decNum, dBaseNum, dBaseSys);
    }
}