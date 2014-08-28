using System;


class FallingRocksGame
{
    /*
        Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of
    the screen and can move left and right (by the arrows keys). A number of rocks of different
    sizes and forms constantly fall down and you need to avoid a crash.
        Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density.
    The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
        Implement collision detection and scoring system.
    */

    static void Main()
    {
        string dwarf = "(0)";
        int leftIntervalCount = Console.WindowWidth / 2;
        int rightIntervalCount = Console.WindowWidth / 2 - 3;
        int lineCount = Console.WindowHeight - 3;

        do
        {
            
            Console.WriteLine(new string('\n', lineCount) + new string(' ', leftIntervalCount) + dwarf + new string(' ', rightIntervalCount));

            if (Console.ReadKey(true).Key.Equals(ConsoleKey.LeftArrow))
            {
                while (leftIntervalCount > 0)
                {
                    leftIntervalCount--;
                    rightIntervalCount++;
                    break;
                }                
            }
            if (Console.ReadKey(true).Key.Equals(ConsoleKey.RightArrow))
            {
                while (rightIntervalCount > 0)
                {
                    
                    rightIntervalCount--;
                    leftIntervalCount++;
                    break;
                }                
            }
            Console.Clear();
            //Console.WriteLine(rightIntervalCount);
           
            
            Random random = new Random();
            int countRocks = random.Next(0,15);
            
            
            string rockLine = "";// new string('+', countRocks);
            //do
            //{
            //    for (int i = 0; i < countRocks; i++)
            //    {
            //     //   rockLine += new string(' ', 5 + i * 3) + new string('+', 1);
            //        if (i == 6)
            //        {
            //            i = 0;
            //          //  rockLine += "\n";
            //        }
            //    }
            //} while (rockLine.Length <= 2000);
            
         //   Console.WriteLine(rockLine);
        } while(true);       
    }
}

