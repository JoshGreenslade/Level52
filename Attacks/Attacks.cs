using Level52.Utils;

namespace Level52.Attacks;

public static class Attacks
{
    public static readonly AttackData Punch = new AttackData(
        Name: "Punch",
        CalculateBaseDamage: () => 50
        );

    public static readonly AttackData BoneCrush = new AttackData(
        Name: "Bone Crusher",
        CalculateBaseDamage: () => ServiceLocator.Rng.Next(2)
    );
    
    public static readonly AttackData Unraveling = new AttackData(
        Name: "Unraveling",
        CalculateBaseDamage: () => ServiceLocator.Rng.Next(3)
    );
}