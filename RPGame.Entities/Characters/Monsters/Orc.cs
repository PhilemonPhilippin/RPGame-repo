namespace RPGame.Entities.Characters.Monsters
{
    public class Orc : Monster
    {
        public Orc()
        {
            Name = "Orc";
            SetStamina(CalculateStamina(1));
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold() + 5;
            Fame = 45;
        }
    }
}
