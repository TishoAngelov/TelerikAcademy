using System;

class NumbersArrangedAsSpiral
{
    // * Write a program that reads a positive integer number N (N < 20) from console
    // and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
    // 	Example for N = 4

    //  1   2   3   4
    //  12  13  14  5
    //  11  16  15  6
    //  10  9   8   7

    static void Main()
    {
        Console.Write("Enter 1 number (0 < N < 20): ");
        int N = int.Parse(Console.ReadLine());        

        int[,] matrix = new int[N, N];
        int column = 0;
        int row = 0;
        int filledColumns = 0;
        int filledRows = 0;
        int currNumber = 0;

        do
        {
            // Fill right

            for (; column < N - filledColumns / 2; column++)
            {               
                currNumber++;
                matrix[column, row] = currNumber;
            }
            filledRows++;
            column--;
            row++;            

            // Fill down

            for (; row < N - filledRows / 2; row++)
            {               
                currNumber++;
                matrix[column, row] = currNumber;
            }
            filledColumns++;
            column--;
            row--;

            // Fill left

            for (; column >= filledColumns / 2; column--)
            {
               
                currNumber++;
                matrix[column, row] = currNumber;
            }
            filledRows++;
            column++;
            row--;

            // Fill up

            for (; row >= filledRows / 2; row--)
            {                
                currNumber++;
                matrix[column, row] = currNumber;
            }            
            filledColumns++;
            column++;
            row++;

        } while (currNumber < N * N);

        // Print the arranged spiral matrix

        for (row = 0; row < N; row++)
        {
            Console.WriteLine();         
            
            for (column = 0; column < N; column++)
            {
                if (matrix[column, row] < 10)
                {
                    Console.Write(matrix[column, row] + "   ");
                }
                else if (matrix[column, row] < 100)
                {
                    Console.Write(matrix[column, row] + "  ");
                }
                else if (matrix[column, row] < 1000)
                {
                    Console.Write(matrix[column, row] + " ");
                }
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
        Console.WriteLine();
    }
}