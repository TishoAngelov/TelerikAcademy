namespace Computers.UI.Console
{
    using System.Collections.Generic;
    using Computers.UI.Console.Interfaces;

    public class Server : IComputer, IProcessableComputer
    {
        private IVideoCard defaultVideoCard = new MonochromeVideoCard();
        private ICpu cpu;
        private IRamMemory ram;
        private IVideoCard videoCard;
        private IEnumerable<IHardDrive> hardDrives;

        public Server(ICpu cpu, IRamMemory ram, IEnumerable<IHardDrive> hardDrives) 
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = this.defaultVideoCard;
        }

        public ICpu Cpu
        {
            get
            {
                return this.cpu;
            }

            set
            {
                this.cpu = value;
            }
        }

        public IRamMemory Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                this.ram = value;
            }
        }

        public IVideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }

            private set
            {
                this.videoCard = value;
            }
        }

        public IEnumerable<IHardDrive> HardDrives
        {
            get
            {
                return this.hardDrives;
            }

            set
            {
                this.hardDrives = value;
            }
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);

            this.Cpu.SquareNumber();
        }
    }
}
