namespace MinesGame
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            const int MaxMines = 35;

            string currCommand = string.Empty;
            char[,] mineField = Mines.CreatePlayground();
            char[,] mines = Mines.PlaceMines();
            int minesCount = 0;
            bool isGameOver = false;
            List<Points> rankings = new List<Points>(6);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            bool isWinner = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play \"Mines\". Try your luck to find the fields without a mine." +
                    " Command 'top' shows the rankings, 'restart' starts a new game, 'exit' exits the game!");
                    Mines.PrintPlayground(mineField);

                    isNewGame = false;
                }

                Console.Write("Enter row and column: ");
                currCommand = Console.ReadLine().Trim();

                if (currCommand.Length >= 3)
                {
                    if (int.TryParse(currCommand[0].ToString(), out row) &&
                        int.TryParse(currCommand[2].ToString(), out col) &&
                        row <= mineField.GetLength(0) &&
                        col <= mineField.GetLength(1))
                    {
                        currCommand = "turn";
                    }
                }

                switch (currCommand)
                {
                    case "top":
                        Mines.Ranking(rankings);
                        break;
                    case "restart":
                        mineField = Mines.CreatePlayground();
                        mines = Mines.PlaceMines();
                        Mines.PrintPlayground(mineField);
                        isGameOver = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                Mines.NextTurn(mineField, mines, row, col);
                                minesCount++;
                            }

                            if (MaxMines == minesCount)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                Mines.PrintPlayground(mineField);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (isGameOver)
                {
                    Mines.PrintPlayground(mines);

                    Console.Write(
                        "\nArgh! You have died! You have {0} points. " +
                        "Enter your nickname: ", 
                        minesCount);
                    string nickname = Console.ReadLine();

                    Points currPoints = new Points(nickname, minesCount);

                    if (rankings.Count < 5)
                    {
                        rankings.Add(currPoints);
                    }
                    else
                    {
                        for (int i = 0; i < rankings.Count; i++)
                        {
                            if (rankings[i].PlayerPoints < currPoints.PlayerPoints)
                            {
                                rankings.Insert(i, currPoints);
                                rankings.RemoveAt(rankings.Count - 1);
                                break;
                            }
                        }
                    }

                    rankings.Sort((Points p1, Points p2) => p2.Name.CompareTo(p1.Name));
                    rankings.Sort((Points p1, Points p2) => p2.PlayerPoints.CompareTo(p1.PlayerPoints));
                    Mines.Ranking(rankings);

                    mineField = Mines.CreatePlayground();
                    mines = Mines.PlaceMines();
                    minesCount = 0;
                    isGameOver = false;
                    isNewGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nCongratulations! You have opened 35 boxes. You won!");
                    Mines.PrintPlayground(mines);

                    Console.WriteLine("Please enter your name: ");
                    string name = Console.ReadLine();

                    Points points = new Points(name, minesCount);
                    rankings.Add(points);

                    Mines.Ranking(rankings);
                    mineField = Mines.CreatePlayground();
                    mines = Mines.PlaceMines();
                    minesCount = 0;
                    isWinner = false;
                    isNewGame = true;
                }
            }
            while (currCommand != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }
    }
}
