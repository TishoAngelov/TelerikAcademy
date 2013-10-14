using System;

class CalcSumFromString
{
    /*
        You are given a sequence of positive integer values written into a string, separated
        by spaces. Write a function that reads these values from given string and calculates their sum. 
            Example:
		    string = "43 68 9 23 318" -> result = 461
    */

    static void Main()
    {
        string givenString = "43 68 9 23 318";
        Console.WriteLine("Given string: {0}", givenString);

        string[] splitArr = givenString.Split(' ');
        int sum = 0;

        for (int i = 0; i < splitArr.Length; i++)
        {
            sum += Convert.ToInt32(splitArr[i]);
        }

        Console.WriteLine("Sum = {0}", sum);

        Console.WriteLine();
    }
}