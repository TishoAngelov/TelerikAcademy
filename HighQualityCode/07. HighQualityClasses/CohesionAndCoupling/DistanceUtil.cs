namespace CohesionAndCoupling
{
    using System;

    public static class DistanceUtil
    {
        public static double CalculateIn2DSystem(double x1, double y1, double x2, double y2)
        {
            double xd = x2 - x1;
            double yd = y2 - y1;
            double distance = Math.Sqrt(xd * xd + yd * yd);

            return distance;
        }

        public static double CalculateIn3DSystem(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double xd = x2 - x1;
            double yd = y2 - y1;
            double zd = z2 - z1;
            double distance = Math.Sqrt(xd * xd + yd * yd + zd * zd);

            return distance;
        }
    }
}
