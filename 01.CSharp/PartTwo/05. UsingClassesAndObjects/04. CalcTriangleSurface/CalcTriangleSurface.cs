using System;

class CalcTriangleSurface
{
    /*
        Write methods that calculate the surface of a triangle by given:
            - Side and an altitude to it
            - Three sides
            - Two sides and an angle between them. 
        * Use System.Math.
    */

    static double TriangleSurface(double side, double altitude) 
    {
        return side * altitude / 2;
    }

    static double TriangleSurface(double side1, double side2, double side3)
    {
        double p = (side1 + side2 + side3) / 2;     // half perimeter (P)

        return Math.Sqrt((p - side1) * (p - side2) * (p - side3));
    }

    static double TriangleSurface(double side1, double side2, decimal angleBetween)
    {
        return side1 * side2 * Math.Sin((double)angleBetween);
    }

    static void PrintMenu()
    {
        Console.WriteLine("Calculate surface of a triangle by given:");
        Console.WriteLine(new string('=', 45));
        Console.WriteLine("1. Side and an altitude to it.");
        Console.WriteLine("2. Three sides.");
        Console.WriteLine("3. Two sides and an angle between them.");
        Console.WriteLine("0. Exit.");
        Console.WriteLine(new string('=', 45));
        Console.WriteLine();
    }

    static void Main()
    {
        int userChoice = 0;

        do
        {
            PrintMenu();

            Console.Write("Your choice: ");
            userChoice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("\nPlease enter only positive numbers for sides!\n");

            double triangleSurface = 0;

            switch (userChoice)
            {
                case 1:
                    Console.Write("Side = ");
                    double side = double.Parse(Console.ReadLine());

                    Console.Write("Altitude to the side = ");
                    double altitude = double.Parse(Console.ReadLine());

                    triangleSurface = TriangleSurface(side, altitude);

                    break;
                case 2:
                    Console.Write("First side= ");
                    double firstSide = double.Parse(Console.ReadLine());

                    Console.Write("Second side = ");
                    double secondSide = double.Parse(Console.ReadLine());

                    Console.Write("Third side = ");
                    double thirdSide = double.Parse(Console.ReadLine());

                    triangleSurface = TriangleSurface(firstSide, secondSide, thirdSide);

                    break;
                case 3:
                    Console.Write("First side= ");
                    double side1 = double.Parse(Console.ReadLine());

                    Console.Write("Second side = ");
                    double side2 = double.Parse(Console.ReadLine());

                    Console.Write("Angle (degrees) between them = ");
                    decimal angle = decimal.Parse(Console.ReadLine());

                    angle = angle * (decimal)Math.PI / 180;     // convert the radians to degrees

                    triangleSurface = TriangleSurface(side1, side2, angle);

                    break;
                case 0:
                    Console.WriteLine("Goodbye!\n");
                    return;
                default:
                    Console.WriteLine("\nIncorrect choice!\n");
                    break;
            }

            Console.WriteLine("\nTriangle surface = {0}\n", Math.Round(triangleSurface, 2));
        } while (userChoice != 0);

        Console.WriteLine();
    }
}