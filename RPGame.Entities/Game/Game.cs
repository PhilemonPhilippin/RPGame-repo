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
            Console.WriteLine("However, if you survive long enough, you will become powerful... and rich beyond your imagination.");
            Console.WriteLine("By the way... What is your name, peasant ? ...");
            string name = Console.ReadLine();
            return name;
        }

        public void Encounter(Hero hero, Monster monster)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"You encounter a wild {monster.Name}.");
            string choice = AskFightOrRun();
            if (choice == "run")
                HasRunAway(hero, 10);
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
        public bool HasRunAway(Hero hero, int diceFaces)
        {
            bool hasRunAway = true;
            Random random = new Random();
            int dice = random.Next(1, diceFaces + 1);
            if (dice == 1)
            {
                Console.WriteLine("You turn your back, try to run away but get executed.");
                hero.Health = 0;
                hasRunAway = false;
            }
            else
                Console.WriteLine("You run away.");
            return hasRunAway;
        }
        public void Fight(Hero hero, Monster monster)
        {
            while (hero.Health != 0 && monster.Health != 0)
            {
                string heroAction = AskFightAction();
                HeroAction(hero, monster, heroAction);
                Console.WriteLine($"Monster health: {monster.Health}");
                MonsterAction(hero, monster);
                Console.WriteLine($"Hero health: {hero.Health}");
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
                Console.WriteLine("Write 'attack' to perform an attack. Write 'prepare' to prepare yourself for a great attack (damage of next attack will be bigger)");
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
                    monster.Health -= hero.Damage;
                    break;
                case "prepare":
                    Console.WriteLine("You prepare a great attack");
                    break;
                case "block":
                    Console.WriteLine("You block");
                    break;
                case "spell":
                    Console.WriteLine("You cast a spell");
                    break;
                case "potion":
                    Console.WriteLine("You drink a mana potion");
                    break;
                case "run":
                    Console.WriteLine("You try to run");
                    HasRunAway(hero, 5);
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }
        public void MonsterAction(Hero hero, Monster monster)
        {
            Random random = new Random();
            int monsterDice = random.Next(1, 4);
            if (monsterDice == 1)
            {
                Console.WriteLine("The monster will block the next attack.");
            }
            else if (monsterDice == 2)
            {
                Console.WriteLine("The monster performs an attack on you.");
                hero.Health -= monster.Damage;
            }
            else
            {
                Console.WriteLine("The monster prepare a great attack. Its next attack will do more damage.");
            }
        }

    }
}
