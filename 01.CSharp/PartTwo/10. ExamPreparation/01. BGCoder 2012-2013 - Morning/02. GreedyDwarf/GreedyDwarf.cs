using System;

class GreedyDwarf
{
    static void Main()
    {
        char[] separators = { ',', ' ' };

        string[] inputValley = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int[] valley = new int[inputValley.Length];

        for (int i = 0; i < inputValley.Length; i++)
        {
            valley[i] = int.Parse(inputValley[i]);
        }

        uint M = uint.Parse(Console.ReadLine());        
        
        long maxSum = long.MinValue;

        for (int row = 0; row < M; row++)
        {
            int[] tempValley = new int[valley.Length];
            bool[] isVisited = new bool[valley.Length];

            for (int i = 0; i < valley.Length; i++)
            {
                tempValley[i] = valley[i];
            }

            string[] strPatternLine = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int currIndex = 0;
            long tempSum = tempValley[currIndex];
            isVisited[currIndex] = true;

            for (int col = 0; col < strPatternLine.Length; col++)
            {                
                int nextIndex = int.Parse(strPatternLine[col]) + currIndex;

                if (((nextIndex < tempValley.Length) && (nextIndex >= 0)) 
                        && !isVisited[nextIndex])
                {
                    tempSum += tempValley[nextIndex];
                    isVisited[nextIndex] = true;
                    currIndex = nextIndex; 
                }
                else
                {
                    break;
                }

                if (col >= strPatternLine.Length - 1)
                {
                    col = -1;
                }        
            }

            if (maxSum <= tempSum)
            {
                maxSum = tempSum;
            }
        }

        Console.WriteLine(maxSum);
    }
}