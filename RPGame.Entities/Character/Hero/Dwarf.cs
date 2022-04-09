namespace RPGame.Entities.Character
{
    public class Dwarf : Player
    {
        public Dwarf(string name)
        {
            Name = name;
            Health = 100;
            Mana = 100;
            Damage = 15;
            Block = 15;
            Experience = 0;
            Level = 1;
            Incarnation = 3;
            Gold = 100;
        }

    }
}
