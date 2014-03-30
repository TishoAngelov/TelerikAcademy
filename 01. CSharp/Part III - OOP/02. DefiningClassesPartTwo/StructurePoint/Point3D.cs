using System;

namespace StructurePoint
{
    public struct Point3D
    {
        // Fields
        private static readonly Point3D startOfCoordSystem = new Point3D(0, 0, 0);

        private double coordX;
        private double coordY;
        private double coordZ;
        
        // Properties
        public static Point3D StartOfCoordSystem
        {
            get { return startOfCoordSystem; }
        }       // Point 0

        public double CoordX
        {
            get { return this.coordX; }
            set { this.coordX = value; }
        }

        public double CoordY
        {
            get { return this.coordY; }
            set { this.coordY = value; }
        }

        public double CoordZ
        {
            get { return this.coordZ; }
            set { this.coordZ = value; }
        }

        // Constructors
        public Point3D(double coordX, double coordY, double coordZ)
            : this()
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.coordZ = coordZ;
        }

        // Methods
        public override string ToString()
        {
            string result = string.Format("Point[{0:0.00}; {1:0.00}; {2:0.00}]", 
                this.coordX, this.coordY, this.coordZ);

            return result;
        }
    }
}