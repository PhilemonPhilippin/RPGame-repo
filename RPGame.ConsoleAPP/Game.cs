using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;
using RPGame.Services;

namespace RPGame.Entities.Games
{
    public class Game
    {
        // TODO:
        // Rétablir les services.
        // Refactor.
        // Considérer une interface pour l'utilisation des services.
        // Zones.
        // Weapons, Shop.
        private static List<Monster> _Monsters = new List<Monster>();
        private static char[,] area;
        public void Run()
        {
            
            area = CreateArea();
            Hero hero = GreetPlayer();
            hero.DisplayStats();
            HeroService heroService = new HeroService();
            BattleService battleService = new BattleService();


            area[0, 0] = 'H';
            hero.Xindex = 0;
            hero.Yindex = 0;
            DisplayArea();
            PopulateArea();
            DisplayArea();
            foreach (Monster monster in _Monsters)
            {
                Console.WriteLine("Monster name: " + monster.Name);
            }
            while (hero.Incarnation > 0 && _Monsters.Count > 0)
            {
                bool isThereEncounter = false;
                string monsterPosition = "";
                while (!isThereEncounter)
                {
                    hero.Move(area);
                    DisplayArea();
                    monsterPosition = CheckMonsterPosition(hero);
                    if (monsterPosition != "none")
                    {
                        isThereEncounter = true;
                    }
                }
                int monsterIndex = GetMonsterEncounteredListIndex(monsterPosition, hero);
                bool hasHeroWon = hero.Encounter(_Monsters[monsterIndex]);
                heroService.UpdateHero(hero);
                battleService.RegisterBattle(hero, _Monsters[monsterIndex], hasHeroWon);
                if (hasHeroWon)
                {
                    area[_Monsters[monsterIndex].Yindex, _Monsters[monsterIndex].Xindex] = '_';
                    _Monsters.Remove(_Monsters[monsterIndex]);
                }
                DisplayArea();
                Console.WriteLine("Liste de monstres:");
                foreach (Monster monster in _Monsters)
                {
                    Console.WriteLine("Monster name: " + monster.Name);
                }
            }



            // Ancien programme.
            //Hero hero = GreetPlayer();
            //hero.DisplayStats();
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
                hero = CreateNewHero();
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

        private Hero CreateNewHero()
        {
            string heroName = GetHeroName();
            string race = GetHeroRace(heroName);
            Hero hero = CreateHero(heroName, race);
            return hero;
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
        private void PopulateArea()
        {
            int monsterCounter = 0;
            // 1 chance sur 18 peuple souvent le tableau de 10 monstres et ils sont souvent bien repartis
            Dice dice = new Dice();
            dice.SetDiceFaces(18);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (!AreLeftBoxesPopulated(area,i,j) && !AreTopBoxesPopulated(area,i,j))
                    {
                        // On jette un dé pour voir si on crée un monstre (1 chance sur 18)
                        int roll = dice.Roll();
                        if (roll == 1 && monsterCounter < 10)
                        {
                            Monster monster = CreateMonster();
                            monster.Xindex = j;
                            monster.Yindex = i;
                            _Monsters.Add(monster);
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
        private bool AreLeftBoxesPopulated(char[,] area, int i, int j)
        {
            bool isPopulated = false;
            if (j > 1)
            {
                if (area[i, j - 1] != '_' || area[i, j - 2] != '_')
                {
                    isPopulated = true;
                }
            }
            return isPopulated;
        }
        private bool AreTopBoxesPopulated(char[,] area, int i, int j)
        {
            bool isPopulated = false;
            if (i > 1)
            {
                if (area[i - 1, j] != '_' || area[i - 2, j] != '_')
                {
                    isPopulated = true;
                }
            }
            return isPopulated;
        }
        private void DisplayArea()
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
        private string CheckMonsterPosition(Hero hero)
        {
            string horizontal = HorizontalCheckMonsterPosition(hero);
            if (horizontal != "none")
                return horizontal;

            string vertical = VerticalCheckMonsterPosition(hero);
            if (vertical != "none")
                return vertical;

            return "none";
        }
        private string HorizontalCheckMonsterPosition(Hero hero)
        {
            // Checking right box.
            if (hero.Xindex < 14)
            {
                if (area[hero.Yindex, hero.Xindex + 1] != '_')
                    return "right";
            }
            // Checking left box.
            if (hero.Xindex > 0)
            {
                if (area[hero.Yindex, hero.Xindex - 1] != '_')
                    return "left";
            }
            return "none";

        }
        private string VerticalCheckMonsterPosition(Hero hero)
        {
            // Checking down box.
            if (hero.Yindex < 14)
            {
                if (area[hero.Yindex + 1, hero.Xindex] != '_')
                    return "down";
            }
            // Checking up box.
            if (hero.Yindex > 0)
            {
                if (area[hero.Yindex - 1, hero.Xindex] != '_')
                    return "up";
            }
            return "none";
        }
        private int GetMonsterEncounteredListIndex(string monsterPosition, Hero hero)
        {
            int monsterListIndex = 0;
            switch (monsterPosition)
            {
                case "right":
                    foreach (Monster monster in _Monsters)
                    {
                        if (monster.Xindex == hero.Xindex + 1 && monster.Yindex == hero.Yindex)
                            monsterListIndex = _Monsters.IndexOf(monster);
                    }
                    break;
                case "left":
                    foreach (Monster monster in _Monsters)
                    {
                        if (monster.Xindex == hero.Xindex - 1 && monster.Yindex == hero.Yindex)
                            monsterListIndex = _Monsters.IndexOf(monster);
                    }
                    break;
                case "down":
                    foreach (Monster monster in _Monsters)
                    {
                        if (monster.Xindex == hero.Xindex && monster.Yindex == hero.Yindex + 1)
                            monsterListIndex = _Monsters.IndexOf(monster);
                    }
                    break;
                case "up":
                    foreach (Monster monster in _Monsters)
                    {
                        if (monster.Xindex == hero.Xindex && monster.Yindex == hero.Yindex - 1)
                            monsterListIndex = _Monsters.IndexOf(monster);
                    }
                    break;
                default:
                    Console.WriteLine("Pas trouvé de monstre.");
                    break;
            }
            return monsterListIndex;
        }
    }
}
