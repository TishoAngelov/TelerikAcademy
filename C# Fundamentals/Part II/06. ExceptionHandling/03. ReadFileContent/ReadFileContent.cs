using System;
using System.IO;
using System.Security;

class ReadFileContent
{
    /*
        Write a program that enters file name along with its full file path 
        (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
        Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch
        all possible exceptions and print user-friendly error messages.
    */

    static void Main()
    {
        //Console.Write("Enter file path to read: ");
        //string filePath = Console.ReadLine();        

        string filePath = @"C:\WINDOWS\win.ini";        // example path        

        try
        {
            string readTextFromFile = File.ReadAllText(filePath);

            Console.WriteLine("Content of {0}", filePath);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(readTextFromFile);
        }

        catch (ArgumentNullException nullEx)
        {
            Console.WriteLine(nullEx.Message);
        }

        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }

        catch (PathTooLongException ptlEx)
        {
            Console.WriteLine(ptlEx.Message);
        }

        catch (DirectoryNotFoundException dirNF)
        {
            Console.WriteLine(dirNF.Message);
        }

        catch (FileNotFoundException fileNF)
        {
            Console.WriteLine(fileNF.Message);
        }

        catch (IOException IOEx)
        {
            Console.WriteLine(IOEx.Message);
        }

        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
        }

        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }

        catch (NotSupportedException notSuppEx)
        {
            Console.WriteLine(notSuppEx.Message);
        }

        Console.WriteLine();
    }
}