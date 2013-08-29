using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

class SortListOfStrings
{
    /*
        Write a program that reads a text file containing a list of
        strings, sorts them and saves them to another text file. 
            Example:
	            Ivan			George
	            Peter	  -> 	Ivan
	            Maria			Maria
	            George			Peter
    */

    public static void OpenResultFile(string path)
    {
        Thread.Sleep(2000);
        Console.WriteLine("The file with the result will be opened for you after 3 seconds!\n");

        Console.WriteLine("==================== 3 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 2 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 1 ====================\n\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("Goodbye. :)\n");
        Console.Beep(); Console.Beep(); Console.Beep();

        Process.Start(path);
    }

    static void Main()
    {
        List<string> words = new List<string>();
        string beforeSortPath = "beforeSort.txt";

        StreamReader beforeSortFileReader = new StreamReader(beforeSortPath);
        using (beforeSortFileReader)
        {
            string singleLine = beforeSortFileReader.ReadLine();

            while (singleLine != null)
            {
                words.Add(singleLine);
                singleLine = beforeSortFileReader.ReadLine();
            }
        }

        words.Sort();

        string afterSortPath = "afterSort.txt";
        StreamWriter afterSortFileWriter = new StreamWriter(afterSortPath);
        using (afterSortFileWriter)
        {
            for (int i = 0; i < words.Count; i++)
            {
                afterSortFileWriter.WriteLine(words[i]);
            }
        }

        Console.WriteLine("Sorting finished!\n");

        OpenResultFile(afterSortPath);
    }
}