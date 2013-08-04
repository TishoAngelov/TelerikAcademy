using System;

class FindLargestAreaOfEqualElements
{
    /*
     7* Write a program that finds the largest area of equal neighbor elements
       in a rectangular matrix and prints its size.
          Example:
                        1  3  2  2  2  4
                        3  3  3  2  4  4
                        4  3  1  2  3  3        -> 13
                        4  3  1  3  3  1
                        4  3  3  3  1  1

       Hint: you can use the algorithm "Depth-first search" 
       or "Breadth-first search" (find them in Wikipedia).
    */

    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("You have entered the matrix\n");

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, -4}", matrix[row, col]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static bool IsTraversable(int[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
    }

    static int currentSum = 0;
    static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

    static void DFS(int[,] matrix, int row, int col)
    {
        int value = matrix[row, col];

        matrix[row, col] = 0;
        currentSum++;

        for (int direction = 0; direction < directions.GetLength(0); direction++)
        {
            int _row = row + directions[direction, 0];
            int _col = col + directions[direction, 1];

            if (IsTraversable(matrix, _row, _col) && matrix[_row, _col] == value) DFS(matrix, _row, _col);
        }
    }

    static void Main()
    {
        // test matrix
        int[,] matrix = { 
                        { 1, 3, 2, 2, 2, 4 },
                        { 3, 3, 3, 2, 4, 4 },
                        { 4, 3, 1, 2, 3, 3 },
                        { 4, 3, 1, 3, 3, 1 },
                        { 4, 3, 3, 3, 1, 1 }
                        };
        //////////////////////////////////////////

        PrintMatrix(matrix);

        int maxSum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] != 0)
                {
                    currentSum = 0;
                    DFS(matrix, row, col);

                    maxSum = Math.Max(currentSum, maxSum);
                }
            }
        }

        Console.WriteLine("Largest area of equal elements: " + maxSum);

        Console.WriteLine();
    }
}