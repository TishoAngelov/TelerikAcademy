using System;

class IsAPointWithinACircle
{
    // Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

    static void Main()
    {
        string pointName = "";
        float pointCoordinateX = 0f;
        float pointCoordinateY = 0f;
        float pointRadius = 0f;
        string circleName = "K";
        float circleCoordinateX = 0f;
        float circleCoordinateY = 5f;
        float circleRadius = (float)Math.Sqrt((circleCoordinateX * circleCoordinateX) + (circleCoordinateY * circleCoordinateY));
        bool isWithinACircle = false;

        Console.Write("Please enter a name for your point: ");
        pointName = Console.ReadLine();

        Console.WriteLine("Your coordinates can be with floating point!\n");
        Console.Write("Please enter the x coordinates of point {0}: ", pointName);
        pointCoordinateX = float.Parse(Console.ReadLine());

        Console.Write("Please enter the y coordinates of point {0}: ", pointName);
        pointCoordinateY = float.Parse(Console.ReadLine());

        pointRadius = (float)Math.Sqrt((pointCoordinateX * pointCoordinateX) + (pointCoordinateY * pointCoordinateY));
        isWithinACircle = pointRadius <= circleRadius ? true : false;

        Console.WriteLine("Is your point {0}({1}; {2})" +
            " within the circle {3}({4}; {5}) ??? -> {6}", pointName, pointCoordinateX, 
            pointCoordinateY, circleName, circleCoordinateX, circleCoordinateY, isWithinACircle);
        Console.WriteLine();
    }
}

