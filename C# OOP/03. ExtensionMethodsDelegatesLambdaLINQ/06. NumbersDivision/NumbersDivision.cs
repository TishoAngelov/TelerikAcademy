using System;
using System.Linq;

namespace _06.NumbersDivision
{
    // Write a program that prints from given array of integers all numbers that 
    // are divisible by 7 and 3. Use the built-in extension methods and lambda 
    // expressions. Rewrite the same with LINQ.
    class NumbersDivision
    {
        static void Main()
        {
            int[] givenArr = { 3, 6, 1, 7, 3, 21, 49, 25, 9, 42 };

            Console.WriteLine("Given array");
            foreach (var num in givenArr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Lambda expr
            var divisibleNums = givenArr.Where(num => num % 3 == 0 ||
                                                        num % 7 == 0);

            Console.WriteLine("Numbers divisible by 3 and 7 (not simultaneously)");
            Console.WriteLine("I. Using lambda expressions");
            foreach (var num in divisibleNums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // LINQ
            divisibleNums =
                from num in givenArr
                where num % 3 == 0 || num % 7 == 0
                select num;
                
            Console.WriteLine("II. Using LINQ");
            foreach (var num in divisibleNums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine();
        }
    }
}