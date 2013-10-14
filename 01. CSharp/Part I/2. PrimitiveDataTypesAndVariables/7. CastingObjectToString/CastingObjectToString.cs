using System;

class CastingObjectToString
{
    /*
    Declare two string variables and assign them with “Hello” and “World”.
    Declare an object variable and assign it with the concatenation of the
    first two variables (mind adding an interval). Declare a third string
    variable and initialize it with the value of the object variable (you should perform type casting).
    */

    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object firstTwoStrings = firstString + " " + secondString;
        string thirdString = (string)firstTwoStrings;

        Console.WriteLine("The first word is: {0}", firstString);
        Console.WriteLine("The second word is: {0}", secondString);
        Console.WriteLine("If we concatenate them we have: {0}", firstTwoStrings);
        Console.WriteLine("Casted object type to string: {0}\n\n", thirdString);
    }
}

