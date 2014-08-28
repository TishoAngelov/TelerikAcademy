using System;

class PointIsWithinFigures
{
    // Write an expression that checks for given point (x, y) if it is WITHIN the
    // circle K( (1,1), 3) and OUT of the rectangle R(top=1, left=-1, width=6, height=2).

    static void Main()
    {
        // Point coordinates
        float pointCoordinateX = 0f;
        float pointCoordinateY = 0f;
        float pointRadius = 0f;

        // Circle coordinates
        float circleCoordinateX = 1.1f;
        float circleCoordinateY = 3f;
        float circleRadius = (float)Math.Sqrt((circleCoordinateX * circleCoordinateX) + (circleCoordinateY * circleCoordinateY));

        // Rectangle coordinates
        float rectXLeft = -1f;
        float rectXRight = 5f;
        float rectWidth = rectXRight - rectXLeft;
        float rectHeight = 2f;
        float rectYTop = 1f;
        float rectYBottom = rectYTop - rectHeight;

        // Conditions
        bool isWithinACircle = false;
        bool isOutOfRectangle = false;

        Console.WriteLine("Your coordinates can be with floating point!\n");
        Console.Write("Please enter the x coordinates of a point: ");
        pointCoordinateX = float.Parse(Console.ReadLine());
        Console.Write("Please enter the y coordinates of a point: ");
        pointCoordinateY = float.Parse(Console.ReadLine());
        pointRadius = (float)Math.Sqrt((pointCoordinateX * pointCoordinateX) + (pointCoordinateY * pointCoordinateY));
        isWithinACircle = pointRadius <= circleRadius ? true : false;        
        isOutOfRectangle = (pointCoordinateX < rectXLeft) || (pointCoordinateX > rectXRight) || (pointCoordinateY > rectYTop) || (pointCoordinateY < rectYBottom) ? true : false;        
        if (isWithinACircle && isOutOfRectangle)
        {
            Console.WriteLine("Is your point ({0}; {1}) withing the cricle K({2}; {3}) AND out of the rectangle\n" +
                "R(top = {4}; left = {5}; width = {6}; height = {7}) -> True.", pointCoordinateX, pointCoordinateY, circleCoordinateX,
                circleCoordinateY, rectYTop, rectXLeft, rectWidth, rectHeight);
        }
        else
        {
            Console.WriteLine("Is your point ({0}; {1}) withing the cricle K({2}; {3}) AND out of the rectangle\n" +
                "R(top = {4}; left = {5}; width = {6}; height = {7}) -> False.", pointCoordinateX, pointCoordinateY, circleCoordinateX,
                circleCoordinateY, rectYTop, rectXLeft, rectWidth, rectHeight);
        }        
        Console.WriteLine("Is withing a circle? -> {0}.", isWithinACircle);
        Console.WriteLine("Is out of rectangle? -> {0}.", isOutOfRectangle);
        Console.WriteLine();
    }
}

