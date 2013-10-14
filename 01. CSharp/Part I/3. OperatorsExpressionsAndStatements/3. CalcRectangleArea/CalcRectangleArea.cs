using System;

class CalcRectangleArea
{
    // Write an expression that calculates rectangle’s area by given width and height.

    static void Main()
    {
        int rectWidth = 0;
        int rectHeight = 0;
        int rectArea = 0;

        Console.WriteLine("Please enter width and height to calculate area of rectangle:");
        Console.Write("Width = ");
        rectWidth = int.Parse(Console.ReadLine());
        Console.Write("Height = ");
        rectHeight = int.Parse(Console.ReadLine());
        rectArea = rectWidth * rectHeight;
        Console.WriteLine("Rectangle area = {0}\n\n", rectArea);

        // draw the rectangle
        Console.WriteLine("Now I will draw it for you!\n");
        Console.WriteLine(" " + new string('_', rectWidth * 2));
        for (int i = 0; i < rectHeight; i++)
        {
            if (i != rectHeight - 1)
            {
                Console.WriteLine("|" + new string(' ', rectWidth * 2) + "|");
            }
            else
            {
                Console.WriteLine("|" + new string('_', rectWidth * 2) + "|\n\n");
            }
        }
    }
}