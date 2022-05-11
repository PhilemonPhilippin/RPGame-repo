namespace RPGame.Entities.Characters.Monsters
{
    public class Wolf : Monster
    {
        public Wolf()
        {
            Name = "Wolf";
            SetStamina(CalculateStamina());
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Gold = 0;
            Leather = CalculateLeather();
            Fame = 15;
        }
    }
}
