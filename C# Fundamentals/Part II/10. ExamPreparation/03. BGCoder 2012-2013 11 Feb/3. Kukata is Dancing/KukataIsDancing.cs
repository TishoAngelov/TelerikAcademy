using System;
// 19:45
class KukataIsDancing
{
    static void Main()
    {
        int movesCount = int.Parse(Console.ReadLine());
        string[] moves = new string[movesCount];

        for (int i = 0; i < movesCount; i++)
        {
            moves[i] = Console.ReadLine();
        }

        char[,] cube = new char[3, 3];

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                cube[row, col] = 'B';

                if (col == 1 && row == 1)
                {
                    cube[row, col] = 'G';
                }
                else if (col != 1 && row != 1)
                {
                    cube[row, col] = 'R';
                }
            }
        }

        //// print cube
        //for (int i = 0; i < 3; i++)
        //{
        //    for (int j = 0; j < 3; j++)
        //    {
        //        Console.Write(cube[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        int startRow = 0;
        int startCol = 0;

        int nextRow = 0;
        int nextCol = 0;
        

        for (int mc = 0; mc < movesCount; mc++)
        {
            startRow = 1;
            startCol = 1;

            nextRow = startRow - 1;
            nextCol = startCol;

            for (int mov = 0; mov < moves[mc].Length; mov++)
            {
                string currLine = moves[mc];

                switch (currLine[mov].ToString())
                {
                    case "L":
                        nextRow = startCol - 1;

                        if (nextRow < 0)
                        {
                            nextRow = 2;
                        }

                        if (startRow == 0)
                        {
                            nextCol = 2;
                        }
                        else if (startRow == 1)
                        {
                            nextCol = 1;
                        }
                        else if (startRow == 2)
                        {
                            nextCol = 0;
                        }

                        break;

                    case "R":
                        nextRow = startCol + 1;

                        if (nextRow >= 3)
                        {
                            nextRow = 0;
                        }

                        if (startRow == 0)
                        {
                            nextCol = 2;
                        }
                        else if (startRow == 1)
                        {
                            nextCol = 1;
                        }
                        else if (startRow == 2)
                        {
                            nextCol = 0;
                        }

                        break;

                    case "W":
                        startRow = nextRow;
                        startCol = nextCol;

                        nextRow--;
                        if (nextRow < 0)
                        {
                            nextRow = 2;
                        }
                        break;
                }
            }

            switch (cube[startRow, startCol].ToString())
            {
                case "R" :
                    Console.WriteLine("RED");
                    break;
                case "G" :
                    Console.WriteLine("GREEN");
                    break;
                case "B" :
                    Console.WriteLine("BLUE");
                    break;

            }
        }


        
    }
}