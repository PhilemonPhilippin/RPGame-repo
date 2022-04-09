namespace RPGame.Entities.Character.Hero
{
    public class Hero : Character
    {
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
    }
}
