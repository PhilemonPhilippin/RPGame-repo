namespace RPGame.Entities.Characters.Heroes
{
    public class Dwarf : Hero
    {
       
        public Dwarf(string name)
        {
            Race = "dwarf";
            Name = name;
            SetStamina(CalculateStamina(2));
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
