using Level52.Attacks;
using Level52.Items;

namespace Level52.Actions;

public class Action
{
    public ActionType Type { get; }
    public Character? ActiveCharacter { get; }
    public Character? Target { get; }
    public Item? Item { get; }
    public Attack? Attack { get; }
    public Party? ActiveParty { get; }

    public Action(
        ActionType type,
        Character? activeCharacter = null,
        Character? target = null,
        Item? item = null,
        Attack? attack = null,
        Party? activeParty = null)
    {
        Type = type;
        ActiveCharacter = activeCharacter;
        Target = target;
        Item = item;
        Attack = attack;
        ActiveParty = activeParty;
    }

    public static Action CreateAttackAction(Character activeCharacter, Character target, Attack attack)
    {
        return new Action(
            ActionType.Attack,
            activeCharacter: activeCharacter,
            target: target,
            attack: attack);
    }

    public static Action CreateUseItemAction(Character activeCharacter, Item item, Party party)
    {
        return new Action(
            ActionType.UseItem,
            activeCharacter: activeCharacter,
            item: item,
            activeParty: party);
    }

    public static Action CreateDoNothingAction(Character activeCharacter)
    {
        return new Action(
            ActionType.DoNothing,
            activeCharacter: activeCharacter);
    }
}