namespace RPGame.Entities.Characters
{
    public class Character
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

        private double _damageStack;
        public double DamageStack
        {
            get { return _damageStack; }
            set
            {
                if (value < 0)
                    _damageStack = 0;
                else
                    _damageStack = value;
            }
        }
        private double _blockStack;

        public double BlockStack
        {
            get { return _blockStack; }
            set
            {
                if (value < 0)
                    _blockStack = 0;
                else
                    _blockStack = value;
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
