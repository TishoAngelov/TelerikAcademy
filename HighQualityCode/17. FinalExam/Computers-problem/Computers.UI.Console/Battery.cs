namespace Computers.UI.Console
{
    using Computers.UI.Console.Interfaces;

    public class Battery : IBattery
    {
        private const int MinPower = 0;
        private const int MaxPower = 100;

        private int percentagePowerLeft;

        public Battery(int initialPowerLeft)
        {
            this.PercentagePowerLeft = initialPowerLeft;
        }

        public int PercentagePowerLeft
        {
            get
            {
                return this.percentagePowerLeft;
            }

            private set
            {
                if (this.percentagePowerLeft + value > MaxPower)
                {
                    this.percentagePowerLeft = MaxPower;
                }
                else if (this.percentagePowerLeft + value < MinPower)
                {
                    this.percentagePowerLeft = MinPower;
                }
                else
                {
                    this.percentagePowerLeft += value;
                }
            }
        }

        public void Charge(int percentage)
        {
            this.PercentagePowerLeft += percentage - this.PercentagePowerLeft;            
        }
    }
}
