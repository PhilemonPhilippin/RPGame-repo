namespace RPGame.Entities.Characters.Monsters
{
    public class Orc : Monster
    {
        public override double Stamina
        {
            get { return base.Stamina + 1; }
        }
        public Orc()
        {
            Name = "Orc";
            SetStamina(CalculateStamina());
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Leather = 0;
            Fame = 45;
        }
    }
}
