namespace RPGame.Entities.Characters.Monsters
{
    public class DragonWhelp : Monster
    {
        public DragonWhelp()
        {
            Name = "DragonWhelp";
            SetStamina(CalculateStamina(1));
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength(1));
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Leather = CalculateLeather();
            Fame = 60;
        }
        

    }
}
