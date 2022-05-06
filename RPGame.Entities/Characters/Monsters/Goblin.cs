namespace RPGame.Entities.Characters.Monsters
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            Stamina = CalculateStamina();
            Health = Stamina + CalculateModifier(Stamina);
            Strength = CalculateStrength() + 1;
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold() + 2;
            Fame = 30;
        }
    }
}
