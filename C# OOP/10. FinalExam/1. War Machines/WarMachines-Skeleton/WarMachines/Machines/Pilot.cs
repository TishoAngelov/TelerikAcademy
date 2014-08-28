namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;
    using System.Linq;
    using System.Text;

    public class Pilot : IPilot
    {
        // Fields
        private readonly string name;
        private readonly List<IMachine> machines;

        // Constructors
        public Pilot(string name)
        {
            this.name = name;
            this.machines = new List<IMachine>();
        }

        // Properties
        public string Name
        {
            get { return this.name; }
        }

        // Methods
        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendFormat("{0} - ", this.Name);

            if (this.machines.Count == 0)
            {
                report.Append("no machines");

                return report.ToString();
            }
            else
            {
                if (this.machines.Count == 1)
                {
                    report.Append("1 machine");
                    report.AppendLine();
                }
                else
                {
                    report.AppendFormat("{0} machines", this.machines.Count);
                    report.AppendLine();
                }

                foreach (IMachine machine in this.machines)
                {
                    report.Append(machine.ToString());
                }
            }

            return report.ToString();
        }
    }
}