using System;
using System.IO;
using System.Net;

class DownloadAndStoreFile
{
    /*
        Write a program that downloads a file from Internet (e.g. 
        http://www.devbg.org/img/Logo-BASD.jpg) and stores it the 
        current directory. Find in Google how to download files in C#. 
        Be sure to catch all exceptions and to free any used resources 
        in the finally block.
    */

    static void Main()
    {
        WebClient webClient = new WebClient();
        string downloadAddres = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string storePathAndFileName = @"downloadedFile.jpg";

        try
        {
            webClient.DownloadFile(downloadAddres, storePathAndFileName);

            Console.WriteLine("Download completed!");
            Console.WriteLine("The file is saved in: {0}", Path.GetFullPath(storePathAndFileName));
        }

        catch (WebException webEx)
        {
            Console.WriteLine("Invalid addres! {0}", webEx.Message);

            if (webEx.Status == WebExceptionStatus.ConnectFailure)
            {
                Console.WriteLine("Are you behind a firewall?  If so, go through the proxy server.");
            }
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            webClient.Dispose();        // release all resources used by webClient

            Console.WriteLine();
        }        
    }
}