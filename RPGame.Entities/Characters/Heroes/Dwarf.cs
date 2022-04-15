namespace RPGame.Entities.Characters.Heroes
{
    public class Dwarf : Hero
    {
        public Dwarf(string name)
        {
            Name = name;
            Health = 100;
            MaxHealth = Health;
            Mana = 100;
            MaxMana = Mana;
            ManaPotion = 2;
            Damage = 15;
            Block = 20;
            Experience = 0;
            Level = 1;
            Incarnation = 3;
            Gold = 100;
        }

    }
}
