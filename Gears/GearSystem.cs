namespace Level52.Gears;

static class GearSystem
{
    public static void ExecuteEquip(Character activeCharacter, Gear gear, Party party)
    {
        var existingGear = GetEquipedGear(activeCharacter);
        if (existingGear != null)
            UnequipGear(activeCharacter, existingGear, party);
        EquipGear(activeCharacter, gear, party);
    }
    public static Gear? GetEquipedGear(Character character) => character.EquipedGear;

    public static void UnequipGear(Character activeCharacter, Gear gear, Party party)
    {
        activeCharacter.EquipedGear = null;
        activeCharacter.Attacks.Remove(gear.GetAttack());
        party.GearInventory.Add(gear);
    }

    public static void EquipGear(Character character, Gear gear, Party party)
    {
        var attack = gear.GetAttack();
        party.GearInventory.Remove(gear);
        character.EquipedGear = gear;
        if (!character.Attacks.Contains(attack))
            character.Attacks.Add(attack);
    }

    public static List<Gear> GetGear(Party party) => party.GearInventory;
    public static void AddGearToParty(Party party, Gear gear) => party.GearInventory.Add(gear);
    public static void RemoveGearFromParty(Party party, Gear gear) => party.GearInventory.Remove(gear);
}