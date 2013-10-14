using System;

class DeclareNumTypes
{
    /*
    Declare five variables choosing for each of them the most appropriate
    of the types byte, sbyte, short, ushort, int, uint, long, ulong to
    represent the following values: 52130, -115, 4825932, 97, -10000.
    */

    static void Main()
    {
        ushort firstNum = 52130;
        sbyte secondNum = -115;
        uint thirdNum = 4825932;
        byte fourthNum = 97;
        short fifthNum = -10000;

        Console.WriteLine("First number = {0} \nSecond number = {1} \nThird number = {2} \nFourth number = {3}"
            + "\nFifth number = {4}\n\n", firstNum, secondNum, thirdNum, fourthNum, fifthNum);
    }
}