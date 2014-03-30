using System;
using System.Linq;
using System.Threading;

namespace _07.DelegatesAndTimer
{
    public delegate void Execute();

    public class Timer
    {
        private static string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
        private static int numColors = colorNames.Length;
        
        public void Start(Action action, int sec)
        {
            Random rand = new Random();

            while (true)
            {                
                string colorName = colorNames[rand.Next(numColors)];

                // Get ConsoleColor from string name
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                colorName = colorNames[rand.Next(numColors)];
                ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                // Assuming you want to set the Foreground here, not the Background
                Console.ForegroundColor = color;
                Console.BackgroundColor = color2;

                Thread.Sleep(sec * 1000);

                Console.WriteLine("{0} seconds passed.", sec);

                Execute e = new Execute(action);

                e();
            }           
        }
    }
}