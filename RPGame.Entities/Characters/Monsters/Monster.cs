using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Games;

namespace RPGame.Entities.Characters.Monsters
{
    public class Monster : Character
    {
        private int _fame;

        public int Fame
        {
            get { return _fame; }
            set { _fame = value; }
        }
        public void MonsterAction(Hero hero)
        {
            Dice dice = new Dice();
            dice.SetDiceFaces(6);
            int diceResult = dice.Roll();
            switch (diceResult)
            {
                case 1:
                    Console.WriteLine("The monster prepare a great attack. Its next attack will do more damage.");
                    DamageStack *= 2.5;
                    break;
                case 2:
                case 3:
                    Console.WriteLine("The monster will block the next attack.");
                    BlockStack += Block;
                    break;
                default :
                    Console.WriteLine("The monster performs an attack on you.");
                    if (DamageStack - hero.BlockStack > 0)
                        hero.SetHealth(hero.Health - (DamageStack - hero.BlockStack));
                    DamageStack = CalculateStrikeDamage();
                    hero.BlockStack = 0;
                    break;
            }
        }
        public void DisplayStats()
        {
            Console.WriteLine($"The monster name is {Name}, he has {Stamina} Stamina, {Health} Health, {Strength} Strength and {Block} Block.");
            Console.WriteLine($"He also has {Gold} Gold and {Leather} leather.");
        }
        public int CalculateGold()
        {
            Dice dice = new Dice();
            dice.SetDiceFaces(6);
            int gold = dice.Roll();
            return gold;
        }
        public int CalculateLeather()
        {
            Dice dice = new Dice();
            dice.SetDiceFaces(4);
            int leather = dice.Roll();
            return leather;
        }
    }
}
