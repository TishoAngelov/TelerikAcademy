using System;

class BinaryDigitsCount
{
    static void Main()
    {
        uint binaryDigit = uint.Parse(Console.ReadLine());
        uint countOfNums = uint.Parse(Console.ReadLine());
        uint[] numberValue = new uint[countOfNums];
        uint mask = 1;
        int digitCounter = 0;
        string binNum = "";

        for (int i = 0; i < countOfNums; i++)
        {
            numberValue[i] = uint.Parse(Console.ReadLine());
            binNum = Convert.ToString(numberValue[i], 2);
            digitCounter = 0;

            for (int j = 0; j < binNum.Length; j++)
            {
                mask = (uint)1 << j;

                if (binaryDigit == 0)
                {    
                    if ((numberValue[i] & mask) == 0)
                    {
                        digitCounter++;
                    }
                }

                if (binaryDigit == 1)
                {
                    if ((numberValue[i] & mask) != 0)
                    {
                        digitCounter++;
                    }
                }
            }
            Console.WriteLine(digitCounter);                
        }
    }
}
