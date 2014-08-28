namespace Computers.UI.Console
{
    using System;
    using Computers.UI.Console.Interfaces;

    public class ColorfulVideoCard : IVideoCard
    {
        public void Draw(string outputText)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(outputText);
            Console.ResetColor();
        }
    }
}
