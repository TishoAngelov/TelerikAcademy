using System;
using System.Text.RegularExpressions;

class ParseURL
{
    /*
        Write a program that parses an URL address given in the format:
            [protocol]://[server]/[resource]
        and extracts from it the [protocol], [server] and [resource] elements. For example 
        from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		    [protocol] = "http"
		    [server] = "www.devbg.org"
		    [resource] = "/forum/index.php"
    */

    static string ParseTheURL(string url)
    {
        string protocol = Regex.Match(url, @"\A\w*", RegexOptions.IgnoreCase).ToString();
        string server = Regex.Match(url, @"//\S*?/", RegexOptions.IgnoreCase).ToString().Trim('/');
        string resource = Regex.Match(url, @"\w/\S*", RegexOptions.IgnoreCase).ToString();
        resource = resource.Trim(resource[0]);      // Removes the first character

        string result = string.Empty;
        result += "[protocol] = " + protocol;
        result += "\n[server] = " + server;
        result += "\n[resource] = " + resource;

        return result;
    }

    static void Main()
    {
        string givenURL1 = @"http://www.devbg.org/forum/index.php";
        Console.WriteLine("Given URL: {0}\n", givenURL1);
        Console.WriteLine(ParseTheURL(givenURL1));

        Console.WriteLine();
        Console.WriteLine();

        string givenURL2 = @"http://www.youtube.com/watch?v=QPVHU3bv2w8";
        Console.WriteLine("Given URL: {0}\n", givenURL2);
        Console.WriteLine(ParseTheURL(givenURL2));

        Console.WriteLine();
    }
}