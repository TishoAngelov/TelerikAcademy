using System;
using System.Linq;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        public ExtendedInteractionManager()
            : base()
        {
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;

                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;

                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;

                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "town":
                    return base.CreateLocation(locationTypeString, locationName);

                case "mine":
                    location = new Mine(locationName);
                    break;

                case "forest":
                    location = new Forest(locationName);
                    break;

                default:
                    break;
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;

                case "craft":
                    HandleCraftInteraction(commandWords[2], commandWords[3], actor);
                    break;

                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;

                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;

        }

        // Private methods
        private void HandleCraftInteraction(string itemType, string newItemName, Person actor)
        {
            Item craftedItem = null;

            Item ironItem = actor.ListInventory().FirstOrDefault(i => i.ItemType == ItemType.Iron);
            Item woodItem = actor.ListInventory().FirstOrDefault(i => i.ItemType == ItemType.Wood);

            if (ironItem != null && itemType == "armor")
            {
                craftedItem = new Armor(newItemName);
                this.AddToPerson(actor, craftedItem);
            }
            else if (ironItem != null && woodItem != null && itemType == "weapon")
            {
                craftedItem = new Weapon(newItemName);
                this.AddToPerson(actor, craftedItem);
            }
        }

        private void HandleGatherInteraction(string newItemName, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                Item weaponItem = actor.ListInventory().FirstOrDefault(i => i.ItemType == ItemType.Weapon);

                if (weaponItem != null)
                {
                    Item gatheredItem = new Wood(newItemName);
                    this.AddToPerson(actor, gatheredItem);
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                Item armorItem = actor.ListInventory().FirstOrDefault(i => i.ItemType == ItemType.Armor);

                if (armorItem != null)
                {
                    Item gatheredItem = new Iron(newItemName);
                    this.AddToPerson(actor, gatheredItem);
                }
            }
        }
    }
}