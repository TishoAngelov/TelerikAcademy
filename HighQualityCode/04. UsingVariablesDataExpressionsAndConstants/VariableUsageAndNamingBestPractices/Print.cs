namespace VariableUsageAndNamingBestPractices
{
    using System;

    public static class Print
    {
        public static void Statistics(double[] elements)
        {
            Console.WriteLine("Minimal element is {0}.", Min(elements));
            Console.WriteLine("Maximal element is {0}.", Max(elements));
            Console.WriteLine("Average is {0}.", Average(elements));
        }

        private static double Max(double[] elements)
        {
            double max = double.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        private static double Min(double[] elements)
        {
            double min = double.MaxValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] < min)
                {
                    min = elements[i];
                }
            }

            return min;
        }

        private static double Average(double[] elements)
        {
            double currSum = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                currSum += elements[i];
            }

            double average = currSum / elements.Length;

            return average;
        }
    }
}
