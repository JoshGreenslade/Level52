using Level52.Utils;

namespace Level52.Items;

public static class ItemSystem
{
    public static void UseItem(Item item, Character target)
    {
        target.AddHealth(item.Healing);
        ServiceLocator.Display.WriteLine($"{target.GetName()} healed for {item.Healing} HP!");
        ServiceLocator.Display.WriteLine($"{target.GetName()} is now at {target.GetHp()} HP!");
    }

    public static List<Item> GetItems(Party party) => party.Inventory.GetItems();
    public static void AddItem(Party party, Item item) => party.Inventory.AddItem(item);
    public static void RemoveItem(Party party, Item item) => party.Inventory.RemoveItem(item);

}