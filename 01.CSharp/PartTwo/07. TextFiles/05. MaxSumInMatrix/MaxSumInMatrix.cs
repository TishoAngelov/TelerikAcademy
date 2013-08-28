using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class MaxSumInMatrix
{
    /*
        Write a program that reads a text file containing a square matrix of numbers
        and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
        The first line in the input file contains the size of matrix N. Each of the next
        N lines contain N numbers separated by space. The output should be a single number
        in a separate text file. 
            Example:
                4
                2 3 3 4
                0 2 3 4		->	17
                3 7 1 2
                4 3 3 2
    */

    public static int[,] GetMatrixFromFileAndPrintIt(string path)
    {
        int matrixSize = 0;
        int[,] matrix;

        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            matrixSize = Convert.ToInt32(reader.ReadLine());

            Console.WriteLine("Matrix size {0} x {0}.\n", matrixSize);
            Console.WriteLine("Matrix look like this");
            Console.WriteLine(new string('=', 40));

            // initialize, fill and print the matrix
            string[] singleLineArr = reader.ReadLine().Split(' ');

            matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = Convert.ToInt32(singleLineArr[col]);
                    Console.Write(matrix[row, col] + " ");
                }

                string tempLine = reader.ReadLine();    // needed because we can't split the string if it has null value

                if (tempLine == null)
                {
                    break;
                }
                else
                {
                    singleLineArr = tempLine.Split(' ');
                    Console.WriteLine();
                }
            }
        }

        return matrix;
    }

    // Finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
    public static int FindMaxSumInMatrix(int[,] matrix)
    {
        int maxSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currSum = matrix[row, col] + matrix[row, col + 1]                   // Get the sum of a matrix 2 x 2
                                + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }
        }

        return maxSum;
    }

    public static void SaveResultInFile(string path, int result)
    {
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            writer.Write(result);
        }

        Console.WriteLine("\n\nCalculations finished! Maximal sum found and saved!\n");
    }

    public static void OpenResultFile(string path)
    {
        Thread.Sleep(2000);
        Console.WriteLine("The file with the result will be opened for you after 3 seconds!\n");

        Console.WriteLine("==================== 3 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 2 ====================\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("==================== 1 ====================\n\n");
        Console.Beep();
        Thread.Sleep(1000);

        Console.WriteLine("Goodbye. :)\n");
        Console.Beep(); Console.Beep(); Console.Beep();

        Process.Start(path);        
    }

    static void Main()
    {
        string inputFilePath = "../../input.txt";
        int[,] getMatrix = GetMatrixFromFileAndPrintIt(inputFilePath);

        int maxSum = FindMaxSumInMatrix(getMatrix);

        string resultFilePath = "result.txt";
        SaveResultInFile(resultFilePath, maxSum);

        OpenResultFile(resultFilePath);
    }
}