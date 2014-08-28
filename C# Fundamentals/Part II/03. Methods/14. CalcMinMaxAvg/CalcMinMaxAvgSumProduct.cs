using System;

class CalcMinMaxAvgSumProduct
{
    // Write methods to calculate minimum, maximum, average, sum and product of
    // given set of integer numbers. Use variable number of arguments.

    static void Minimum(int[] anyArray)
    {
        int minElement = anyArray[0];

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] < minElement)
            {
                minElement = anyArray[i];
            }
        }

        Console.WriteLine("Minimal element in the sequence: {0}.\n", minElement);
    }

    static void Maximum(int[] anyArray)
    {
        int maxElement = anyArray[0];

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] > maxElement)
            {
                maxElement = anyArray[i];
            }
        }

        Console.WriteLine("Maximal element in the sequence: {0}.\n", maxElement);
    }

    static void Average(int[] anyArray)
    {
        double sum = 0;
        double average = 0;

        for (int i = 0; i < anyArray.Length; i++)
        {
            sum += anyArray[i];
        }

        average = sum / anyArray.Length;

        Console.WriteLine("Average of the equance: {0}.\n", average);
    }

    static void Sum(int[] anyArray)
    {
        int sum = 0;

        for (int i = 0; i < anyArray.Length; i++)
        {
            sum = sum + anyArray[i];
        }

        Console.WriteLine("Sum of the sequance: {0}.\n", sum);
    }

    static void Product(int[] anyArray)
    {
        int product = 1;

        for (int i = 0; i < anyArray.Length; i++)
        {
            product = product * anyArray[i];
        }

        Console.WriteLine("Product of the sequence: {0}.\n", product);
    }

    static void Main()
    {
        Console.Write("Enter size of the sequance: ");
        int arrSize = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int[] intArr = new int[arrSize];

        for (int i = 0; i < intArr.Length; i++)
        {
            Console.Write("element[{0}] = ", i);
            intArr[i] = int.Parse(Console.ReadLine());
        }

        Minimum(intArr);

        Maximum(intArr);

        Average(intArr);

        Sum(intArr);

        Product(intArr);

        Console.WriteLine();
    }
}

