using System;

class MissCat2011
{
    static void Main()
    {
        uint juryNum = uint.Parse(Console.ReadLine());
        uint [] catNum = new uint[11];
        int choice = 0;
        int catWin = 0;

        for (int i = 1; i <= juryNum; i++)
        {
            choice = int.Parse(Console.ReadLine());
            catNum[choice]++;
        }

        catWin = 10;

        for (int i = 10; i > 0; i--)
        {
            if (catNum[catWin] <= catNum[i - 1])
            {
                catWin = i - 1;                
            }
        }
        Console.WriteLine(catWin);

    }
}
