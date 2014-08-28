namespace Computers.UI.Console.AbstractFactory
{
    public abstract class ComputerManufacturer
    {
        public abstract PersonalComputer ManufacturePC();

        public abstract Laptop ManufactureLaptop();

        public abstract Server ManufactureServer();
    }
}
