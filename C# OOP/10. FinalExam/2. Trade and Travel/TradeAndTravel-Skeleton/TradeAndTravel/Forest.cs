using System;

namespace TradeAndTravel
{
    public class Forest : Location      // Should inherit IGatheringLocation. The best way is to implement GatheringLocation class and inherit it.
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }
    }
}