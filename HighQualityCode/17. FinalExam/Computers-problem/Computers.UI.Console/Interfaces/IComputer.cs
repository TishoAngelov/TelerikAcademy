namespace Computers.UI.Console.Interfaces
{
    using System.Collections.Generic;

    public interface IComputer
    {
        ICpu Cpu { get; }

        IRamMemory Ram { get; }

        IVideoCard VideoCard { get; }

        IEnumerable<IHardDrive> HardDrives { get; }
    }
}
