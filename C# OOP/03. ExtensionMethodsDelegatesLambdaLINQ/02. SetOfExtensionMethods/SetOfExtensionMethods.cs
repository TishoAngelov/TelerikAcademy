using System;
using System.Collections.Generic;

namespace _02.SetOfExtensionMethods
{
    // Implement a set of extension methods for IEnumerable<T> that
    // implement the following group functions: sum, product, min, max, average.
    public static class SetOfExtensionMethods
    {
        public static T Sum<T>(this IEnumerable<T> enums) where T : IComparable
        {
            dynamic sum = 0;

            foreach (var num in enums)
            {
                sum += num;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> enums) where T : IComparable
        {
            dynamic product = 1;

            foreach (var num in enums)
            {
                product *= num;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> enums) where T : IComparable
        {
            dynamic min = decimal.MaxValue;

            foreach (var num in enums)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> enums) where T : IComparable
        {
            dynamic max = decimal.MinValue;

            foreach (var num in enums)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> enums) where T : IComparable
        {
            dynamic average = 0;
            dynamic sum = 0;
            int counter = 0;

            foreach (var num in enums)
            {
                counter++;
                sum += num;                
            }

            average = sum / counter;

            return average;
        }

        static void Main()
        {
            int[] givenArr = { 1, 2, 3, 4, 5 };     // Sum = 15, Prod = 120, 

            Console.WriteLine("Given array");
            foreach (var num in givenArr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            dynamic sum = givenArr.Sum();
            dynamic product = givenArr.Product();
            dynamic min = givenArr.Min();
            dynamic max = givenArr.Max();
            dynamic average = givenArr.Average();

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Average = " + average);

            Console.WriteLine();
        }
    }
}