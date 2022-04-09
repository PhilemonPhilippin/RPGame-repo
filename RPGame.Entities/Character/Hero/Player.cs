namespace RPGame.Entities.Character
{
    public class Player
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
            set 
            {
                if (value < 0)
                    _health = 0;
                else
                    _health = value; 
            }
        }

        private double _mana;

        public double Mana
        {
            get { return _mana; }
            set 
            {
                if (value < 0)
                    _mana = 0;
                else
                    _mana = value; 
            }
        }
        private double _damage;

        public double Damage
        {
            get { return _damage; }
            set 
            {
                if (value < 0)
                    _damage = 0;
                else
                    _damage = value;
            }
        }
        private double _block;

        public double Block
        {
            get { return _block; }
            set 
            {
                if (value < 0)
                    _block = 0;
                else
                    _block = value;
            }
        }


        private double _experience;

        public double Experience
        {
            get { return _experience; }
            set 
            {
                if (value < 0)
                    _experience = 0;
                else
                    _experience = value; 

            }
        }
        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        private int _incarnation;

        public int Incarnation
        {
            get { return _incarnation; }
            set 
            {
                if (value < 0)
                    _incarnation = 0;
                else
                    _incarnation = value; 
            }
        }
        private int _gold;

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
    }
}
