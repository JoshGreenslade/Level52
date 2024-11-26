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
}