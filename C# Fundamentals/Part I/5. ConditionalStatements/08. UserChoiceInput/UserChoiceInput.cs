using System;

class UserChoiceInput
{
    // Write a program that, depending on the user's choice inputs int, double or string variable.
    // If the variable is integer or double, increases it with 1. If the variable is string, appends
    // "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

    static void Main()
    {
        Console.Write("Please choose a variable type (int, double or string) {0}that you want to define: ", Environment.NewLine);
        string selectedVariable = Console.ReadLine();

        switch (selectedVariable)
        {
            case "int" :
                Console.Write("Enter a number: ");
                int intNum = int.Parse(Console.ReadLine());
                intNum++;
                Console.WriteLine("The number is increased with 1: {0}", intNum);
                break;
            case "double" :
                Console.Write("Enter a number with floating point: ");
                double doubleNum = double.Parse(Console.ReadLine());
                doubleNum++;
                Console.WriteLine("The number is increased with 1: {0}", doubleNum);
                break;
            case "string" :
                Console.Write("Enter any text: ");
                string someString = Console.ReadLine();
                someString += "*";
                Console.WriteLine("\"*\" is added at the end of your text:");
                Console.WriteLine(someString);
                break;
            default:
                Console.WriteLine("You have entered unknown variable type!");
                break;
        }
        Console.WriteLine();
    }
}
