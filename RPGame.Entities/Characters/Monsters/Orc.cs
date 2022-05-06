namespace RPGame.Entities.Characters.Monsters
{
    public class Orc : Monster
    {
        public Orc()
        {
            Name = "Orc";
            Stamina = CalculateStamina() + 1;
            Health = Stamina + CalculateModifier(Stamina);
            Strength = CalculateStrength();
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold() + 5;
            Fame = 45;
        }
    }
}
