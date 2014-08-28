namespace Computers.UI.Console
{
    using System.Collections.Generic;
    using Computers.UI.Console.Interfaces;

    public abstract class Computer
    {
        private ICpu cpu;
        private IRamMemory ram;
        private IVideoCard videoCard;
        private IEnumerable<IHardDrive> hardDrives;
        
        public Computer(ICpu cpu, IRamMemory ram, IVideoCard videoCard, IEnumerable<IHardDrive> hardDrives)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.videoCard = videoCard;
            this.hardDrives = hardDrives;
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

            set
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
    }
}
