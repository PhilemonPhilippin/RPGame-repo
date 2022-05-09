namespace RPGame.Entities.Characters.Heroes
{
    public class Human : Hero
    {
        public Human(string name)
        {
            Name = name;
            CalculateStamina(1);
            MaxHealth = Stamina + CalculateModifier(Stamina);
            Health = MaxHealth;
            Mana = 100;
            MaxMana = Mana;
            ManaPotion = 2;
            CalculateStrength(1);
            Damage = Strength;
            Block = CalculateBlock();
            Experience = 0;
            Level = 1;
            Incarnation = 3;
            Gold = 6;
        }

    }
}
