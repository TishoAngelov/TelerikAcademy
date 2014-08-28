using System;

namespace TradeAndTravel
{
    public class Mine : Location        // Should inherit IGatheringLocation. The best way is to implement GatheringLocation class and inherit it.
    {
        public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }
    }
}