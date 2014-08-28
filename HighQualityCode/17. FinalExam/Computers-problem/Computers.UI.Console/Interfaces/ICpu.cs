namespace Computers.UI.Console.Interfaces
{
    public interface ICpu
    {
        byte NumberOfCores { get; }

        void GenerateRandomNumber(int minValue, int maxValue);

        void SquareNumber();
    }
}
