namespace Level52.Items;

public class Item
{
    public string Name { get; }
    public int Healing { get; }

    public Item(string name, int healing = 0)
    {
        Name = name;
        Healing = healing;
    }

    public static Item CreateHealingPotion()
    {
        return new Item(
            name: "Healing Potion",
            healing: 10);
    }
}