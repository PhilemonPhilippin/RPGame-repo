using RPGame.Entities.Characters.Heroes;
namespace RPGame.Entities.Characters.Monsters
{
    public class Monster : Character
    {
        public void MonsterAction(Hero hero)
        {
            Random random = new Random();
            int dice = random.Next(1, 4);
            if (dice == 1)
            {
                Console.WriteLine("The monster will block the next attack.");
                this.BlockStack += this.Block;
            }
            else if (dice == 2)
            {
                Console.WriteLine("The monster performs an attack on you.");
                if (this.DamageStack - hero.BlockStack > 0)
                    hero.Health -= this.DamageStack - hero.BlockStack;
                this.DamageStack = this.Damage;
                hero.BlockStack = 0;
            }
            else
            {
                Console.WriteLine("The monster prepare a great attack. Its next attack will do more damage.");
                this.DamageStack *= 2.5;
            }
        }
    }
}
