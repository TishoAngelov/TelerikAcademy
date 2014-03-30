using System;
using System.Collections.Generic;

namespace StructurePoint
{
    public class Path
    {
        // Fields
        private readonly List<Point3D> points = new List<Point3D>();

        // Properties
        public List<Point3D> Points
        {
            get { return this.points; }
        }

        // Constructors
        public Path()
        {
        }

        // Methods
        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public void ClearPath()
        {
            this.points.Clear();
        }              
    }
}

/* Second solution

    public class Path
    {
        // Fields
        private List<Point3D> points;

        // Properties
        public List<Point3D> Points
        {
            get { return this.points; }
        }
        
        // Constructors
        public Path(int pointsCount)
        {
            points = new List<Point3D>(pointsCount);

            Console.WriteLine("Enter {0} points.", pointsCount);
            for (int i = 0; i < pointsCount; i++)
            {
                Console.Write("Enter X: ");
                int coordX = int.Parse(Console.ReadLine());

                Console.Write("Enter Y: ");
                int coordY = int.Parse(Console.ReadLine());

                Console.Write("Enter Z: ");
                int coordZ = int.Parse(Console.ReadLine());

                points.Add(new Point3D(coordX, coordY, coordZ));
            }
        }
 
        // Methods
        public void ClearPath()
        {
            this.points.Clear();
        }
    }
*/