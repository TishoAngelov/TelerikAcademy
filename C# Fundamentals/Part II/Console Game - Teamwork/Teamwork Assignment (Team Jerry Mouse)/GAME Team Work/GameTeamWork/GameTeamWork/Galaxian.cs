using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

public class Galaxian
{
    private static int playGroundWidth;
    private static int playGroundHeight;
    private static int topBarHight;

    private static int spaceShipPosition;

    private static List<int> fleetPositionX = new List<int>();
    private static List<int> fleetPositionY = new List<int>();

    private static List<int> fleetShotsX = new List<int>();
    private static List<int> fleetShotsY = new List<int>();
    private static char[,] fleet;

    private static List<int> shipShotsX = new List<int>();
    private static List<int> shipShotsY = new List<int>();

    private static int shotPerSec;
    private static int shipShotSpeed;

    private static bool shipFiring;
    private static bool spacebarLocked;
    private static int move;

    private static int indexCol;
    private static int indexRow;
    private static int direction;

    private static int shipsPerColumn;
    private static int shipsPerRow;
    private static int fleetShotDensity;

    private static int maxShipsX;
    private static int maxShipsY;
    private static Random generator = new Random();

    private static int score;
    private static int scorePerShip;

    private static int lives;

    public static void Main()
    {
        InitialSettings();
        Menu();
        GenerateFleet(shipsPerRow, shipsPerColumn);
        GenerateShipShots();
        GameEngine();
    }

    private static void InitialSettings()
    {
        Console.Title = "Galaxian - Console game";
        Console.CursorVisible = false;
        Console.OutputEncoding = Encoding.Unicode;

        Console.SetWindowSize(100, 29);

        playGroundWidth = Console.WindowWidth - 2;
        playGroundHeight = Console.WindowHeight - 1;

        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;

        topBarHight = 2;
        scorePerShip = 10;

        spaceShipPosition = (playGroundWidth / 2) - 2;
        shotPerSec = 1;
        shipShotSpeed = 2;

        shipFiring = false;
        spacebarLocked = false;

        fleetPositionX = new List<int>();
        fleetPositionY = new List<int>();

        fleetShotsX = new List<int>();
        fleetShotsY = new List<int>();

        shipShotsX = new List<int>();
        shipShotsY = new List<int>();

        direction = 1;

        shipsPerColumn = 10;
        shipsPerRow = 10;
        fleetShotDensity = 1;

        score = 0;
        lives = 3;
    }

    private static void PlayInitialSound()
    {
        SoundPlayer player = new SoundPlayer("initialSound.wav");
        using (player)
        {
            player.PlaySync();
        }
    }

    private static void PlayShootSound()
    {
        SoundPlayer player = new SoundPlayer("shootSound.wav");
        using (player)
        {
            player.PlaySync();
        }
    }

    private static void YouWin()
    {
        CheckForHighScore(score, ReadHighScore());
        Console.Clear();
        string filePath = "youWinText.txt";
        string text = string.Empty;

        try
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                text = reader.ReadToEnd();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
        }
        catch (DirectoryNotFoundException dirNF)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dirNF.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }
        catch (FileNotFoundException fileNF)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(fileNF.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }
        catch (IOException inputOutputEx)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputOutputEx.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }
    }

    private static void GameEngine()
    {
        while (indexRow < playGroundHeight - shipsPerRow - 1)
        {
            if (lives <= 0)
            {
                GameOver();
                break;
            }

            if (score >= shipsPerColumn * shipsPerRow * scorePerShip)
            {
                YouWin();

                break;
            }

            SpaceShipMovements();
            GenarateFleetShots();
            GenerateShipShots();
            UpdateShipShots();
            UpdateFleetShots();
            FleetUpdate();
            KillMyShip();

            Console.SetCursorPosition(0, 0);
            Console.Write("Score: {0}", score);

            Console.SetCursorPosition((playGroundWidth / 2) - 3, 0);
            Console.Write("Lives: {0}", lives);

            Console.SetCursorPosition(playGroundWidth - 18, 0);
            Console.Write("High score: {0}", ReadHighScore());

            Console.SetCursorPosition(0, 1);
            Console.Write(new string('*', Console.WindowWidth));

            Thread.Sleep(80);
        }

        GameOver();
    }

    private static void GenarateFleetShots()
    {
        for (int i = 0; i < fleetShotDensity; i++)
        {
            fleetShotsX.Add(generator.Next(fleetPositionY[1], fleetPositionY[maxShipsX - 1]));
            fleetShotsY.Add(fleetPositionY.Count - 1);
        }
    }

    private static void UpdateFleetShots()
    {
        Console.SetCursorPosition(0, playGroundHeight - 1);
        Console.Write(new string(' ', Console.WindowWidth));

        for (int i = 0; i < fleetShotDensity; i++)
        {
            if (fleetShotsY[i] <= playGroundHeight - 1)
            {
                Console.SetCursorPosition(fleetShotsX[i], fleetShotsY[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*");

                Console.SetCursorPosition(fleetShotsX[i], fleetShotsY[i] - 1);
                Console.Write(" ");

                fleetShotsY[i] += 1;
            }
            else
            {
                fleetShotsX[i] = generator.Next(fleetPositionX[1], fleetPositionX[maxShipsY - 1]);
                fleetShotsY[i] = fleetPositionY[i] + shipsPerRow;
            }
        }
    }

    private static void RechargeShipShots()
    {
        for (int i = 0; i < shotPerSec; i++)
        {
            shipShotsY[i] = playGroundHeight - 1 - i;
            shipShotsX[i] = spaceShipPosition + 2;
        }
    }

    private static void GameFrame()
    {
        for (int i = 0; i < playGroundHeight; i++)
        {
            if (move % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                move = 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                move = 0;
            }

            Console.SetCursorPosition(0, i);
            Console.WriteLine("|");
            Console.SetCursorPosition(playGroundWidth, i);
            Console.WriteLine("|");
        }
    }

    private static void DrawShots(int x, int y)
    {
        Console.SetCursorPosition(x, y + shipShotSpeed);
        Console.Write(" ");

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("^");
    }

    private static void UpdateShipShots()
    {
        int i = 0;
        for (i = 0; i < shotPerSec; i++)
        {
            if (shipShotsY[i] > shipShotSpeed && shipFiring == true)
            {
                shipShotsY[i] -= shipShotSpeed;
                ColisionDefiner(shipShotsX[i], shipShotsY[i]);
                DrawShots(shipShotsX[i], shipShotsY[i]);
                spacebarLocked = false;
            }
            else
            {
                spacebarLocked = true;
                shipFiring = false;
            }
        }
    }

    private static void GenerateShipShots()
    {
        for (int i = 0; i < shotPerSec; i++)
        {
            shipShotsX.Add(spaceShipPosition + 2);
            shipShotsY.Add(playGroundHeight - i);
        }
    }

    private static void SpaceShipMovements()
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo craftPosition = Console.ReadKey(true);

            // left
            if (craftPosition.Key == ConsoleKey.LeftArrow)
            {
                if (spaceShipPosition > 1)
                {
                    spaceShipPosition--;
                }

                Console.SetCursorPosition(spaceShipPosition + 5, playGroundHeight);
                Console.Write(" ");
            }

            // right
            if (craftPosition.Key == ConsoleKey.RightArrow)
            {
                if (spaceShipPosition < playGroundWidth - 5)
                {
                    spaceShipPosition++;
                }

                Console.SetCursorPosition(spaceShipPosition - 1, playGroundHeight);
                Console.Write(" ");
            }

            // shoot
            if (craftPosition.Key == ConsoleKey.Spacebar && spacebarLocked == true)
            {
                Thread threadPlayShootSound = new Thread(PlayShootSound);
                threadPlayShootSound.Start();

                shipFiring = true;
                RechargeShipShots();
            }
        }

        Console.SetCursorPosition(spaceShipPosition, playGroundHeight);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("(=\u2551=)");
    }

    private static void ColisionDefiner(int sX, int sY)
    {
        int indexColumn = fleetPositionX.IndexOf(sX);

        if (fleetPositionY.Contains(sY) && fleetPositionX.Contains(sX))
        {
            ShipToRemove(indexColumn);
        }
    }

    private static void ShipToRemove(int fleetShipY)
    {
        for (int fleetShipX = fleetPositionY.Count - 1; fleetShipX >= 0; fleetShipX--)
        {
            if (fleet[fleetShipX, fleetShipY] != ' ' && shipFiring == true)
            {
                score += scorePerShip;

                if (fleet[fleetShipX, fleetShipY] == '(')
                {
                    fleet[fleetShipX, fleetShipY] = ' ';
                    fleet[fleetShipX, fleetShipY + 1] = ' ';
                    fleet[fleetShipX, fleetShipY + 2] = ' ';
                }
                else if (fleet[fleetShipX, fleetShipY] == '\u03C9')
                {
                    fleet[fleetShipX, fleetShipY] = ' ';
                    fleet[fleetShipX, fleetShipY + 1] = ' ';
                    fleet[fleetShipX, fleetShipY - 1] = ' ';
                }
                else if (fleet[fleetShipX, fleetShipY] == ')')
                {
                    fleet[fleetShipX, fleetShipY] = ' ';
                    fleet[fleetShipX, fleetShipY - 1] = ' ';
                    fleet[fleetShipX, fleetShipY - 2] = ' ';
                }

                shipFiring = false;
            }
        }
    }

    private static void GenerateFleet(int shipPerX, int shipPerY)
    {
        fleet = new char[shipPerX, 3 * shipPerY];

        for (int i = 0; i < shipsPerRow; i++)
        {
            fleetPositionY.Add(i);

            for (int j = 0; j < shipPerY * 3; j++)
            {
                if (j % 3 == 0)
                {
                    fleet[i, j] = '(';
                }

                if (j % 3 == 1)
                {
                    fleet[i, j] = '\u03C9';
                }

                if (j % 3 == 2)
                {
                    fleet[i, j] = ')';
                }
            }
        }

        for (int k = 0; k < shipPerY * 3; k++)
        {
            fleetPositionX.Add(k);
        }

        maxShipsX = fleetPositionY.Count;
        maxShipsY = fleetPositionX.Count;
    }

    private static void FleetUpdate()
    {
        indexRow = fleetPositionY[0];
        indexCol = fleetPositionX[fleetPositionX.Count - 1];

        if (direction == 1) // right
        {
            for (int i = 0; i < fleetPositionX.Count; i++)
            {
                fleetPositionX[i]++;

                if (fleetPositionX[fleetPositionX.Count - 1] >= playGroundWidth)
                {
                    direction = 2;
                    break;
                }
            }
        }
        else if (direction == 2) // down
        {
            Console.SetCursorPosition(0, indexRow + topBarHight);
            Console.Write(new string(' ', Console.WindowWidth));

            for (int i = 0; i < fleetPositionY.Count; i++)
            {
                fleetPositionY[i]++;
            }

            direction = 3;
        }
        else if (direction == 3) // right
        {
            for (int i = 0; i < fleetPositionX.Count; i++)
            {
                fleetPositionX[i]--;
                if (fleetPositionX[fleetPositionX.Count - 1] < shipsPerColumn * 3)
                {
                    direction = 4;
                    break;
                }
            }
        }
        else if (direction == 4) // down
        {
            Console.SetCursorPosition(0, indexRow + topBarHight);
            Console.Write(new string(' ', Console.WindowWidth));

            for (int i = 0; i < fleetPositionY.Count; i++)
            {
                fleetPositionY[i]++;
            }

            direction = 1;
        }

        DrawFleet();
    }

    private static void DrawFleet()
    {
        for (int col = 0; col < fleetPositionY.Count; col++)
        {
            for (int row = 0; row < fleetPositionX.Count; row++)
            {
                Console.SetCursorPosition(fleetPositionX[row], fleetPositionY[col] + topBarHight);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(fleet[col, row]);

                for (int i = col; i < col + 1; i++)
                {
                    Console.Write(' ');
                }
            }
        }

        for (int col = 0; col < fleetPositionY.Count; col++)
        {
            for (int row = 0; row < 1; row++)
            {
                if (fleetPositionX[row] >= 1)
                {
                    Console.SetCursorPosition(fleetPositionX[row] - 1, fleetPositionY[col] + topBarHight);
                    Console.Write(' ');
                }
            }
        }
    }

    private static void KillMyShip()
    {
        for (int i = 0; i < fleetShotDensity; i++)
        {
            bool isShotAtBottom = fleetShotsY[i] + 1 == playGroundHeight + 1;
            bool shipIsHit = spaceShipPosition + 0 == fleetShotsX[i] ||
                             spaceShipPosition + 1 == fleetShotsX[i] ||
                             spaceShipPosition + 2 == fleetShotsX[i] ||
                             spaceShipPosition + 3 == fleetShotsX[i] ||
                             spaceShipPosition + 4 == fleetShotsX[i];

            if (isShotAtBottom && shipIsHit)
            {
                lives--;
                Console.Beep();
            }
        }
    }

    private static void GameOver()
    {
        CheckForHighScore(score, ReadHighScore());

        Console.SetCursorPosition((playGroundWidth / 2) - 6, playGroundHeight / 2);

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write("Game over!");

        Console.SetCursorPosition((playGroundWidth / 2) - 9, (playGroundHeight / 2) + 1);
        Console.Write("Your score: {0}", score);

        Thread.Sleep(4000);

        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        Main();

        return;
    }

    private static int ReadHighScore()
    {
        int highScore = 0;
        string filePath = "highScore.txt";

        try
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string line = reader.ReadLine();
                line.Trim();
                highScore = int.Parse(line);
            }
        }
        catch (DirectoryNotFoundException dirNF)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dirNF.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }
        catch (FileNotFoundException fileNF)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(fileNF.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }
        catch (IOException inputOutputEx)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputOutputEx.Message);
            Console.WriteLine();
            Environment.Exit(0);
        }

        return highScore;
    }

    private static void CheckForHighScore(int currScore, int currHighScore)
    {
        string filePath = "highScore.txt";

        if (currScore > currHighScore)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                using (writer)
                {
                    writer.WriteLine(currScore);
                }
            }
            catch (IOException inputOutputEx)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(inputOutputEx.Message);
                Console.WriteLine();
                Environment.Exit(0);
            }
        }
    }

    private static void Menu()
    {
        StreamReader reader = new StreamReader("galaxianText.txt");
        string galaxianText = string.Empty;

        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                galaxianText += "\t" + line + "\n";
                line = reader.ReadLine();
            }
        }

        string menuText = string.Empty;
        StreamReader readerOne = new StreamReader("menuText.txt");
        using (readerOne)
        {
            string lineOne = readerOne.ReadLine();

            while (lineOne != null)
            {
                menuText += "\t\t\t\t\t" + lineOne + "\n";
                lineOne = readerOne.ReadLine();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(galaxianText + "\n\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(menuText);

        Console.SetCursorPosition(0, playGroundHeight - 1);
        Console.Write("1. Use Left and Right arrows to move.");

        Console.SetCursorPosition(0, playGroundHeight);
        Console.Write("2. Use Spacebar to shoot.");

        while (true)
        {
            Console.SetCursorPosition(1, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t\t\t\t      Press ENTER to start the game...");
            Thread.Sleep(800);

            Console.SetCursorPosition(1, 20);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string(' ', Console.WindowWidth));
            Thread.Sleep(800);

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo enter = Console.ReadKey();
                if (enter.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    Thread threadPlayInitialSound = new Thread(PlayInitialSound);
                    threadPlayInitialSound.Start();

                    return;
                }
            }
        }
    }
}