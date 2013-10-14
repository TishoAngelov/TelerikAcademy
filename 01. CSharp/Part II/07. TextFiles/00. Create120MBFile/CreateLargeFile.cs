using System;
using System.IO;

public class CreateLargeFile
{
    // Creating 120 MB file. It's needed for tasks 07 and 08.

    public static void CreateTheLargeFile(string path)
    {
        DateTime start = DateTime.Now;

        Console.WriteLine("Creating large file...");

        StreamWriter poorPoorWriter = new StreamWriter(path);       
        using (poorPoorWriter)
        {
            for (int i = 1; i <= 1398102; i++)
            {
                poorPoorWriter.WriteLine("startstart start aastartaaaaa start. dont ,start! blablastart startffffffff cant start");
            }            
        }

        DateTime finish = DateTime.Now;

        Console.WriteLine("Time elapsed: {0}", finish - start);
        Console.WriteLine("Done!");
        Console.WriteLine();
    }

    public static void Main()
    {

    }
}