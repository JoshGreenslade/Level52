using Level52.Items;

namespace Level52;

public class Inventory
{
    private List<Item> _items { get; set; }

    public Inventory()
    {
        _items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    public List<Item> GetItems() => _items;
}