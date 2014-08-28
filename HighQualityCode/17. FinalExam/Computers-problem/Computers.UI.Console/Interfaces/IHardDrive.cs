namespace Computers.UI.Console.Interfaces
{
    using System;

    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
