using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;
using RPGame.Services;

namespace RPGame.Entities.Games
{
    public class Game
    {
        //TODO: Zones
        //Weapons, Shop
        //Refactor
        public void Run()
        {
            //Hero hero = GreetPlayer();
            //hero.DisplayStats();
            List<Monster> monsters = new List<Monster>();
            char[,] area = CreateArea();
            DisplayArea(area);
            PopulateArea(area, monsters);
            DisplayArea(area);
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("Monster name: " + monster.Name);
            }
            //HeroService heroService = new HeroService();
            //BattleService battleService = new BattleService();
            //while (hero.Incarnation > 0)
            //{
            //    Monster monster = CreateMonster();
            //    bool hasHeroWon = hero.Encounter(monster);
            //    heroService.UpdateHero(hero);
            //    battleService.RegisterBattle(hero, monster, hasHeroWon);
            //}
        }


        private Hero GreetPlayer()
        {
            Console.WriteLine("Hello. Do you want to create a new hero or to load a saved one ?");
            string answer = "";
            do
            {
                Console.WriteLine("Write 'new' or 'load'...");
                answer = Console.ReadLine();
            } while (answer != "new" && answer != "load");
            Hero hero;
            if (answer == "new")
                hero = CreateHero();
            else
                hero = LoadHero();
            return hero;
        }
        private Hero LoadHero()
        {
            Hero hero;
            bool isHeroFound = false;
            do
            {
                Console.WriteLine("You want to load a saved hero. Here is the list of all saved heroes with their ID.");
                HeroService service = new HeroService();
                service.DisplayHeroes();
                int id;
                bool isParsed = false;
                do
                {
                    Console.WriteLine("What is the ID of your hero ?...");
                    isParsed = int.TryParse(Console.ReadLine(), out id);
                } while (!isParsed);
                hero = service.GetHero(id);
                if (hero.Name is not null)
                    isHeroFound = true;
            } while (!isHeroFound);
            return hero;
        }

        private Hero CreateHero()
        {
            string heroName = GetHeroName();
            string race = GetHeroRace(heroName);
            Hero hero = CreateHero(heroName, race);
            return hero;
        }
        private string GetHeroName()
        {
            Console.WriteLine("Welcome, adventurer. Welcome in this cruel and merciless world.");
            Console.WriteLine("You finally came out of your peaceful village.");
            Console.WriteLine("Prepare yourself to face terrible dangers and encounter terrifying monsters.");
            Console.WriteLine("However, if you survive long enough, you will become powerful, and rich beyond your imagination.");
            Console.WriteLine("By the way, what is your name ?...");
            string name = Console.ReadLine();
            return name;
        }
        private string GetHeroRace(string name)
        {
            Console.WriteLine($"Welcome {name}. Where are you from ?");
            Console.WriteLine("Did you dig your way from the harsh mountains to come here, or do you come from the quiet and peaceful plains?");
            string race;
            do
            {
                Console.WriteLine("Write 'dwarf' if you are a dwarf or 'human' if you are a human...");
                race = Console.ReadLine().ToLower();
            } while (race != "dwarf" && race != "human");
            return race;
        }
        private Hero CreateHero(string heroName, string race)
        {
            Hero hero;
            if (race == "dwarf")
                hero = new Dwarf(heroName);
            else
                hero = new Human(heroName);
            HeroService service = new HeroService();
            service.InsertHero(hero);
            return hero;
        }

        private Monster CreateMonster()
        {
            Monster monster;
            Dice dice = new Dice();
            dice.SetDiceFaces(6);
            int diceResult = dice.Roll();
            switch (diceResult)
            {
                case 1:
                    monster = new DragonWhelp();
                    break;
                case 2:
                    monster = new Orc();
                    break;
                case 3:
                case 4:
                    monster = new Goblin();
                    break;
                default:
                    monster = new Wolf();
                    break;
            }
            return monster;
        }
        private char[,] CreateArea()
        {
            char[,] area = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    area[i, j] = '_';
                }
            }
            return area;
        }
        private void PopulateArea(char[,] area, List<Monster> monsters)
        {
            int monsterCounter = 0;
            // 1 chance sur 18 peuple souvent le tableau de 10 monstres et ils sont souvent bien repartis
            Dice dice = new Dice();
            dice.SetDiceFaces(18);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (!IsThereMonsterLeftSide(area,i,j) && !IsThereMonsterTopSide(area,i,j))
                    {
                        // On jette un dé pour voir si on crée un monstre (1 chance sur 18)
                        int roll = dice.Roll();
                        if (roll == 1 && monsterCounter < 10)
                        {
                            Monster monster = CreateMonster();
                            monster.Xindex = j;
                            monster.Yindex = i;
                            monsters.Add(monster);
                            switch (monster)
                            {
                                case Wolf:
                                    area[i, j] = 'W';
                                    break;
                                case Goblin:
                                    area[i, j] = 'G';
                                    break;
                                case Orc:
                                    area[i, j] = 'O';
                                    break;
                                default:
                                    area[i, j] = 'D';
                                    break;
                            }
                            monsterCounter++;
                        }
                    }
                }
            }
            

        }
        private bool IsThereMonsterLeftSide(char[,] area, int i, int j)
        {
            bool isThereMonster = false;
            if (j > 1)
            {
                if (area[i, j - 1] != '_' || area[i, j - 2] != '_')
                {
                    isThereMonster = true;
                }
            }
            return isThereMonster;
        }
        private bool IsThereMonsterTopSide(char[,] area, int i, int j)
        {
            bool isThereMonster = false;
            if (i > 1)
            {
                if (area[i - 1, j] != '_' || area[i - 2, j] != '_')
                {
                    isThereMonster = true;
                }
            }
            return isThereMonster;
        }

        private bool AreAllMonstersDead()
        {
            bool areAllMonstersDead = false;
            // Vérifier que tous les monstres sont morts
            return areAllMonstersDead;
        }
        private void DisplayArea(char[,] area)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(area[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
