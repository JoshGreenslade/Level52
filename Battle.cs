using Level52.Actions;
using Level52.Utils;
using Action = Level52.Actions.Action;
namespace Level52;

public class Battle
{
    private List<Party> Parties { get; set; }
    private Party ActiveParty { get; set; }
    private Character ActiveCharacter { get; set; }
    private bool BattleOngoing { get; set; }

    public Battle(List<Party> parties)
    {
        Parties = parties;
        BattleOngoing = true;
        ActiveParty = parties[0];
        ActiveCharacter = ActiveParty.Characters[0];
    }

    private void RunCharacterTurn()
    {
        ServiceLocator.Display.WriteLine($"It is {ActiveCharacter.GetName()}'s turn....");
        Action action = ActiveCharacter.GetActionStrategy().SelectAction(this);
        ActionSystem.Execute(action);
        CheckForCharacterDeath();
        ServiceLocator.Display.WriteLine();
        Thread.Sleep(250);
    }

    private void RunPartyTurn()
    {
        for (int charIndex = 0; charIndex < ActiveParty.Characters.Count; charIndex++)
        {
            ActiveCharacter = ActiveParty.Characters[charIndex];
            RunCharacterTurn();
            if (IsBattleOver())
                return;
        }
    }

    private void RunRound()
    {
        for (int partyIndex = 0; partyIndex < Parties.Count; partyIndex++)
        {
            ActiveParty = Parties[partyIndex];
            RunPartyTurn();
            if (IsBattleOver())
                return;
        }

    }

    private bool IsBattleOver()
    {
        var deadParty = Parties.FirstOrDefault(party => party.Characters.Count == 0); ;
        if (deadParty != null)
        {
            BattleOngoing = false;
            return true;
        }
        return false;
    }

    public void RunBattle()
    {
        while (BattleOngoing)
            RunRound();

    }

    public Party GetCurrentParty() => ActiveParty;
    public Character GetActiveCharacter() => ActiveCharacter;
    public Party GetActiveParty() => Parties.First(p => p == ActiveParty);
    public Party GetEnemyParty() => Parties.First(p => p != ActiveParty);

    private void CheckForCharacterDeath()
    {
        Parties.ForEach(party =>
        {
            party.SetCharacters(
                party.Characters
                    .Where(character => !character.IsDead())
                    .ToList()
            );
        });
    }

}