using System;

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        // Constants
        const int GeneralWeaponValue = 10;

        // Constructors
        public Weapon(string name, Location location = null)
            : base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location)
        {
        }
    }
}