using System;

class Trails
{
    static void Main()
    {
        string[] winner = { "BLUE", "RED", "DRAW" };

        Random rnd = new Random();
        
        Console.WriteLine(winner[rnd.Next(0, 3)]);
        Console.WriteLine(rnd.Next(1, 11));
    }
}