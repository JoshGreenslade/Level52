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
}