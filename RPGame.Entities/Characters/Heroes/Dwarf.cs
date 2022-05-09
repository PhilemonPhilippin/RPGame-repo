namespace RPGame.Entities.Characters.Heroes
{
    public class Dwarf : Hero
    {
        public Dwarf(string name)
        {
            Name = name;
            CalculateStamina(2);
            MaxHealth = Stamina + CalculateModifier(Stamina);
            Health = MaxHealth;
            Mana = 100;
            MaxMana = Mana;
            ManaPotion = 2;
            CalculateStrength();
            Damage = Strength;
            Block = CalculateBlock();
            Experience = 0;
            Level = 1;
            Incarnation = 3;
            Gold = 10;
        }

       

        

    }
}
