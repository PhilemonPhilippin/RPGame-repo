using RPGame.Entities.Games;

namespace RPGame.Entities.Characters
{
    public abstract class Character : ICharacter
    {
        public int Xindex { get; set; }
        public int Yindex { get; set; }

        public string Name { get; set; }
        public double Health { get; set; }
        public void SetHealth(double value)
        {
            if (value < 0)
                Health = 0;
            else
                Health = value;
        }
        public virtual double Stamina { get; set; }
        public void SetStamina(double value)
        {
            if (value < 0)
                Stamina = 0;
            else
                Stamina = value;
        }

       public virtual double Strength { get; set; }
        public void SetStrength(double value)
        {
            if (value < 0)
                Strength = 0;
            else
                Strength = value;
        }

        public double Damage { get; set; }
        public double Block { get; set; }

        public double DamageStack { get; set; }
        public double BlockStack { get; set; }

        public int Gold { get; set; }
        public int Leather { get; set; }

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
