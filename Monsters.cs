using Level52.ActionStrategies;
using Level52.Attacks;

namespace Level52.Actions;

public static class Monsters
{
    public static Character CreateSkeleton()
    {
        return new Character(
            name: "Skeleton",
            maxHp: 5,
            actionStrategy: new AlwaysAttackStrategy(),
            attacks: new List<AttackData> { Attacks.Attacks.BoneCrush },
            actions: new List<ActionType> { ActionType.Attack, ActionType.DoNothing }
        );
    }
    
    public static Character CreatePlayer()
    {
        return new Character(
            name: "True Programmer",
            maxHp: 25,
            attacks: new List<AttackData> { Attacks.Attacks.Punch },
            actions: new List<ActionType> { ActionType.Attack, ActionType.DoNothing }
        );
    }
    
    public static Character CreateUncodedOne()
    {
        return new Character(
            name: "Uncoded One",
            maxHp: 15,
            actionStrategy: new AlwaysAttackStrategy(),
            attacks: new List<AttackData> { Attacks.Attacks.Unraveling },
            actions: new List<ActionType> { ActionType.Attack, ActionType.DoNothing }
        );
    }
}