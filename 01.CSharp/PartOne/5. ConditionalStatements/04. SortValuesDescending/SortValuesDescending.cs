using System;

class SortValuesDescending
{
    // Sort 3 real values in descending order using nested if statements.

    static void Main()
    {
        Console.Write("Enter first number: ");
        float firstNum = float.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        float secondNum = float.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        float thirdNum = float.Parse(Console.ReadLine());

        
        float min, mid, max = 0f;
        if (firstNum > secondNum)
        {
            if (firstNum < thirdNum)
            {
                max = thirdNum;
                mid = firstNum;
                min = secondNum;
            }
            else
            {
                if (secondNum > thirdNum)
                {
                    max = firstNum;
                    mid = secondNum;
                    min = thirdNum;
                }
                else
                {
                    max = firstNum;
                    mid = thirdNum;
                    min = secondNum;
                }
            }
        }
        else
        {
            if (secondNum < thirdNum)
            {
                max = thirdNum;
                mid = secondNum;
                min = firstNum;
            }
            else
            {
                if (firstNum > thirdNum)
	            {
                    max = secondNum;
                    mid = firstNum;
                    min = thirdNum;
	            }
                else
                {
                    max = secondNum;
                    mid = thirdNum;
                    min = firstNum;
                }                
            }
        }
        Console.WriteLine("{0} >= {1} >= {2}", max, mid, min);
        Console.WriteLine();
    }
}