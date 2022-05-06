namespace RPGame.Entities.Characters.Monsters
{
    public class Wolf : Monster
    {
        public Wolf()
        {
            Name = "Wolf";
            Stamina = CalculateStamina();
            Health = Stamina + CalculateModifier(Stamina);
            Strength = CalculateStrength();
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Fame = 15;
        }
    }
}
