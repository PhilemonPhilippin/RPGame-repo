namespace RPGame.Entities.Characters.Monsters
{
    public class Wolf : Monster
    {
        public Wolf()
        {
            Name = "Wolf";
            CalculateStamina();
            Health = Stamina + CalculateModifier(Stamina);
            CalculateStrength();
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Fame = 15;
        }
    }
}
