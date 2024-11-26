using Level52.Actions;
using Level52.ActionStrategies;
using Level52.Attacks;

namespace Level52;

public class Character
{
    private string Name { get; set; }
    public List<ActionType> Actions;
    public List<AttackData> Attacks;
    private IActionStrategy _actionStrategy;
    private int _maxHp = 1;
    private int _hp = 1;

    public Character(string name,
        IActionStrategy? actionStrategy = null,
        List<ActionType>? actions = null,
        List<AttackData>? attacks = null,
        int maxHp = 1)
    {
        Name = name;
        _actionStrategy = actionStrategy ?? new DoNothingStrategy();
        Actions = actions ?? new List<ActionType> { ActionType.DoNothing, ActionType.Attack };
        Attacks = attacks ?? new List<AttackData> { };
        _maxHp = maxHp;
        _hp = _maxHp;
    }

    public string GetName() => Name;
    public List<ActionType> GetActions() => Actions;
    public List<AttackData> GetAttacks() => Attacks;
    public IActionStrategy GetActionStrategy() => _actionStrategy;
    public void SetPlayerControlled() => _actionStrategy = new PlayerStrategy();
    public void SetActions(List<ActionType> actions) => Actions = actions;
    public void SetAttacks(List<AttackData> attacks) => Attacks = attacks;

    public int GetHp() => _hp;
    public int GetMaxHp() => _maxHp;
    public void SetHp(int hp) => _hp = hp;
    public void TakeDamage(int damage) => _hp = Math.Max(_hp - damage, 0);
    public void AddHealth(int health) => _hp = Math.Min(_hp + health, _maxHp);
    public bool IsDead() => _hp == 0;
    public void SetName(string name) => Name = name;

}