using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        decimal X = decimal.Parse(Console.ReadLine());
        decimal Y = decimal.Parse(Console.ReadLine());
        int output = 0;

        if (X == 0 && Y == 0)
        {
            output = 0;
        }

        else if (X > 0 && Y > 0)
        {
            output = 1;
        }

        else if (X < 0 && Y > 0)
        {
            output = 2;
        }

        else if (X < 0 && Y < 0)
        {
            output = 3;
        }

        else if (X > 0 && Y < 0)
        {
            output = 4;
        }

        else if (X == 0 && Y != 0)
        {
            output = 5;
        }

        else if (X != 0 && Y == 0)
        {
            output = 6;
        }

        Console.WriteLine(output);
    }
}
