namespace RPGame.Entities.Characters.Monsters
{
    public class DragonWhelp : Monster
    {
        public override double Stamina
        {
            get { return base.Stamina + 1; }
        }
        public override double Strength
        {
            get { return base.Strength + 1; }
        }
        public DragonWhelp()
        {
            Name = "DragonWhelp";
            SetStamina(CalculateStamina());
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Leather = CalculateLeather();
            Fame = 60;
        }
        

    }
}
