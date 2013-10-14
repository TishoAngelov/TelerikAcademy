using System;

class Slides
{
    class Ball
    {
        public int BallWidth { get; set; }

        public int BallHeight { get; set; }

        public int BallDepth { get; set; }

        public Ball(int width, int height, int depth)
        {
            this.BallWidth = width;
            this.BallHeight = height;
            this.BallDepth = depth;
        }
    }

    static void Main()
    {
        string[] cubeDimensions = Console.ReadLine().Split();

        int cubeWidth = int.Parse(cubeDimensions[0]);
        int cubeHeight = int.Parse(cubeDimensions[1]);
        int cubeDepth = int.Parse(cubeDimensions[2]);

        string[, ,] cube = new string[cubeWidth, cubeHeight, cubeDepth];

        for (int h = 0; h < cubeHeight; h++)
        {
            string[] currDepth = Console.ReadLine().Split(new string[]{ " | " }, 
                                        StringSplitOptions.RemoveEmptyEntries);;

            for (int d = 0; d < cubeDepth; d++)
            {
                string[] currWidth = currDepth[d].Split(new char[]{ '(', ')'} , 
                                        StringSplitOptions.RemoveEmptyEntries);

                for (int w = 0; w < cubeWidth; w++)
                {
                    cube[w, h, d] = currWidth[w];
                }
            }
        }
    }
}