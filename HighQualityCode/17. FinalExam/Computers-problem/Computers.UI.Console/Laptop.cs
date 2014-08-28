namespace Computers.UI.Console
{
    using System.Collections.Generic;
    using Computers.UI.Console.Interfaces;

    public class Laptop : Computer, IComputer, IChargeableComputer
    {
        private IBattery battery;

        public Laptop(ICpu cpu, IRamMemory ram, IVideoCard videoCard, IEnumerable<IHardDrive> hardDrives, IBattery battery)
            : base(cpu, ram, videoCard, hardDrives)
        {
            this.Battery = battery;
        }

        public IBattery Battery
        {
            get 
            {
                return this.battery;
            }

            set 
            {
                this.battery = value;
            }
        }
        
        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.VideoCard.Draw(string.Format("Battery status: {0}%", this.battery.PercentagePowerLeft));
        }
    }
}
