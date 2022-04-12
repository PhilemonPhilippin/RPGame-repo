namespace RPGame.Entities.Characters.Heroes
{
    public class Human : Hero
    {
        public Human(string name)
        {
            Name = name;
            Health = 100;
            MaxHealth = Health;
            Mana = 100;
            MaxMana = Mana;
            ManaPotion = 2;
            Damage = 20;
            Block = 10;
            Experience = 0;
            Level = 1;
            Incarnation = 5;
            Gold = 15;
        }

    }
}
