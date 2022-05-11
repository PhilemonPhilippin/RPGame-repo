namespace RPGame.Entities.Characters.Heroes
{
    public class Human : Hero
    {
        public override double Strength
        {
            get { return base.Strength + 1; }
        }
        public override double Stamina
        {
            get { return base.Stamina + 1; }
        }
        public Human(string name)
        {
            Race = "human";
            Name = name;
            SetStamina(CalculateStamina());
            SetMaxHealth(Stamina + CalculateModifier(Stamina));
            SetHealth(MaxHealth);
            Mana = 100;
            MaxMana = Mana;
            ManaPotion = 2;
            SetStrength(CalculateStrength());
            Damage = Strength;
            Block = CalculateBlock();
            Experience = 0;
            Level = 1;
            Incarnation = 3;
            Gold = 0;
            Leather = 0;
        }

    }
}
