using System;

class MaxSequenceOfEqualsElements
{
    // Write a program that finds the maximal sequence of equal elements in an array.
    // 	Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

    static void Main()
    {
        int[] intArray = new int[10];

        Console.WriteLine("Enter 10 integer members for the array:");

        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write("element [{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }

        // Find the max seq
        int maxSeq = 1;
        int tempMaxSeq = 1;

        for (int i = 0; i < intArray.Length - 1; i++)
        {
            if (intArray[i] == intArray[i + 1])
            {
                tempMaxSeq++;
            }
            else
            {
                tempMaxSeq = 1;
            }

            if (maxSeq <= tempMaxSeq)
            {
                maxSeq = tempMaxSeq;
            }
        }

        Console.WriteLine("Max sequence: " + maxSeq);

        // Find max equals
        string maxEqualSeq = "";
        int counter = 1;

        for (int i = 0; i < intArray.Length - 1; i++)
        {
            for (int j = 1; j < maxSeq; j++)
            {
                if (intArray[i] == intArray[i + 1])
                {
                    counter++;
                    i++;
                }
                else
                {
                    counter = 1;
                    break;
                }
            }

            if (counter == maxSeq)
            {
                for (int j = i - maxSeq + 1; j < i + 1; j++)
                {
                    maxEqualSeq += intArray[j] + ", ";
                }
            }
            counter = 1;
        }

        // Print the results
        Console.Write("{");
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write(intArray[i] + ", ");
        }
        Console.Write("} -> {" + maxEqualSeq + "}");

        Console.WriteLine();
    }
}