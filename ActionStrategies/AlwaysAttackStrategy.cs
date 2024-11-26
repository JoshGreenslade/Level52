using Level52.Actions;
using Action = Level52.Actions.Action;

namespace Level52.ActionStrategies;

public class AlwaysAttackStrategy : IActionStrategy
{
    public Action SelectAction(Battle battle)
    {
        return new Action(
            type: ActionType.Attack,
            activeCharacter: battle.GetActiveCharacter(),
            target: battle.GetEnemyParty().Characters[0]
        );
    }
}