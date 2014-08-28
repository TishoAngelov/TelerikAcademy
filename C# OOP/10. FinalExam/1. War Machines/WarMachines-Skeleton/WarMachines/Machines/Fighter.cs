namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        // Fields
        private bool stealthMode;

        // Constructors
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
           : base(name, attackPoints, defensePoints)
        {
            this.stealthMode = stealthMode;

            this.HealthPoints = 200;
        }

        // Properties
        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        // Methods
        public void ToggleStealthMode()
        {
            if (this.stealthMode == false)
            {
                this.stealthMode = true;
            }
            else
            {
                this.stealthMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder fighterToStr = new StringBuilder();

            fighterToStr.AppendFormat(" *Stealth: {0}", this.StealthMode == true ? "ON" : "OFF");

            return base.ToString() + fighterToStr.ToString();
        }
    }
}