using RPGame.Entities.Games;

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
            private set
            {
                _health = value;
            }
        }
        public void SetHealth(double value)
        {
            if (value < 0)
                Health = 0;
            else
                Health = value;
        }
        private double _stamina;

        public virtual double Stamina
        {
            get { return _stamina; }
            private set { _stamina = value; }
        }
        public void SetStamina(double value)
        {
            if (value < 0)
                Stamina = 0;
            else
                Stamina = value;
        }

        private double _strength;

        public virtual double Strength
        {
            get { return _strength; }
            private set 
            {
                _strength = value;
            }
        }
        public void SetStrength(double value)
        {
            if (value < 0)
                Strength = 0;
            else
                Strength = value;
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
        private int _leather;
        public int Leather
        {
            get { return _leather; }
            set { _leather = value; }
        }

        public double CalculateStamina()
        {
            int[] diceResults = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetDiceFaces(6);
                diceResults[i] = diceSix.Roll();
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
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetDiceFaces(6);
                diceResults[i] = diceSix.Roll();
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
            Dice diceFour = new Dice();
            diceFour.SetDiceFaces(4);
            int diceResult = diceFour.Roll();
            double strikeDamage = diceResult + CalculateModifier(Strength);
            return strikeDamage;
        }
        public double CalculateBlock()
        {
            Dice diceFive = new Dice();
            diceFive.SetDiceFaces(5);
            double block = diceFive.Roll();
            return block;
        }
    }
}
