using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetExtension("example"));
            Console.WriteLine(FileUtils.GetExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceUtil.CalculateIn2DSystem(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceUtil.CalculateIn3DSystem(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;

            Console.WriteLine("Volume = {0:f2}", GeometryFigureUtil.CalculateVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", GeometryFigureUtil.CalculateDiagonalIn3DSystem(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", GeometryFigureUtil.CalculateDiagonalIn2DSystem(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", GeometryFigureUtil.CalculateDiagonalIn2DSystem(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", GeometryFigureUtil.CalculateDiagonalIn2DSystem(height, depth));
        }
    }
}
