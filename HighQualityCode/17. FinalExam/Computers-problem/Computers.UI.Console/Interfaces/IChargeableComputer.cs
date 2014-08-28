namespace Computers.UI.Console.Interfaces
{
    public interface IChargeableComputer : IComputer
    {
        IBattery Battery { get; }

        void ChargeBattery(int percentage);
    }
}
