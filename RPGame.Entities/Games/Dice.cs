using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void SetMinMax(int diceFaces)
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
