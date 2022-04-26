using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;

namespace RPGame.Entities.Games
{
    public class Game
    {
        //TODO: Zones, Weapons, Shop
        public void Run()
        {
            string heroName = GetHeroName();
            bool isDwarf = GetHeroRace(heroName);
            Hero hero = CreateHero(heroName, isDwarf) ;
            while (hero.Incarnation >= 0)
            {
                Monster monster = CreateMonster();
                hero.Encounter(monster);
            }
        }
        private string GetHeroName()
        {
            Console.WriteLine("Welcome, adventurer. Welcome in this cruel and merciless world.");
            Console.WriteLine("You finally came out of your peaceful village.");
            Console.WriteLine("Prepare yourself to face terrible dangers and encounter terriyfing monsters.");
            Console.WriteLine("However, if you survive long enough, you will become powerful, and rich beyond your imagination.");
            Console.WriteLine("By the way, what is your name, peasant ?...");
            string name = Console.ReadLine();
            return name;
        }
        private bool GetHeroRace(string name)
        {
            bool isDwarf = false;
            Console.WriteLine($"Welcome {name}. Where are you from ?");
            Console.WriteLine("Did you dig your way from the harsh mountains to come here, or do you come from the quiet and peaceful plains?");
            string race;
            do
            {
                Console.WriteLine("Write 'dwarf' if you are a dwarf or 'human' if you are a human...");
                race = Console.ReadLine().ToLower();
            } while (race != "dwarf" && race != "human");
            if (race == "dwarf")
                isDwarf = true;
            return isDwarf;
        }
        private Hero CreateHero(string heroName, bool isDwarf)
        {
            Hero hero;
            if (isDwarf)
                hero = new Dwarf(heroName);
            else
                hero = new Human(heroName);
            return hero;
        }

        private Monster CreateMonster()
        {
            Monster monster;
            Random random = new Random();
            int dice = random.Next(1, 7);
            if (dice == 6)
                monster = new Orc();
            else if (dice >= 4)
                monster = new Goblin();
            else
                monster = new Wolf();
            return monster;
        }
    }
}
