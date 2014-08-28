namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.UI.Console.Interfaces;

    public class HardDriver : IHardDrive
    {        
        private List<HardDriver> hds;
        private bool isInRaid;
        private int hardDrivesInRaid;

        // private SortedDictionary<int, string> info; never used ?!
        private int capacity;
        private Dictionary<int, string> data;

        internal HardDriver()
        {
        }

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<HardDriver>();
        }

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDriver> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<HardDriver>();
            this.hds = hardDrives;
        }
                
        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }
        
        public void SaveData(int address, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(address, newData);
                }
            }
            else
            {
                this.data[address] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hds.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }
    }
}
