namespace Computers.UI.Console.AbstractFactory
{
    using System;
    using System.Collections.Generic;
    using Computers.UI.Console.Enumerations;
    using Computers.UI.Console.Interfaces;

    public class HPComputers : ComputerManufacturer
    {
        private ICpu cpu;
        private IRamMemory ram;
        private IVideoCard videoCard;
        private IEnumerable<IHardDrive> hardDrives;

        // The hardcoded values are used on only one place so i think that there is no need of constants.
        public override PersonalComputer ManufacturePC()
        {
            this.ram = new RamMemory(2);
            this.videoCard = new ColorfulVideoCard();
            this.cpu = new Cpu(2, 32, this.ram, this.videoCard);
            this.hardDrives = new[] 
            { 
                new HardDriver(500, false, 0)
            };

            return new PersonalComputer(this.cpu, this.ram, this.videoCard, this.hardDrives);
        }

        public override Laptop ManufactureLaptop()
        {
            this.ram = new RamMemory(4);
            this.videoCard = new ColorfulVideoCard();
            this.cpu = new Cpu(2, 64, this.ram, this.videoCard);
            this.hardDrives = new[] 
            { 
                new HardDriver(500, false, 0)
            };
            IBattery battery = BatteryFactory.GetBattery(BatteryType.LaptopBattery);

            return new Laptop(this.cpu, this.ram, this.videoCard, this.hardDrives, battery);
        }

        public override Server ManufactureServer()
        {
            this.ram = new RamMemory(32);
            this.cpu = new Cpu(4, 32, this.ram);
            this.hardDrives = new List<HardDriver> 
            { 
                new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) })
            };
            return new Server(this.cpu, this.ram, this.hardDrives);
        }
    }
}
