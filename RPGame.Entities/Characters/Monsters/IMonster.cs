using RPGame.Entities.Characters.Heroes;

namespace RPGame.Entities.Characters.Monsters
{
    public interface IMonster : ICharacter
    {
        public int Fame { get; set; }
        public void MonsterAction(Hero hero);
        public void DisplayStats();
        public int CalculateGold();
        public int CalculateLeather();
    }
}
