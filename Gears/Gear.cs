using Level52.Attacks;

namespace Level52.Gears;

public class Gear
{
    string Name { get; }
    Attack Attack { get; }

    public Gear(string name, Attack attack)
    {
        Name = name;
        Attack = attack;
    }

    public string GetName() => Name;
    public Attack GetAttack() => Attack;

    public static readonly Func<Gear> Dagger = () =>
        new Gear("Dagger", Attack.Stab());

    public static readonly Func<Gear> Sword = () =>
        new Gear("Sword", Attack.Slash());
}