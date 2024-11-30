using Level52.Actions;
using Level52.ActionStrategies;
using Level52.Attacks;
using Level52.Items;
using Level52.Utils;

namespace Level52;

public class Game
{
    public Party HeroParty { get; }
    public Party MonsterParty1 { get; }
    public Party MonsterParty2 { get; }
    public Party BossParty { get; }

    public Game()
    {

        HeroParty = new Party();
        MonsterParty1 = new Party();
        MonsterParty2 = new Party();
        BossParty = new Party();

        var monster1 = Monsters.CreateSkeleton();
        var monster2 = Monsters.CreateSkeleton();
        var monster3 = Monsters.CreateSkeleton();
        var boss = Monsters.CreateUncodedOne();

        ServiceLocator.Display.Write("Pick a name...");
        var playerName = ServiceLocator.UserInput.GetInput();
        var playerCharacter = Monsters.CreatePlayer();
        playerCharacter.SetName(playerName);

        HeroParty.AddCharacter(playerCharacter);
        MonsterParty1.AddCharacter(monster1);
        MonsterParty2.AddCharacter(monster2);
        MonsterParty2.AddCharacter(monster3);
        BossParty.AddCharacter(boss);

        HeroParty.SetPlayerControlled();

        HeroParty.AddItem(Item.HealingPotion());
        HeroParty.AddItem(Item.HealingPotion());
        HeroParty.AddItem(Item.HealingPotion());
    }

    private void CheckLoseCondition()
    {
        if (HeroParty.Characters.Count == 0)
        {
            ServiceLocator.Display.WriteLine("The Heros lost and the uncoded ones forces have prevailed...");
        }
    }

    public void Run()
    {
        var partyList = new List<Party> { HeroParty, MonsterParty1 };
        Battle battle = new Battle(partyList);
        battle.RunBattle();
        CheckLoseCondition();

        partyList.Remove(MonsterParty1);
        partyList.Add(MonsterParty2);
        battle = new Battle(partyList);
        battle.RunBattle();
        CheckLoseCondition();

        partyList.Remove(MonsterParty2);
        partyList.Add(BossParty); battle = new Battle(partyList);
        battle.RunBattle();
        CheckLoseCondition();
    }
}