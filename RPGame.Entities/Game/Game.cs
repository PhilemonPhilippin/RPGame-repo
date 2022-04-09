using RPGame.Entities.Character.Hero;
using RPGame.Entities.Character.Monster;

namespace RPGame.Entities.Game
{
    public class Game
    {
        public void Run()
        {
            Hero hero = new Human(GetHeroName());
            Monster wolf = new Wolf();
            Encounter(hero, wolf);
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

        public void Encounter(Hero hero, Monster monster)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"You encounter a wild {monster.Name}.");
            string choice = AskFightOrRun();
            if (choice == "run")
                TryToRunAway(hero, 5);
            else
                Fight(hero, monster);
            Console.WriteLine("The encounter is over.");
        }
        public string AskFightOrRun()
        {
            string heroChoice;
            do
            {
                Console.WriteLine("Do you want to fight, or to try to run away? Note that if you fail to run away, you die instantly. Write 'fight' or 'run' ...");
                heroChoice = Console.ReadLine().ToLower();
            } while (heroChoice != "fight" && heroChoice != "run");
            return heroChoice;
        }
        public void TryToRunAway(Hero hero, int diceFaces)
        {
            Random random = new Random();
            int dice = random.Next(1, diceFaces + 1);
            if (dice == 1)
            {
                Console.WriteLine("You turn your back, try to run away but get executed.");
                hero.Health = 0;
            }
            else
                Console.WriteLine("You run away.");
        }
        public void Fight(Hero hero, Monster monster)
        {
            hero.DamageStack = hero.Damage;
            monster.DamageStack = monster.Damage;
            bool isHerosTurn = true;
            while (hero.Health != 0 && monster.Health != 0)
            {
                if (isHerosTurn)
                {
                    string heroAction = AskFightAction();
                    HeroAction(hero, monster, heroAction);
                    Console.WriteLine($"Monster health: {monster.Health}");
                    isHerosTurn = false;
                }
                else
                {
                    MonsterAction(hero, monster);
                    Console.WriteLine($"Hero health: {hero.Health}");
                    isHerosTurn = true;
                }
            }
        }
        public string AskFightAction()
        {
            string heroAction;
            bool isHeroActionValid;
            do
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Choose a fight action:");
                Console.WriteLine("Write 'attack' to perform an attack.");
                Console.WriteLine("Write 'prepare' to prepare yourself for a great attack (damage of next attack will be bigger)");
                Console.WriteLine("Write 'block' to block the next monster's attack.");
                Console.WriteLine("Write 'spell' to cast a spell. Or write 'potion' to drink a mana potion.");
                Console.WriteLine("Write 'run' to try to run. If you fail to run away, you die instantly ...");
                heroAction = Console.ReadLine().ToLower();
                isHeroActionValid = heroAction == "attack" || heroAction == "prepare" || heroAction == "block" || heroAction == "spell" || heroAction == "potion" || heroAction == "run";
            } while (!isHeroActionValid);
            return heroAction;
        }
        public void HeroAction(Hero hero, Monster monster, string heroAction)
        {
            switch (heroAction)
            {
                case "attack":
                    Console.WriteLine("You perform an attack");
                    if (hero.DamageStack - monster.BlockStack > 0)
                        monster.Health -= hero.DamageStack - monster.BlockStack;
                    hero.DamageStack = hero.Damage;
                    monster.BlockStack = 0;
                    break;
                case "prepare":
                    Console.WriteLine("You prepare a great attack");
                    hero.DamageStack *= 3;
                    break;
                case "block":
                    Console.WriteLine("You will block the next attack.");
                    hero.BlockStack += hero.Block;
                    break;
                case "spell":
                    Console.WriteLine("You cast a spell.");
                    break;
                case "potion":
                    Console.WriteLine("You drink a mana potion.");
                    break;
                case "run":
                    Console.WriteLine("You try to run away.");
                    TryToRunAway(hero, 3);
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }
        public void MonsterAction(Hero hero, Monster monster)
        {
            Random random = new Random();
            int dice = random.Next(1, 4);
            if (dice == 1)
            {
                Console.WriteLine("The monster will block the next attack.");
                monster.BlockStack += monster.Block;
            }
            else if (dice == 2)
            {
                Console.WriteLine("The monster performs an attack on you.");
                if (monster.DamageStack - hero.BlockStack > 0)
                    hero.Health -= monster.DamageStack - hero.BlockStack;
                monster.DamageStack = monster.Damage;
                hero.BlockStack = 0;
            }
            else
            {
                Console.WriteLine("The monster prepare a great attack. Its next attack will do more damage.");
                monster.DamageStack *= 3;
            }
        }

    }
}
