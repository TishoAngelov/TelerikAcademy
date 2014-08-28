namespace MinesGame
{
    using System;
    using System.Collections.Generic;

    public static class Mines
    {
        public static void Ranking(List<Points> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} boxes",
                        i + 1, 
                        points[i].Name, 
                        points[i].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranklist!\n");
            }
        }

        public static void NextTurn(char[,] field, char[,] mines, int row, int col)
        {
            char minesCount = CountMines(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
        }

        public static void PrintPlayground(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardCols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public static char[,] CreatePlayground()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        public static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playground = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playground[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random rnd = new Random();
                int currMinePosition = rnd.Next(50);

                if (!mines.Contains(currMinePosition))
                {
                    mines.Add(currMinePosition);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playground[col, row - 1] = '*';
            }

            return playground;
        }

        public static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesCount = CountMines(field, i, j);
                        field[i, j] = minesCount;
                    }
                }
            }
        }

        private static char CountMines(char[,] field, int row, int col)
        {
            int minesCount = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
