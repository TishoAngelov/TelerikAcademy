using System;

class SpecialValue
{
    static int rows;
    static int path = 0;
    static string[][] weirdMatrix;
    static long currSpecSum = 0;
    static long maxSpecialSum = long.MinValue;    

    static long FindCurrSpecialSum(int currRow, int currCol)
    {
        int currNum = int.Parse(weirdMatrix[currRow][currCol]);
        path++;

        if (currNum < 0)
        {
            currSpecSum = path + Math.Abs(currNum);
            path = 0;

            return currSpecSum;
        }
        else
        {
            currRow = ((currRow + 1) == rows) ? 0 : currRow + 1;
            currCol = currNum;

            FindCurrSpecialSum(currRow, currCol);
        }

        return currSpecSum;
    }

    static void Main()
    {
        string[] separators = { ",", " " };

        rows = int.Parse(Console.ReadLine());
        weirdMatrix = new string[rows][];

        // Fill the matrix
        for (int i = 0; i < rows; i++)
        {
            weirdMatrix[i] = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        // Find max special sum
        for (int col = 0; col < weirdMatrix[0].Length; col++)
        {
            long currSpecialSum = FindCurrSpecialSum(0, col);
            maxSpecialSum = Math.Max(maxSpecialSum, currSpecialSum);
        }

        Console.WriteLine(maxSpecialSum);
    }
}