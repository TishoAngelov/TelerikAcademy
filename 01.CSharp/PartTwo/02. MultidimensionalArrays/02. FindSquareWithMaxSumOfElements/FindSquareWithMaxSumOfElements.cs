using System;

class FindSquareWithMaxSumOfElements
{
    // Write a program that reads a rectangular matrix of size N x M and 
    // finds in it the square 3 x 3 that has maximal sum of its elements.

    public static int FindMaxSumInTheSquare(int[,] anyMatrix, int someRows, int someColumns)
    {
        int maxSum = 0;
        int tempSum = 0;

        int k = 3;          // size of the square k x k
        int rowCounterToK = 0;

        int maxMovesByRow = someRows - (k - 1);
        int maxMovesByColumn = someColumns - (k - 1);

        int movesByRowCounter = 0;
        int movesByColumnCounter = 0;

        for (int row = movesByRowCounter; (row < someRows) &&           // search all rows
            (movesByRowCounter < maxMovesByRow); row++)                 // until max moves (k) for row aren't reached
        {
            int colCounterToK = 0;

            rowCounterToK++;

            for (int col = movesByColumnCounter; (col < someColumns) &&         // search all columns
                (movesByColumnCounter < maxMovesByColumn); col++)               // until max moves (k) for column aren't reached
            {
                colCounterToK++;

                tempSum += anyMatrix[row, col];         // add the value of curr element to temp sum

                if (colCounterToK >= k)    
                {
                    colCounterToK = 0;                  // set the counter back to 0 when k columns are searched
                    col = movesByColumnCounter - 1;

                    if (rowCounterToK >= k)
                    {
                        rowCounterToK = 1;
                        row -= k - 1;

                        movesByColumnCounter++;
                        col = movesByColumnCounter - 1;

                        if (maxSum <= tempSum)
                        {
                            maxSum = tempSum;
                        }

                        tempSum = 0;      // setting temp sum to 0 because all elements of the square are searched already
                    }
                    else                  // increase row index and counter by 1 if k rows aren't reached
                    {
                        rowCounterToK++;
                        row++;
                    }                   
                }      
            }

            movesByRowCounter++;
            movesByColumnCounter = 0;
            rowCounterToK = 0;
        }

        return maxSum;
    }

    public static void PrintAllSquaresWithMaxSum(int[,] anyMatrix, int someRows, int someColumns)
    {
        int maxSum = FindMaxSumInTheSquare(anyMatrix, someRows, someColumns);
        int tempSum = 0;

        int k = 3;
        int rowCounterToK = 0;

        int maxMovesByRow = someRows - (k - 1);
        int maxMovesByColumn = someColumns - (k - 1);

        int movesByRowCounter = 0;
        int movesByColumnCounter = 0;

        for (int row = movesByRowCounter; (row < someRows) && 
            (movesByRowCounter < maxMovesByRow); row++)
        {
            int colCounterToK = 0;
            int[,] tempMatrix = new int[someRows, someColumns];

            // set all elements of the temp matrix to int.MinValue (i need it because of the colour printing later)
            for (int i = 0; i < someRows; i++)
            {
                for (int j = 0; j < someColumns; j++)
                {
                    tempMatrix[i, j] = int.MinValue;
                }
            }
            ///////////////////////////////////////////////////////////////////////////////

            tempSum = 0;
            rowCounterToK++;

            for (int col = movesByColumnCounter; (col < someColumns) && (movesByColumnCounter < maxMovesByColumn); col++)
            {
                colCounterToK++;
                tempSum += anyMatrix[row, col];
                tempMatrix[row, col] = anyMatrix[row, col];

                if (colCounterToK >= k)
                {
                    colCounterToK = 0;
                    col = movesByColumnCounter - 1;

                    if (rowCounterToK >= k)
                    {
                        rowCounterToK = 1;
                        movesByColumnCounter++;
                        col = movesByColumnCounter - 1;
                        row -= k - 1;

                        if (maxSum == tempSum)
                        {
                            for (int rowK = 0; rowK < someRows; rowK++)
                            {
                                for (int colK = 0; colK < someColumns; colK++)
                                {
                                    if (tempMatrix[rowK, colK] == int.MinValue)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;

                                        Console.Write(anyMatrix[rowK, colK].ToString().PadRight(3));
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;

                                        Console.Write(tempMatrix[rowK, colK].ToString().PadRight(3));                                        
                                    }
                                }
                                Console.WriteLine("\n");
                            }

                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Max sum: " + maxSum);
                            Console.WriteLine(new string('=', 40) + "\n");

                            Console.ResetColor();
                        }

                        tempSum = 0;

                        // set all elements of the temp matrix to int.MinValue (i need it because of the colour printing)
                        for (int i = 0; i < someRows; i++)
                        {
                            for (int j = 0; j < someColumns; j++)
                            {
                                tempMatrix[i, j] = int.MinValue;
                            }
                        }
                        ////////////////////////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        rowCounterToK++;
                        row++;
                    }
                }
            }

            movesByRowCounter++;
            movesByColumnCounter = 0;
            rowCounterToK = 0;
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Enter size of the matrix[N(rows),M(columns)]");
        Console.WriteLine("Condition: N and M should be greater than 3!!!");

        Console.Write("N = ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("M = ");
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];

        // fill  the matrix
        Console.WriteLine("\nEnter elements of the matrix:");

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("element[{0},{1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        //////////////////////////////////////////////////////////////////

        // print whole matrix
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("You have entered the matrix");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("{0, -3}", matrix[row, col]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("\n");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("Square matrix (can be more than 1) k x k with max sum");
        Console.WriteLine(new string('=', 60));
        
        Console.WriteLine();

        Console.ResetColor();
        ///////////////////////////////////////////////////////////////////////////

        PrintAllSquaresWithMaxSum(matrix, rows, columns);

        Console.WriteLine();
    }
}