using System;

class MultipleTasks
{
    /*
        Write a program that can solve these tasks:
            - Reverses the digits of a number
            - Calculates the average of a sequence of integers
            - Solves a linear equation a * x + b = 0
	    Create appropriate methods.
	    Provide a simple text-based menu for the user to choose which task to solve.
	    Validate the input data:
            - The decimal number should be non-negative
            - The sequence should not be empty
            - a should not be equal to 0
    */
    static bool IsArrayEmpty(int[] anyArray)
    {
        bool isEmpty = false;
        int sum = 0;

        for (int i = 0; i < anyArray.Length; i++)
	    {
			 sum += anyArray[i];
		}

        if (sum == 0)
        {
            isEmpty = true;

            Console.WriteLine("\nThe array should not be empty!\n");
        }

        return isEmpty;
    }

    static void ReverseNumber()
    {
        Console.Write("\nEnter one number: ");
        int num = int.Parse(Console.ReadLine());

        string minus = "";

        if (num < 0)
        {
            num = Math.Abs(num);

            minus = "-";
        }

        string reversedNum = minus;

        for (int i = num.ToString().Length - 1; i >= 0; i--)
        {
            reversedNum += num.ToString()[i];
        }

        Console.WriteLine("The number is reversed! - {0}", Convert.ToInt32(reversedNum));
    }

    static void CalcAverage()
    {
        int arrSize = 0;

        while (true)
        {
            Console.Write("\nEnter size of array: ");
            arrSize = int.Parse(Console.ReadLine());

            if (arrSize <= 0)
            {
                Console.WriteLine("\nThe array can't have negative or zero size!\n");
            }
            else
            {                
                break;
            }
        }

        int[] intArr = new int[arrSize];
        int sum = 0;        

        do
        {            
            Console.WriteLine("\nEnter values for the elements of the array\n");
            for (int i = 0; i < arrSize; i++)
            {
                Console.Write("element[{0}] = ", i);
                intArr[i] = int.Parse(Console.ReadLine());

                sum += intArr[i];
            }
        } while (IsArrayEmpty(intArr));

        decimal avg = (decimal)sum / arrSize;

        Console.WriteLine("\nAverage: {0}\n", avg);
    }

    static void SolveLinearEquation()
    {
        Console.WriteLine("\nLinear equation: a * x + b = 0");

        int a = 0;

        do
        {
            Console.WriteLine("\na should be different from 0!\n");
            Console.Write("a = ");
            a = int.Parse(Console.ReadLine());
        } while (a == 0);

        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());

        decimal x = (decimal)-b / a;

        Console.WriteLine("\nx = {0}\n", x);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 27) + " MENU " + new string('=', 27));
            Console.WriteLine("1. Reverse digits of a number.");
            Console.WriteLine("2. Calculate the average of a sequence of integers.");
            Console.WriteLine("3. Solve a linear equation a * x + b = 0.");
            Console.WriteLine("4. Exit");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();

            Console.Write("Your choice: ");
            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    ReverseNumber();
                    break;

                case 2:
                    CalcAverage();
                    break;

                case 3:
                    SolveLinearEquation();
                    break;

                case 4:
                    Console.WriteLine("\nGoodbye!!!\n");
                    return;

                default:
                    Console.WriteLine("Incorrect choice!");
                    break;                    
            }

            Console.WriteLine();
        }
    }
}