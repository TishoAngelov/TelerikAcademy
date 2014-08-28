namespace CohesionAndCoupling
{
    using System;

    public static class GeometryFigureUtil
    {
        public static double CalculateVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }

        public static double CalculateDiagonalIn3DSystem(double width, double height, double depth)
        {
            double distance = DistanceUtil.CalculateIn3DSystem(0, 0, 0, width, height, depth);

            return distance;
        }

        public static double CalculateDiagonalIn2DSystem(double firstSideWidth, double secondSideWidth)
        {
            double distance = DistanceUtil.CalculateIn2DSystem(0, 0, firstSideWidth, secondSideWidth);

            return distance;
        }        
    }
}
