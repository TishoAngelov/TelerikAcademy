using System;

class FillMatrixAsShown
{
    /*
        Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

            a)  1 5 9  13        b) 1 8 9  16
                2 6 10 14           2 7 10 15
                3 7 11 15           3 6 11 14
                4 8 12 16           4 5 12 13
    
            c)  7 11 14 16      d)* 1 12 11 10
                4 8  12 15          2 13 16 9
                2 5  9  13          3 14 15 8
                1 3  6  10          4 5  6  7
    */

    // WORKS ONLY FOR N = 4!!!

    public static int currNum = 0;
    public static int n = 4;
    public static int[,] matrix = new int[n,n];

    public static void PrintMatrix()
    {
        currNum = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, -4}", matrix[row, col]);                
            }

            Console.WriteLine();
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void FillMatrixA()
    {        
        // Fill matrix
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
			{
			    currNum++;

                matrix[row, col] = currNum;
			}
        }

        PrintMatrix();
    }

    public static void FillMatrixB()
    {
        // Fill matrix
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    currNum++;

                    matrix[row, col] = currNum;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    currNum++;

                    matrix[row, col] = currNum;
                }
            }            
        }

        PrintMatrix();
    }

    public static void FillMatrixC()
    {
        // fill under the main diagonal
        int startRow = 0;

        for (int row = n - 1; row >= 0; row--)
        {
            startRow = row;

            for (int col = 0; col < n - startRow; col++)
            {                
                matrix[row++, col] = ++currNum;
            }

            row = startRow;
        }

        // fill over the main diagonal
        int startCol = 0;

        for (int col = 1; col < n; col++)
        {
            startCol = col;

            for (int row = 0; row < n - startCol; row++)
            {
                matrix[row, col++] = ++currNum;
            }

            col = startCol;
        }

        PrintMatrix();
    }

    public static void FillMatrixD()
    {
        // Fill matrix
        
        int row = 0;
        int col = 0;
        int filledRows = 0;
        int filledCols = 0;

        do
       {
            // fill down
            do
            {
                matrix[row++, col] = ++currNum;
            } while (row < n - filledRows / 2);
            filledCols++;            
            row--;

            // fill right
            do
            {
                matrix[row, ++col] = ++currNum;
            } while (col < n - filledCols);
            filledRows++;

            // fill up
            do
            {
                matrix[--row, col] = ++currNum;
            } while (row >= 0 + filledRows);
            filledCols++;

            // fill left
            do
            {
                if (currNum >= 16)
                {
                    break;
                }
                matrix[row, --col] = ++currNum;
            } while (col >= 0 + filledCols);
            filledRows++;
            currNum--;
        } while (currNum < 15);
        
        PrintMatrix();
    }
    
    static void Main()
    {        
        byte userChoise = 0;
        
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("MENU");
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("\tChoose 1 for matrix a).");
            Console.WriteLine("\tChoose 2 for matrix b).");
            Console.WriteLine("\tChoose 3 for matrix c).");
            Console.WriteLine("\tChoose 4 for matrix d).");
            Console.WriteLine("\tChoose 5 for Exit.");
            Console.WriteLine(new string('=', 40));

            Console.ResetColor();

            Console.Write("\nEnter your choise: ");
            userChoise = byte.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (userChoise)
            {
                case 1:
                    FillMatrixA();
                    break;
                case 2:
                    FillMatrixB();
                    break;
                case 3:
                    FillMatrixC();
                    break;
                case 4:
                    FillMatrixD();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("\nIncorrect choise!\n");
                    break;
            }
        } while (userChoise != 5);

        Console.WriteLine("\nGoodbye!");
        Console.WriteLine();
    }
}