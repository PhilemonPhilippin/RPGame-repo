using RPGame.Entities.Characters.Monsters;
using RPGame.Entities.Games;

namespace RPGame.Entities.Characters.Heroes
{
    public class Hero : Character
    {
        public int Id { get; set; }

        public string Race { get; set; }

        private double _maxHealth;

        public double MaxHealth
        {
            get { return _maxHealth; }
            private set 
            {
                _maxHealth = value; 
            }
        }
        public void SetMaxHealth(double value)
        {
            if (value < 0)
                MaxHealth = 0;
            else
                MaxHealth = value;
        }
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
        private double _maxMana;

        public double MaxMana
        {
            get { return _maxMana; }
            set 
            {
                if (value < 0)
                    _maxMana = 0;
                else
                    _maxMana = value; 
            }
        }
        private int _manaPotion;

        public int ManaPotion
        {
            get { return _manaPotion; }
            set 
            {
                if (value < 0)
                    _manaPotion = 0;
                else
                    _manaPotion = value; 
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
                if (value < -1)
                    _incarnation = -1;
                else
                    _incarnation = value; 
            }
        }

        public bool Encounter(Monster monster)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"You encounter a wild {monster.Name}.");
            string choice = AskFightOrRun();
            if (choice == "run")
                TryToRunAway(5);
            else
                Fight(monster);

            bool hasHeroWon = false;
            if (monster.Health == 0)
            {
                Console.WriteLine("You have slain the monster.");
                hasHeroWon = true;
                Gold += monster.Gold;
                Experience += monster.Fame;
                LevelUp();
                SetHealth(MaxHealth);
                Mana = MaxMana;
                Console.WriteLine($"Your Health: {Health}, your mana: {Mana}, your gold: {Gold}, your XP: {Experience}, your lvl: {Level}");
            }
            else if (this.Health == 0)
            {
                Console.WriteLine("The monster destroyed you.");
                hasHeroWon = false;
                Incarnation--;
                SetHealth(MaxHealth);
                Mana = MaxMana;
                Console.WriteLine($"You have {Incarnation} incarnation left.");
                Console.WriteLine($"Your Health: {Health}, your mana: {Mana}, your gold: {Gold}, your XP: {Experience}, your lvl: {Level}");
            }
            Console.WriteLine("The encounter is over.");
            return hasHeroWon;
        }
        private string AskFightOrRun()
        {
            string heroChoice;
            do
            {
                Console.WriteLine("Do you want to fight, or to try to run away? Note that if you fail to run away, you die instantly.");
                Console.WriteLine("Write 'fight' or 'run'...");
                heroChoice = Console.ReadLine().ToLower();
            } while (heroChoice != "fight" && heroChoice != "run");
            return heroChoice;
        }
        private void TryToRunAway(int diceFaces)
        {
            Dice dice = new Dice();
            dice.SetMinMax(diceFaces);
            int diceResult = dice.Roll();
            if (diceResult == 1)
            {
                Console.WriteLine("You turn your back, try to run away but get executed.");
                SetHealth(0);
            }
            else
                Console.WriteLine("You run away.");
        }
        private void Fight(Monster monster)
        {
            DamageStack = CalculateStrikeDamage();
            monster.DamageStack = monster.CalculateStrikeDamage();
            bool isHerosTurn = true;
            while (Health != 0 && monster.Health != 0)
            {
                if (isHerosTurn)
                {
                    string heroAction = AskFightAction();
                    HeroAction(monster, heroAction);
                    Console.WriteLine($"Monster health: {monster.Health}");
                    isHerosTurn = false;
                }
                else
                {
                    monster.MonsterAction(this);
                    Console.WriteLine($"Hero health: {Health}");
                    isHerosTurn = true;
                }
            }
        }
        private string AskFightAction()
        {
            string heroAction;
            bool isHeroActionValid;
            do
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Choose a fight action:");
                Console.WriteLine("Write 'attack' to perform an attack.");
                Console.WriteLine("Write 'prepare' to prepare yourself for a great attack.");
                Console.WriteLine("Write 'block' to block the next monster's attack.");
                Console.WriteLine("Write 'spell' to cast a spell. Or write 'potion' to drink a mana potion.");
                Console.WriteLine("Write 'run' to try to run. If you fail to run away, you die instantly...");
                Console.WriteLine("=========================================");
                heroAction = Console.ReadLine().ToLower();
                isHeroActionValid = heroAction == "attack" || heroAction == "prepare" || heroAction == "block" || heroAction == "spell" || heroAction == "potion" || heroAction == "run";
            } while (!isHeroActionValid);
            return heroAction;
        }
        private void CastSpell()
        {
            string spell;
            do
            {
                Console.WriteLine("Write 'heal' to cast a healing spell on yourself...");
                spell = Console.ReadLine().ToLower();
                switch (spell)
                {
                    case "heal":
                        Heal();
                        break;
                    default:
                        Console.WriteLine("Invalid spell.");
                        break;
                }
            } while (spell != "heal");
        }
        private void Heal()
        {
            if (Mana < 50)
                Console.WriteLine("You don't have enough mana to heal yourself. You need 50 mana.");
            else
            {
                Mana -= 50;
                SetHealth(MaxHealth);
                Console.WriteLine("You heal yourself.");
            }
        }
        private void DrinkManaPotion()
        {
            if (ManaPotion <= 0)
                Console.WriteLine("You don't have any mana potion left.");
            else
            {
                if (Mana + 50 > MaxMana)
                    Mana = MaxMana;
                else
                    Mana += 50;
                ManaPotion--;
                Console.WriteLine("You drink a mana potion");
            }
        }
        private void HeroAction(Monster monster, string heroAction)
        {
            switch (heroAction)
            {
                case "attack":
                    Console.WriteLine("You perform an attack");
                    if (DamageStack - monster.BlockStack > 0)
                        monster.SetHealth(monster.Health - (DamageStack - monster.BlockStack));
                    DamageStack = CalculateStrikeDamage();
                    monster.BlockStack = 0;
                    break;
                case "prepare":
                    Console.WriteLine("You prepare a great attack");
                    DamageStack *= 2.5;
                    break;
                case "block":
                    Console.WriteLine("You will block the next attack.");
                    BlockStack += this.Block;
                    break;
                case "spell":
                    Console.WriteLine("You cast a spell.");
                    CastSpell();
                    break;
                case "potion":
                    DrinkManaPotion();
                    break;
                case "run":
                    Console.WriteLine("You try to run away.");
                    TryToRunAway(3);
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }
        private void LevelUp()
        {
            if (Experience >= 100)
            {
                Level++;
                MaxHealth += 2;
                MaxMana += 15;
                Incarnation++;
                Experience -= 100;
                Console.WriteLine("Congratulations, you level up!");
            }
        }
    }
}
