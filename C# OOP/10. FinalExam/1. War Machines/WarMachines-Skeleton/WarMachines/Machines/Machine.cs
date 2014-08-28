namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        // Fields
        protected string name;
        protected double healthPoints;
        protected double attackPoints;
        protected double defensePoints;

        protected IPilot pilot;
        protected readonly List<string> targets;

        // Consturctors
        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;

            this.targets = new List<string>();
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        // Methods
        public override string ToString()
        {
            StringBuilder machineToStr = new StringBuilder();

            machineToStr.AppendFormat("- {0}", this.Name);
            machineToStr.AppendLine();

            machineToStr.AppendFormat(" *Type: {0}", this.GetType().Name);
            machineToStr.AppendLine();

            machineToStr.AppendFormat(" *Health: {0}", this.HealthPoints);
            machineToStr.AppendLine();

            machineToStr.AppendFormat(" *Attack: {0}", this.AttackPoints);
            machineToStr.AppendLine();

            machineToStr.AppendFormat(" *Defense: {0}", this.DefensePoints);
            machineToStr.AppendLine();

            if (this.Targets.Count == 0)
            {
                machineToStr.Append(" *Targets: None");
            }
            else
            {
                machineToStr.Append(" *Targets: ");

                foreach (string target in this.Targets.Where(t => t.Equals(this.Targets[0])))
                {
                    machineToStr.AppendFormat("{0}, ", target);
                }

                machineToStr.Length = machineToStr.Length - 2;
            }

            machineToStr.AppendLine();

            return machineToStr.ToString();
        }
    }
}