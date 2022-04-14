using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;

namespace RPGame.Entities.Games
{
    public class Game
    {
        public void Run()
        {
            Hero hero = new Human(GetHeroName());
            while (hero.Incarnation >= 0)
            {
                Monster wolf = new Wolf();
                hero.Encounter(wolf);
            }
        }

        public string GetHeroName()
        {
            Console.WriteLine("Welcome, adventurer. Welcome in this cruel and merciless world.");
            Console.WriteLine("You finally came out of your peaceful village.");
            Console.WriteLine("Prepare yourself to face terrible dangers and encounter terriyfing monsters.");
            Console.WriteLine("However, if you survive long enough, you will become powerful.. and rich beyond your imagination.");
            Console.WriteLine("By the way, what is your name, peasant ? ...");
            string name = Console.ReadLine();
            return name;
        }
    }
}
