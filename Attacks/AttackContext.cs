namespace Level52.Attacks;

public class AttackContext
{
    public AttackData Data;
    public Character? Attacker;
    public Character? Target;

    public AttackContext(AttackData data, Character attacker, Character target)
    {
        Data = data;
        Attacker = attacker;
        Target = target;
    }

    public AttackData GetMeta() => Data;
    public Character GetCharacter() => Attacker;
    public Character GetTarget() => Target;

}