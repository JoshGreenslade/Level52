namespace Level52.Attacks;

public record AttackData
(
    Func<int> CalculateBaseDamage, 
    string Name = "Attack"
    );