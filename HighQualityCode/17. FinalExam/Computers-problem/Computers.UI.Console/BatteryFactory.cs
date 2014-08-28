namespace Computers.UI.Console
{
    using System;
    using Computers.UI.Console.Enumerations;
    using Computers.UI.Console.Interfaces;

    public static class BatteryFactory
    {
        private const int InitialLaptopPowerLeft = 50;

        public static IBattery GetBattery(BatteryType batteryType)
        {
            switch (batteryType)
            {
                case BatteryType.LaptopBattery:
                    return new Battery(InitialLaptopPowerLeft);
                default:
                    throw new ArgumentException("Invalid battery type.");
            }
        }
    }
}
