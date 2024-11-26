using Level52.Actions;
using Level52.Items;

namespace Level52;

public class Party
{
    public List<Character> Characters { get; set; }
    public Inventory Inventory { get; set; }

    public Party()
    {
        Characters = new List<Character>();
        Inventory = new Inventory();
    }
    public Party(List<Character> characters)
    {
        Characters = characters;
        Inventory = new Inventory();
    }

    public void AddCharacter(Character character)
    {
        if (Characters.Contains(character)) return;
        Characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        if (Characters.Contains(character))
            Characters.Remove(character);
    }

    public void SetPlayerControlled()
    {
        foreach (var character in Characters)
            character.SetPlayerControlled();
    }

    public List<Character> GetCharacters() => Characters;
    public List<Item> GetInventory() => Inventory.GetItems();

    public void AddItem(Item item)
    {
        Inventory.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        Inventory.RemoveItem(item);
    }
    public void SetCharacters(List<Character> characters) => Characters = characters;
}