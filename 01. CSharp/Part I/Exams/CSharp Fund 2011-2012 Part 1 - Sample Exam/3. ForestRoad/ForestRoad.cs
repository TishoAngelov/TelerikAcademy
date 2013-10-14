using System;

class ForestRoad
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(new string('.',i - 1) + "*" + new string('.',N - i));
        }

        for (int i = N-1; i > 0; i--)
        {
            Console.WriteLine(new string('.', i - 1) + "*" + new string('.', N - i));
        }
    }
}