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
            dice.SetMinMax(5);
            int diceResult = dice.Roll();
            switch (diceResult)
            {
                case 1:
                    Console.WriteLine("The monster prepare a great attack. Its next attack will do more damage.");
                    this.DamageStack *= 2.5;
                    break;
                case 2:
                case 3:
                    Console.WriteLine("The monster will block the next attack.");
                    this.BlockStack += this.Block;
                    break;
                default :
                    Console.WriteLine("The monster performs an attack on you.");
                    if (this.DamageStack - hero.BlockStack > 0)
                        hero.Health -= this.DamageStack - hero.BlockStack;
                    this.DamageStack = this.CalculateStrikeDamage();
                    hero.BlockStack = 0;
                    break;
            }
        }
        public int CalculateGold()
        {
            Dice dice = new Dice();
            dice.SetMinMax(6);
            int gold = dice.Roll();
            return gold;
        }
    }
}
