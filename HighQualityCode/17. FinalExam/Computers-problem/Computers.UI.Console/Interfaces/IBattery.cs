namespace Computers.UI.Console.Interfaces
{
    public interface IBattery
    {
        int PercentagePowerLeft { get; }

        void Charge(int percentage);
    }
}
