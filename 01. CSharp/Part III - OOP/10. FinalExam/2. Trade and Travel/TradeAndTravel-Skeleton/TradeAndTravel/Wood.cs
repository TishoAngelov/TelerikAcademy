using System;

namespace TradeAndTravel
{
    public class Wood : Item
    { 
        // Constants
        const int GeneralWoodValue = 2;
        
        // Constructors
        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        // Methods
        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}