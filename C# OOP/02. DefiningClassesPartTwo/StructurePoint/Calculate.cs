using System;

namespace StructurePoint
{
    public static class Calculate
    {
        public static double Distance(Point3D p1, Point3D p2)
        {
            double xd = p2.CoordX - p1.CoordX;
            double yd = p2.CoordY - p1.CoordY;
            double zd = p2.CoordZ - p1.CoordZ;

            return Math.Sqrt(xd * xd + yd * yd + zd * zd);
        }
    }
}