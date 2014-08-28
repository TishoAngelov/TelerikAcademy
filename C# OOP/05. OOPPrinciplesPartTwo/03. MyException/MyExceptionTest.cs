using System;

namespace _03.MyException
{
    // Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
    // by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
    public class MyExceptionTest
    {
        static void Main()
        {
            // Test 1
            try
            {
                int minRange = 1;
                int maxRange = 100;

                int someIntValue = 100;

                if (!(minRange <= someIntValue && someIntValue <= maxRange))
                {
                    throw new InvalidRangeException<int>(minRange, maxRange);
                }

                Console.WriteLine("OK! Value = {0}", someIntValue);
            }
            catch (InvalidRangeException<int> intEx)
            {
                Console.WriteLine(intEx.Message);
            }

            Console.WriteLine();

            // Test 2
            try
            {
                int minRange = 1;
                int maxRange = 100;

                int someIntValue = -1;

                if (!(minRange <= someIntValue && someIntValue <= maxRange))
                {
                    throw new InvalidRangeException<int>(minRange, maxRange);
                }

                Console.WriteLine("OK!");
            }
            catch (InvalidRangeException<int> intEx)
            {
                Console.WriteLine(intEx.Message);
            }

            Console.WriteLine();

            // Test 3
            try
            {
                DateTime minRange = new DateTime(1980, 1, 1);
                DateTime maxRange = new DateTime(2013, 12, 31);

                DateTime someDate = new DateTime(2014, 12, 31);

                if (!(minRange <= someDate && someDate <= maxRange))
                {
                    throw new InvalidRangeException<DateTime>(minRange, maxRange);
                }

                Console.WriteLine("OK!");
            }
            catch (InvalidRangeException<DateTime> dtEx)
            {
                Console.WriteLine(dtEx.Message);
            }

            Console.WriteLine();
        }
    }
}