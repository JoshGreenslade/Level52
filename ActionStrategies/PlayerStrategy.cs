using Level52.Actions;
using Level52.Attacks;
using Level52.Items;
using Level52.Utils;
using Action = Level52.Actions.Action;

namespace Level52.ActionStrategies;

public class PlayerStrategy : IActionStrategy
{
    public Action SelectAction(Battle battle)
    {
        ServiceLocator.Display.WriteLine("1) Attack, 2) Use Item, 3) Do nothing");
        string input = ServiceLocator.UserInput.GetInput();

        return input switch
        {
            "1" => AttackAction(battle),
            "2" => UseItemAction(battle),
            "3" => DoNothingAction(battle),
            _ => DoNothingAction(battle)
        };
    }

    private Action AttackAction(Battle battle)
    {
        Character target = SelectTarget(battle);
        Attack attack = SelectAttack(battle);
        return Action.CreateAttackAction(battle.GetActiveCharacter(), target, attack);
    }

    private Action UseItemAction(Battle battle)
    {
        Item item = SelectItem(battle);
        return Action.CreateUseItemAction(battle.GetActiveCharacter(), item, battle.GetActiveParty());
    }

    private Action DoNothingAction(Battle battle)
    {
        return Action.CreateDoNothingAction(battle.GetActiveCharacter());
    }

    private Attack SelectAttack(Battle battle)
    {
        var activeCharacter = battle.GetActiveCharacter();
        var attacks = activeCharacter.GetAttacks();
        while (true)
        {
            var attackIndex = 1;
            ServiceLocator.Display.WriteLine("Choose an Attack");
            foreach (var attack in attacks)
            {
                ServiceLocator.Display.WriteLine($"{attackIndex}) - {attack.Name}");
                attackIndex++;
            }

            var choice = ServiceLocator.UserInput.GetInput();
            if (int.TryParse(choice, out int selectedIndex) &&
                selectedIndex > 0 &&
                selectedIndex <= attacks.Count)
            {
                var chosenAction = attacks[selectedIndex - 1];
                return chosenAction;
            }

            ServiceLocator.Display.WriteLine("Invalid Choice");
            ServiceLocator.Display.WriteLine();
        }
    }

    private Character SelectTarget(Battle battle)
    {
        var enemyParty = battle.GetEnemyParty();
        var targets = enemyParty.GetCharacters();
        while (true)
        {
            var targetIndex = 1;
            ServiceLocator.Display.WriteLine("Choose a Target");
            foreach (var target in targets)
            {
                ServiceLocator.Display.WriteLine($"{targetIndex}) - {target.GetName()}");
                targetIndex++;
            }

            var choice = ServiceLocator.UserInput.GetInput();
            if (int.TryParse(choice, out int selectedIndex) &&
                selectedIndex > 0 &&
                selectedIndex <= targets.Count)
            {
                var chosenAction = targets[selectedIndex - 1];
                return chosenAction;
            }

            ServiceLocator.Display.WriteLine("Invalid Choice");
            ServiceLocator.Display.WriteLine();
        }
    }

    private Item SelectItem(Battle battle)
    {
        var inventory = battle.GetActiveParty().GetInventory();
        while (true)
        {
            var index = 1;
            ServiceLocator.Display.WriteLine("Choose an item");
            foreach (var item in inventory)
            {
                ServiceLocator.Display.WriteLine($"{index}) - {item.Name}");
                index++;
            }

            var choice = ServiceLocator.UserInput.GetInput();
            if (int.TryParse(choice, out int selectedIndex) &&
                selectedIndex > 0 &&
                selectedIndex <= inventory.Count)
            {
                var chosenItem = inventory[selectedIndex - 1];
                return chosenItem;
            }

            ServiceLocator.Display.WriteLine("Invalid Choice");
            ServiceLocator.Display.WriteLine();
        }
    }
}