namespace RPGame.Entities.Character
{
    public class Human : Player
    {
        public Human(string name)
        {
            Name = name;
            Health = 100;
            Mana = 100;
            Damage = 20;
            Block = 10;
            Experience = 0;
            Level = 1;
            Incarnation = 5;
            Gold = 15;
        }

    }
}
