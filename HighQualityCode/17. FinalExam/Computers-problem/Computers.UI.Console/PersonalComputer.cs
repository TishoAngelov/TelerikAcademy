namespace Computers.UI.Console
{
    using System.Collections.Generic;
    using Computers.UI.Console.Interfaces;

    public class PersonalComputer : Computer, IComputer, IPlayableComputer
    {
        public PersonalComputer(ICpu cpu, IRamMemory ram, IVideoCard videoCard, IEnumerable<IHardDrive> hardDrives)
            : base(cpu, ram, videoCard, hardDrives)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = this.Ram.LoadValue();

            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }
    }
}
