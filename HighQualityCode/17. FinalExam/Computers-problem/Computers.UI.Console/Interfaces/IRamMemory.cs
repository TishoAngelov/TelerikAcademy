namespace Computers.UI.Console.Interfaces
{
    using System;

    public interface IRamMemory
    {
        int Amount { get; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
