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
            private set { _stamina = value; }
        }
        public double SetStamina(double value)
        {
            if (value < 0)
                Stamina = 0;
            else
                Stamina = value;
            return Stamina;
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
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetMinMax(6);
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
        public double CalculateStamina(int bonus)
        {
            int[] diceResults = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetMinMax(6);
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
            double stamina = diceResults[1] + diceResults[2] + diceResults[3] + bonus;
            return stamina;
        }

        public void CalculateStrength()
        {
            int[] diceResults = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetMinMax(6);
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
            Strength = strength;
        }
        public void CalculateStrength(int bonus)
        {
            int[] diceResults = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Dice diceSix = new Dice();
                diceSix.SetMinMax(6);
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
            Strength = strength + bonus;
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
            diceFour.SetMinMax(4);
            int diceResult = diceFour.Roll();
            double strikeDamage = diceResult + CalculateModifier(this.Strength);
            return strikeDamage;
        }
        public double CalculateBlock()
        {
            Dice diceFive = new Dice();
            diceFive.SetMinMax(5);
            double block = diceFive.Roll();
            return block;
        }
    }
}
