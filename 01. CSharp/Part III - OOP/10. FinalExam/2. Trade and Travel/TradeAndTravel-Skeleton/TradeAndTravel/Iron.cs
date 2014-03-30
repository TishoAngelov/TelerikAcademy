using System;

namespace TradeAndTravel
{
    public class Iron : Item
    {
        // Constants
        const int GeneralIronValue = 3;

        // Constructors
        public Iron(string name, Location location = null)
            : base(name, Iron.GeneralIronValue, ItemType.Iron, location)
        {
        }
    }
}