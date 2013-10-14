using System;

class LongestSeqOfEqualStringsInMatrix
{
    /*
    We are given a matrix of strings of size N x M. Sequences in the matrix we define 
    as sets of several neighbor elements located on the same line, column or diagonal.
    Write a program that finds the longest sequence of equal strings in the matrix.
     * Example:
     * ha fifi ho hi                        s  qq s
     * fo  ha  hi xx  -> ha, ha, ha         pp pp s   -> s, s, s
     * xxx ho  ha xx                        pp qq s
    */

    public static void PrintMatrix(string[,] anyMatrix, int someRows, int someColumns)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("\nYou have entered the matrix");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;

        for (int row = 0; row < someRows; row++)
        {
            for (int col = 0; col < someColumns; col++)
            {
                Console.Write("{0, -4}", anyMatrix[row, col]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(new string('=', 40));

        Console.ResetColor();
    }

    static void Main()
    {
        Console.WriteLine("Enter size of the matrix[N(rows),M(columns)]");

        Console.Write("N = ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("M = ");
        int cols = int.Parse(Console.ReadLine());

        //test matrix (you should remove the manual entering first)
        //string[,] matrix = {{"s", "s", "s", "ad"},
        //                    {"s", "s", "j", "s"},
        //                    {"s", "a", "d", "a"},
        //                    {"a", "d", "a", "s"},
        //                    {"c", "da", "s", "s"},
        //                    {"a", "b", "d", "s"} 
        //                   };
        //
        //int rows = 6;
        //int cols = 4;

        // fill  the matrix
        Console.WriteLine("\nEnter string elements of the matrix:");
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("element[{0},{1}] = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }
        //////////////////////////////////////////////////////////////////

        

        PrintMatrix(matrix, rows, cols);

        int elementRepeats = 1;
        int maxElementRepeats = 1;

        string currElement = "";
        string nextElement = "";
        string maxEqualElement = "";


        // search by column
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row + 1, col];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (vertically) - at column " + col;
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (vertically) - at column " + col;
                }
            }

            elementRepeats = 1;            
        }
        //////////////////////

        // search by row
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row, col + 1];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (horizontal) - at row " + row;
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (horizontal) - at row " + row;
                }
            }

            elementRepeats = 1;
        }
        /////////////////////////////////
        int startRow = 0;

        // search under the main diagonal (including)
        for (int row = 0; row < rows - 1; row++)
        {
            startRow = row;

            for (int col = 0; (col < cols - 1) && (row < rows - 1); row++, col++)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row + 1, col + 1];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (diagonal) - starting from row " + 
                                                                (row - 1) + " and column " + (col - 1);
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (diagonal) - starting from row " + 
                                                                (row - 1) + " and column " + (col - 1);
                }
            }

            row = startRow;

            elementRepeats = 1;
        }
        ////////////////////////////////////////////////////////

        // search over the main diagonal (not including)
        for (int row = 0; row < rows - 1; row++)
        {
            startRow = row;

            for (int col = 1; (col < cols - 1) && (row < rows - 1); row++, col++)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row + 1, col + 1];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (diagonal) - starting from row " + 
                                                                                  (row - 1) + " and column " + (col - 1);
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (diagonal) - starting from row " + 
                                                                                  (row - 1) + " and column " + (col - 1);
                }
            }

            row = startRow;

            elementRepeats = 1;
        }
        ////////////////////////////////////////////////////////

        // search under the secondary diagonal (including)
        for (int row = 0; row < rows - 1; row++)
        {
            startRow = row;

            for (int col = cols - 1; (col > 0) && (row < rows - 1); row++, col--)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row + 1, col - 1];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (diagonal) - starting from row " + 
                                                                                (row + 1) + " and column " + (col - 1);
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (diagonal) - starting from row " + 
                                                                                (row + 1) + " and column " + (col - 1);
                }
            }

            row = startRow;

            elementRepeats = 1;
        }
        ////////////////////////////////////////////////////////

        // search over the secondary diagonal (not including)
        for (int row = 0; row < rows - 1; row++)
        {
            startRow = row;

            for (int col = cols - 2; (col > 0) && (row < rows - 1); row++, col--)
            {
                currElement = matrix[row, col];
                nextElement = matrix[row + 1, col - 1];

                if (!currElement.Equals(nextElement))
                {
                    currElement = nextElement;
                    elementRepeats = 1;
                }
                else
                {
                    elementRepeats++;
                }

                if (elementRepeats > maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement = currElement + " - (diagonal) - starting from row " +
                                                                                  (row + 1) + " and column " + (col - 1);
                }
                else if (elementRepeats == maxElementRepeats)
                {
                    maxElementRepeats = elementRepeats;
                    maxEqualElement += "\n" + currElement + " - (diagonal) - starting from row " +
                                                                                  (row + 1) + " and column " + (col - 1);
                }
            }

            row = startRow;

            elementRepeats = 1;
        }
        ////////////////////////////////////////////////////////

        Console.WriteLine("\nLongest sequance of equal strings");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(maxEqualElement);

        Console.WriteLine(new string('=', 60));
        Console.WriteLine("Repeat " + maxElementRepeats + " times.");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine();
    }
}