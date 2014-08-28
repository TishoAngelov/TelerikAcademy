using System;

class ExtendEx14ForAllTypes
{
    //  * Modify your last program and try to make it work for any number
    //  type, not just integer (e.g. decimal, float, byte, etc.). 
    //  Use generic method (read in Internet about generic methods in C#).

    static T Minimum<T>(params T[] anyArray)
    {
        dynamic minElement = anyArray[0];

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] < minElement)
            {
                minElement = anyArray[i];
            }
        }

        return minElement;
    }

    static T Maximum<T>(params T[] anyArray)
    {
        dynamic maxElement = anyArray[0];

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] > maxElement)
            {
                maxElement = anyArray[i];
            }
        }

        return maxElement;
    }

    static T Average<T>(params T[] anyArray)
    {
        dynamic sum = 0;
        dynamic average = 0;

        for (int i = 0; i < anyArray.Length; i++)
        {
            sum += anyArray[i];
        }

        average = sum / anyArray.Length;

        return average;
    }

    static T Sum<T>(params T[] anyArray)
    {
        dynamic sum = 0;

        for (int i = 0; i < anyArray.Length; i++)
        {
            sum = sum + anyArray[i];
        }

        return sum;
    }

    static T Product<T>(params T[] anyArray)
    {
        dynamic product = 1;

        for (int i = 0; i < anyArray.Length; i++)
        {
            product = product * anyArray[i];
        }

        return product;
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

        Console.WriteLine("\nMinimal element in the sequence: {0}.", Minimum(intArr));

        Console.WriteLine("\nMaximal element in the sequence: {0}.", Maximum(intArr));

        Console.WriteLine("\nAverage of your sequence: {0}.", Average(intArr));

        Console.WriteLine("\nSum of the sequence: {0}.", Sum(intArr));

        Console.WriteLine("\nProduct of the sequence: {0}.", Product(intArr));

        Console.WriteLine();
    }
}
