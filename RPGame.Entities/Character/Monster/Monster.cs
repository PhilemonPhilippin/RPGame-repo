namespace RPGame.Entities.Character.Monster
{
    public class Monster
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private double _health;

        public double Health
        {
            get { return _health; }
            set { _health = value; }
        }
        private double _damage;

        public double Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        private double _block;

        public double Block
        {
            get { return _block; }
            set { _block = value; }
        }
        private int _gold;

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }


    }
}
