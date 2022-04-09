using RPGame.Entities.Character.Hero;
using RPGame.Entities.Character.Monster;

namespace RPGame.Entities.Game
{
    public class Game
    {
        public void Run()
        {
            Hero hero = new Human(GetPlayerName());
            Monster wolf = new Wolf();

        }

        public string GetPlayerName()
        {
            Console.WriteLine("Welcome, adventurer. Welcome in this cruel and merciless world.");
            Console.WriteLine("You finally came out of your peaceful village.");
            Console.WriteLine("Prepare yourself to face terrible dangers and encounter terriyfing monsters."); 
            Console.WriteLine("However, if you survive long enough, you will become powerful... and rich beyond your imagination.");
            Console.WriteLine("By the way... What is your name, peasant ?");
            string name = Console.ReadLine();
            return name;
        }

    }
}
