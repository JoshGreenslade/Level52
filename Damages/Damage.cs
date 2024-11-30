namespace Level52.Damages;

public class Damage
{
    public DamageTypes Type { get; }
    public int BaseAmount { get; }

    public Damage(DamageTypes type, int baseAmount)
    {
        Type = type;
        BaseAmount = baseAmount;
    }
    
}