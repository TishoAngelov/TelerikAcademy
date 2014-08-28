namespace Computers.UI.Console
{
    using System;
    using Computers.UI.Console.Interfaces;

    public class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string outputText)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(outputText);
            Console.ResetColor();
        }
    }
}
