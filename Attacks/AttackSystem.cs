using Level52.Damages;
using Level52.Utils;

namespace Level52.Attacks;

public static class AttackSystem
{
    public static void ExecuteAttack(Character activeCharacter, Character target, Attack attack)
    {
        var baseAmount = attack.BaseAmount;
        var damage = new Damage(
            type: DamageTypes.Brute,
            baseAmount: attack.BaseAmount
        );
        target.TakeDamage(damage.BaseAmount);

        ServiceLocator.Display.WriteLine($"{activeCharacter.GetName()} used {attack.Name} on {target.GetName()}!");
        ServiceLocator.Display.WriteLine($"{target.GetName()} took {damage.BaseAmount} damage! {target.GetHp()}/{target.GetMaxHp()}");
    }

    public static List<Attack> GetAttacks(Character activeCharacter) => activeCharacter.Attacks;

    public static void AddAttack(Character activeCharacter, Attack attack)
    {
        if (!GetAttacks(activeCharacter).Contains(attack))
            activeCharacter.Attacks.Add(attack);
    }

    public static void RemoveAttack(Character activeCharacter, Attack attack)
    {
        if (GetAttacks(activeCharacter).Contains(attack))
            activeCharacter.Attacks.Remove(attack);
    }
}