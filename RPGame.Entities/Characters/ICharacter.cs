namespace RPGame.Entities.Characters
{
    public interface ICharacter
    {
        public int Xindex { get; set; }
        public int Yindex { get; set; }

        public string Name { get; set; }
        public double Health { get; set; }
        public void SetHealth(double value);
        public double Stamina { get; set; }
        public void SetStamina(double value)
        {
            if (value < 0)
                Stamina = 0;
            else
                Stamina = value;
        }

        public double Strength { get; set; }
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

        public double CalculateStamina();

        public double CalculateStrength();

        public double CalculateModifier(double stat);
        public double CalculateStrikeDamage();
        public double CalculateBlock();
    }
}
