using System;
using System.Collections.Generic;
using System.IO;

namespace StructurePoint
{
    public static class PathStorage
    {
        // Fields
        private const string NewPathTitle = "---------- Path ----------";

        // Methods
        public static void Save(Path pathOfPoints, string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath, true);     // True - appends the new path to the old one
            using (writer)
            {
                writer.WriteLine(NewPathTitle);         // Separator for new path

                foreach (var point in pathOfPoints.Points)
                {
                    writer.WriteLine(point);
                }

                writer.WriteLine();
            }
        }

        public static List<Path> Load(string filePath)
        {
            List<Path> loadedPaths = new List<Path>();
            string singleLine = string.Empty;

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                singleLine = reader.ReadLine();
                while (singleLine != null)
                {
                    if (singleLine == "")        // Empty line
                    {
                        singleLine = reader.ReadLine();     // Read next line
                    }

                    else if (singleLine.StartsWith("-"))
                    {
                        singleLine = reader.ReadLine();

                        Path currPath = new Path();

                        while (singleLine != "")
                        {
                            singleLine = singleLine.Replace("Point[", string.Empty);
                            singleLine = singleLine.Replace("]", string.Empty);

                            string[] singleLineArray = singleLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            double[] coordinates = new double[singleLineArray.Length];

                            for (int coord = 0; coord < coordinates.Length; coord++)
                            {
                                coordinates[coord] = double.Parse(singleLineArray[coord]);
                            }

                            currPath.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));

                            singleLine = reader.ReadLine();
                        }

                        loadedPaths.Add(currPath);
                    }

                    singleLine = reader.ReadLine();
                }
            }

            return loadedPaths;
        }
    }
}