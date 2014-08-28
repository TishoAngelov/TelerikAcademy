using System;
using System.Collections.Generic;

namespace StructurePoint
{
    // Optional test
    class PointTEST
    {
        private const string FilePath = "../../Points.txt";

        public static void Main()
        {
            // Create 2 points
            Console.WriteLine("Create first point");
            Point3D p1 = CreatePoint();

            Console.WriteLine("Create second point");
            Point3D p2 = CreatePoint();

            Console.WriteLine();

            // Calculate distance between them
            Console.WriteLine("The distance between the points {0} and {1} is: {2}",
                p1, p2, Math.Round(Calculate.Distance(p1, p2), 2));

            Console.WriteLine();

            // Create new path of points
            Path path = new Path();

            // Add points to the path
            path.AddPoint(p1);
            path.AddPoint(p2);

            // Save the path in file
            PathStorage.Save(path, FilePath);
            Console.WriteLine("The current path has been saved!");

            // Add another point to the path and save again
            Console.WriteLine("Enter third point");
            Point3D p3 = CreatePoint();

            path.AddPoint(p3);

            PathStorage.Save(path, FilePath);
            Console.WriteLine("The current path has been saved!");

            // Clear the path and print it
            Console.WriteLine("Clearing the path...");
            path.ClearPath();
            
            Console.WriteLine("Your path of points: ");
            foreach (var point in path.Points)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine("End of path.");
            Console.WriteLine();

            // Load all path from file and print them
            int pathCounter = 0;
            List<Path> loadAllPaths = PathStorage.Load(FilePath);

            Console.WriteLine("Loaded paths");
            foreach (var loadedPath in loadAllPaths)
            {
                pathCounter++;

                Console.WriteLine("========= Path {0} =========", pathCounter);
                foreach (var point in loadedPath.Points)
                {
                    Console.WriteLine(point);
                }
            }

            Console.WriteLine();
            Console.WriteLine("End of loaded paths.");
            Console.WriteLine();
        }

        private static Point3D CreatePoint()
        {
            Console.Write("Coordinate X = ");
            double X = double.Parse(Console.ReadLine());

            Console.Write("Coordinate Y = ");
            double Y = double.Parse(Console.ReadLine());

            Console.Write("Coordinate Z = ");
            double Z = double.Parse(Console.ReadLine());

            Console.WriteLine();

            return new Point3D(X, Y, Z);            
        }
    }
}