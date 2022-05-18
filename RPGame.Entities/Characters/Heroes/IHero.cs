using RPGame.Entities.Characters.Monsters;

namespace RPGame.Entities.Characters.Heroes
{
    public interface IHero : ICharacter
    {
        public int Id { get; set; }

        public string Race { get; set; }

        public double MaxHealth { get; set; }
        public void SetMaxHealth(double value);

        public double Mana { get; set; }

        public double MaxMana { get; set; }
        public int ManaPotion { get; set; }

        public double Experience { get; set; }
        public int Level { get; set; }
        public int Incarnation { get; set; }
        public void DisplayStats();
        public bool Encounter(IMonster monster);
        public string AskFightOrRun();
        public void TryToRunAway(int diceFaces);
        public void Fight(IMonster monster);
        public string AskFightAction();
        public void CastSpell();
        public void Heal();
        public void DrinkManaPotion();
        public void HeroAction(IMonster monster, string heroAction);
        public void LevelUp();
    }
}
