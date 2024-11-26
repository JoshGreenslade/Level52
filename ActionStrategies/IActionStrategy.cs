using Action = Level52.Actions.Action;
namespace Level52.ActionStrategies;

public interface IActionStrategy
{
    public Action SelectAction(Battle battle);
}