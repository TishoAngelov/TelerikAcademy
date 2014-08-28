using System;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Add some exploding blocks
            for (int i = startCol; i < endCol - 1; i++)
            {
                Block currBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // Side walls
            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock indestrBlock = new IndestructibleBlock(new MatrixCoords(row, 0));

                engine.AddObject(indestrBlock);

                indestrBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(indestrBlock);
            }

            // Ceiling
            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock indestrBlock = new IndestructibleBlock(new MatrixCoords(0, col));

                engine.AddObject(indestrBlock);
            }

            // Some trail object: body - 'T'
            TrailObject trailObj = new TrailObject(20, new MatrixCoords(10, 15), new char[,] { { 'T' } });

            engine.AddObject(trailObj);

            // Some unpassable blocks: body - 'X'
            for (int col = 4; col < WorldCols - 12; col += 3)
            {
                UnpassableBlock unpassBlock = new UnpassableBlock(new MatrixCoords(6, col));

                engine.AddObject(unpassBlock);
            }

            // Unpassable wall and ceiling (we can't edit the other classes so the 
            // unstoppable ball will go throw indestructable block but we cant edit it!).
            for (int col = 1; col < WorldCols - 1; col++)
            {
                UnpassableBlock unpassBlock = new UnpassableBlock(new MatrixCoords(1, col));

                engine.AddObject(unpassBlock);
            }

            for (int row = 2; row < WorldRows; row++)
            {
                UnpassableBlock unpassBlock = new UnpassableBlock(new MatrixCoords(row, WorldCols - 2));

                engine.AddObject(unpassBlock);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(200, renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // Shooting
            //keyboard.OnActionPressed += (sender, eventInfo) =>
            //{
            //    gameEngine.ShootPlayerRacket();
            //};

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
