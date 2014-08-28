namespace RefactorLoop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int expectedValue = 7;
            int divider = 10;
            int[] elements = new int[12];
            bool isExpectedValueFound = false;

            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine(elements[i]);

                bool isCurrentIndexDivisibleWithoutRemainder = (i % divider) == 0;
                if (isCurrentIndexDivisibleWithoutRemainder)
                {
                    isExpectedValueFound = elements[i] == expectedValue;

                    if (isExpectedValueFound)
                    {
                        Console.WriteLine("Value Found");

                        break;
                    }                    
                }
            }
        }
    }
}
