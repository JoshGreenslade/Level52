using Level52.Actions;
using Level52.ActionStrategies;
using Level52.Attacks;
using Level52.Gears;

namespace Level52;

public class Character
{
    private string Name { get; set; }
    public List<ActionType> Actions;
    public List<Attack> Attacks;
    public Gear? EquipedGear;
    private IActionStrategy _actionStrategy;
    private int _maxHp = 1;
    private int _hp = 1;

    public Character(string name,
        IActionStrategy? actionStrategy = null,
        List<ActionType>? actions = null,
        List<Attack>? attacks = null,
        Gear? equipedGear = null,
        int maxHp = 1)
    {
        Name = name;
        _actionStrategy = actionStrategy ?? new DoNothingStrategy();
        Actions = actions ?? new List<ActionType> { ActionType.DoNothing, ActionType.Attack };
        Attacks = attacks ?? new List<Attack> { };
        EquipedGear = equipedGear;
        _maxHp = maxHp;
        _hp = _maxHp;
    }

    public string GetName() => Name;
    public List<ActionType> GetActions() => Actions;
    public IActionStrategy GetActionStrategy() => _actionStrategy;
    public void SetPlayerControlled() => _actionStrategy = new PlayerStrategy();
    public void SetActions(List<ActionType> actions) => Actions = actions;

    public int GetHp() => _hp;
    public int GetMaxHp() => _maxHp;
    public void SetHp(int hp) => _hp = hp;
    public void TakeDamage(int amount) => _hp = Math.Max(_hp - amount, 0);
    public void AddHealth(int health) => _hp = Math.Min(_hp + health, _maxHp);
    public bool IsDead() => _hp == 0;
    public void SetName(string name) => Name = name;

}