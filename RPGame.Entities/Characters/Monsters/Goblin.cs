namespace RPGame.Entities.Characters.Monsters
{
    public class Goblin : Monster
    {
        public override double Strength
        {
            get { return base.Strength + 1; }
        }
        public Goblin()
        {
            Name = "Goblin";
            SetStamina(CalculateStamina());
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Leather = 0;
            Fame = 30;
        }
    }
}
