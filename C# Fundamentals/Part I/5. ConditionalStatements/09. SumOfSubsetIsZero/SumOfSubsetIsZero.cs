using System;

class SumOfSubsetIsZero
{
    // We are given 5 integer numbers. Write a program that checks if
    // the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

    static void Main()
    {
        int[] intNumber = new int[5];
        string subset = "";
        int lineCounter = 0;
        char [] signOfNumber = new char[5];
        int sumHoleSubset = 0;

        Console.WriteLine("Enter five numbers:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("{0}: ", i + 1);
            intNumber[i] = int.Parse(Console.ReadLine());
            subset += intNumber[i] + " ";

            sumHoleSubset += intNumber[i];

            if (intNumber[i] < 0)
            {
                signOfNumber[i] = '-';
            }
            else
            {
                signOfNumber[i] = '+';
            }
        }
        Console.WriteLine("Subset: {0}", subset);
        Console.WriteLine();

        int sumOfSubset = 0;
        string resultZeroSubsets = "";
        int countOfZeroSubsets = 0;
        string currentSubsetSum = "";

        for (int i = 0; i < 5; i++)
        {
            // Check the sum of 1 number with 1 number
            for (int j = i + 1; j < 5; j++)
            {                               
                sumOfSubset = intNumber[i];
                sumOfSubset += intNumber[j];
                lineCounter++;
                
                currentSubsetSum = lineCounter + ".  " +
                    intNumber[i] + " " +
                    signOfNumber[j] + " " + Math.Abs(intNumber[j]) + " = " +
                    sumOfSubset; 
                Console.WriteLine(currentSubsetSum);

                if (sumOfSubset == 0)
                {
                    countOfZeroSubsets++;
                    resultZeroSubsets += "At line " + currentSubsetSum + Environment.NewLine;
                }
            }

            
            for (int j = i + 1; j <= 5; j++)
            {
                // Check the sum of 1 number with 2 numbers
                for (int k = j+1; k < 5; k++)
                {
                    sumOfSubset = intNumber[i];
                    sumOfSubset += intNumber[j] + intNumber[k];            
                    lineCounter++;
               
                    currentSubsetSum = lineCounter + ".  " +
                        intNumber[i] + " " +
                        signOfNumber[j] + " " + Math.Abs(intNumber[j]) + " " +
                        signOfNumber[k] + " " + Math.Abs(intNumber[k]) + " = " +
                        sumOfSubset;
                    Console.WriteLine(currentSubsetSum);

                    if (sumOfSubset == 0)
                    {
                        countOfZeroSubsets++;
                        resultZeroSubsets += "At line " + currentSubsetSum + Environment.NewLine;
                    }

                    // Check the sum of 1 number with 3 numbers
                    for (int n = k + 1; n < 5; n++)
                    {
                        sumOfSubset = intNumber[i];
                        sumOfSubset += intNumber[j] + intNumber[k] + intNumber[n];
                        lineCounter++;

                        currentSubsetSum = lineCounter + ".  " +
                            intNumber[i] + " " +
                            signOfNumber[j] + " " + Math.Abs(intNumber[j]) + " " +
                            signOfNumber[k] + " " + Math.Abs(intNumber[k]) + " " +
                            signOfNumber[n] + " " + Math.Abs(intNumber[n]) + " = " +
                            sumOfSubset;
                        Console.WriteLine(currentSubsetSum);

                        if (sumOfSubset == 0)
                        {
                            countOfZeroSubsets++;
                            resultZeroSubsets += "At line " + currentSubsetSum + Environment.NewLine;
                        }
                    }
                    // End check with 3

                }
                // End check with 2

            }
        }

        lineCounter++;    
        currentSubsetSum = lineCounter + ".  " +
                            intNumber[0] + " " +
                            signOfNumber[1] + " " + Math.Abs(intNumber[1]) + " " +
                            signOfNumber[2] + " " + Math.Abs(intNumber[2]) + " " +
                            signOfNumber[3] + " " + Math.Abs(intNumber[3]) + " " +
                            signOfNumber[4] + " " + Math.Abs(intNumber[4]) + " = " +
                            sumHoleSubset;
        Console.WriteLine(currentSubsetSum);

        if (sumOfSubset == 0)
        {
            countOfZeroSubsets++;
            resultZeroSubsets += "At line " + currentSubsetSum + Environment.NewLine;
        }

        Console.WriteLine("{0}---------------------------------------------", Environment.NewLine);
        Console.WriteLine("There are {0} subsets with sum of 0! {1}", countOfZeroSubsets, Environment.NewLine);
        Console.WriteLine(resultZeroSubsets);
        Console.WriteLine();
    }
}