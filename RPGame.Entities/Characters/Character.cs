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
        private double _stamina;

        public double Stamina
        {
            get { return _stamina; }
            set 
            {
                if (value < 0)
                    _stamina = 0;
                else
                    _stamina = value; 
            }
        }

        private double _strength;

        public double Strength
        {
            get { return _strength; }
            set 
            {
                if (value < 0)
                    _strength = 0;
                else
                    _strength = value; 
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

        public double CalculateStamina()
        {
            int[] diceResults = new int[4];
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int diceResult = random.Next(1, 7);
                diceResults[i] = diceResult;
            }
            for (int i = 1; i < diceResults.Length; i++)
            {
                if (diceResults[0] > diceResults[i])
                {
                    int temp = diceResults[0];
                    diceResults[0] = diceResults[i];
                    diceResults[i] = temp;
                }
            }
            double stamina = diceResults[1] + diceResults[2] + diceResults[3];
            return stamina;
        }

        public double CalculateStrength()
        {
            int[] diceResults = new int[4];
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int diceResult = random.Next(1, 7);
                diceResults[i] = diceResult;
            }
            for (int i = 1; i < diceResults.Length; i++)
            {
                if (diceResults[0] > diceResults[i])
                {
                    int temp = diceResults[0];
                    diceResults[0] = diceResults[i];
                    diceResults[i] = temp;
                }
            }
            double strength = diceResults[1] + diceResults[2] + diceResults[3];
            return strength;
        }

        public double CalculateModifier(double stat)
        {
            double modifier;
            if (stat < 5)
                modifier = -1;
            else if (stat < 10)
                modifier = 0;
            else if (stat < 15)
                modifier = 1;
            else
                modifier = 2;
            return modifier;
        }
        public double CalculateStrikeDamage()
        {
            Random random = new Random();
            int dice = random.Next(1, 5);
            double strikeDamage = dice + CalculateModifier(this.Strength);
            return strikeDamage;
        }
        public double CalculateBlock()
        {
            Random random = new Random();
            double block = random.Next(1, 6);
            return block;
        }
    }
}
