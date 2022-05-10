namespace RPGame.Entities.Games
{
    public class Dice
    {
        public int Minimum
        {
            get; private set;
        }
        public int Maximum
        {
            get; private set;
        }
        public void SetDiceFaces(int diceFaces)
        {
            Minimum = 1;
            Maximum = diceFaces + 1;
        }
        public int Roll()
        {
            Random random = new Random();
            int diceResult = random.Next(Minimum, Maximum);
            return diceResult;
        }

    }
}
