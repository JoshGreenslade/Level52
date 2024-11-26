using Level52.Actions;
using Action = Level52.Actions.Action;

namespace Level52.ActionStrategies;

public class DoNothingStrategy : IActionStrategy
{
    public Action SelectAction(Battle battle)
    {
        return new Action(type: ActionType.DoNothing);
    }
}