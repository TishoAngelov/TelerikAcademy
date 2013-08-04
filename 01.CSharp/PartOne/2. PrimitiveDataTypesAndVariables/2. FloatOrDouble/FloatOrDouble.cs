using System;

class FloatOrDouble
{
    // Which of the following values can be assigned to a variable of type 
    // float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

    static void Main()
    {
        double firstNum = 34.567839023;
        float secondNum = 12.345F;
        double thirdNum = 8923.1234857;        
        float fourthNum = 3456.091F;

        Console.WriteLine("First number = {0} - double \nSecond number = {1} - float \nThird number = {2} - double"
           + "\nFourth number = {3} - float\n\n", firstNum, secondNum, thirdNum, fourthNum);
    }
}