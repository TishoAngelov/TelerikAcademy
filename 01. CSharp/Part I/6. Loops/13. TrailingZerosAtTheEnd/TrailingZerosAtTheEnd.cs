using System;

class TrailingZerosAtTheEnd
{
    // * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	// N = 10 -> N! = 3628800 -> 2
	// N = 20 -> N! = 2432902008176640000 -> 4
	// Does your program work for N = 50 000?
	// Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

    static void Main()
    {
        Console.Write("Enter 1 integer (N): ");
        int intN = int.Parse(Console.ReadLine());       
                
        int sumOfTrailingZeros = 0;

        for (int pow = 1; Math.Pow(5, pow) <= intN; pow++)
        {
            sumOfTrailingZeros += (int)(intN / Math.Pow(5, pow));
        }
       
        Console.WriteLine("{0}! has {1} trailing zeros at the end.", intN, sumOfTrailingZeros);
        Console.WriteLine();
    }
}