using Level52.Items;
using Level52.Utils;

namespace Level52.Actions;

public static class ActionSystem
{
    public static void Execute(Action action)
    {
        switch (action.Type)
        {
            case ActionType.Attack:
                ExecuteAttack(action.ActiveCharacter, action.Target);
                break;
            case ActionType.DoNothing:
                ExecuteDoNothing(action.ActiveCharacter);
                break;
            case ActionType.UseItem:
                ExecuteUseItem(action.ActiveCharacter, action.Item, action.ActiveParty);
                break;
        }
    }

    private static void ExecuteUseItem(Character activeCharacter, Item item, Party party)
    {
        ServiceLocator.Display.WriteLine($"{activeCharacter.GetName()} uses {item.Name}!");
        ItemSystem.UseItem(item: item, target: activeCharacter);
        party.RemoveItem(item);

    }

    public static void ExecuteAttack(Character activeCharacter, Character target)
    {
        ServiceLocator.Display.WriteLine($"{activeCharacter.GetName()} attacks {target.GetName()}!");
        target.TakeDamage(1);
    }

    public static void ExecuteDoNothing(Character activeCharacter)
    {
        ServiceLocator.Display.WriteLine($"{activeCharacter.GetName()} does nothing.");
    }
}