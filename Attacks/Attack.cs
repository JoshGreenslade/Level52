namespace Level52.Attacks;

public class Attack
{
    public string Name { get; }
    public int BaseAmount { get; }

    public Attack(string name, int baseAmount)
    {
        Name = name;
        BaseAmount = baseAmount;
    }
    
    public static readonly Func<Attack> Punch = () => new Attack(
        name: "Punch",
        baseAmount: 50
        );

    public static readonly Func<Attack> BoneCrush = () => new Attack(
        name: "BoneCrush",
        baseAmount: 1
     );
    
    public static readonly Func<Attack> Unraveling = () => new Attack(
       name: "Unraveling",
       baseAmount: 5
       );
}