namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        // Fields
        private bool defenseMode;

        // Constructors
        public Tank(string name, double attackPoints, double defensePoints)
            :base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            ToggleDefenseMode();
        }

        // Properties
        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        // Methods
        public void ToggleDefenseMode()
        {
            if (this.defenseMode == false)
            {
                this.defenseMode = true;

                this.defensePoints += 30;
                this.attackPoints -= 40;
            }
            else
            {
                this.defenseMode = false;

                this.defensePoints -= 30;
                this.attackPoints += 40;
            }
        }

        public override string ToString()
        {
            StringBuilder tankToStr = new StringBuilder();

            tankToStr.AppendFormat(" *Defense: {0}", this.DefenseMode == true ? "ON" : "OFF");
            tankToStr.AppendLine();

            return base.ToString() + tankToStr.ToString();
        }
    }
}