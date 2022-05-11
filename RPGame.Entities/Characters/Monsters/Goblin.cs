namespace RPGame.Entities.Characters.Monsters
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            SetStamina(CalculateStamina());
            SetHealth(Stamina + CalculateModifier(Stamina));
            SetStrength(CalculateStrength(1));
            Damage = Strength;
            Block = CalculateBlock();
            Gold = CalculateGold();
            Leather = 0;
            Fame = 30;
        }
    }
}
