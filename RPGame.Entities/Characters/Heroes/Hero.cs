using RPGame.Entities.Characters.Monsters;

namespace RPGame.Entities.Characters.Heroes
{
    public class Hero : Character
    {
        //TODO: DONNER UNE ID EN C#
        public int Id { get; set; }

        private double _maxHealth;

        public double MaxHealth
        {
            get { return _maxHealth; }
            set 
            {
                if (value < 0)
                    _maxHealth = 0;
                else
                    _maxHealth = value; 
            }
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

        public void Encounter(Monster monster)
        {
            bool hasHeroWon;
            Console.WriteLine("=========================================");
            Console.WriteLine($"You encounter a wild {monster.Name}.");
            string choice = AskFightOrRun();
            if (choice == "run")
                TryToRunAway(5);
            else
                Fight(monster);
            if (monster.Health == 0)
            {
                Console.WriteLine("You have slain the monster.");
                hasHeroWon = true;
                this.Gold += monster.Gold;
                this.Experience += monster.Fame;
                this.LevelUp();
                this.Health = this.MaxHealth;
                this.Mana = this.MaxMana;
                Console.WriteLine($"Your Health: {this.Health}, your mana: {this.Mana}, your gold: {this.Gold}, your XP: {this.Experience}, your lvl: {this.Level}");
            }
            else if (this.Health == 0)
            {
                Console.WriteLine("The monster destroyed you.");
                hasHeroWon = false;
                this.Incarnation--;
                this.Health = this.MaxHealth;
                this.Mana = this.MaxMana;
                Console.WriteLine($"You have {this.Incarnation} incarnation left.");
                Console.WriteLine($"Your Health: {this.Health}, your mana: {this.Mana}, your gold: {this.Gold}, your XP: {this.Experience}, your lvl: {this.Level}");
            }
            Console.WriteLine("The encounter is over.");
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
            Random random = new Random();
            int dice = random.Next(1, diceFaces + 1);
            if (dice == 1)
            {
                Console.WriteLine("You turn your back, try to run away but get executed.");
                this.Health = 0;
            }
            else
                Console.WriteLine("You run away.");
        }
        private void Fight(Monster monster)
        {
            this.DamageStack = this.CalculateStrikeDamage();
            monster.DamageStack = monster.CalculateStrikeDamage();
            bool isHerosTurn = true;
            while (this.Health != 0 && monster.Health != 0)
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
                    Console.WriteLine($"Hero health: {this.Health}");
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
            if (this.Mana < 50)
                Console.WriteLine("You don't have enough mana to heal yourself. You need 50 mana.");
            else
            {
                this.Mana -= 50;
                this.Health = this.MaxHealth;
                Console.WriteLine("You heal yourself.");
            }
        }
        private void DrinkManaPotion()
        {
            if (this.ManaPotion <= 0)
                Console.WriteLine("You don't have any mana potion left.");
            else
            {
                if (this.Mana + 50 > this.MaxMana)
                    this.Mana = this.MaxMana;
                else
                    this.Mana += 50;
                this.ManaPotion--;
                Console.WriteLine("You drink a mana potion");
            }
        }
        private void HeroAction(Monster monster, string heroAction)
        {
            switch (heroAction)
            {
                case "attack":
                    Console.WriteLine("You perform an attack");
                    if (this.DamageStack - monster.BlockStack > 0)
                        monster.Health -= this.DamageStack - monster.BlockStack;
                    this.DamageStack = this.CalculateStrikeDamage();
                    monster.BlockStack = 0;
                    break;
                case "prepare":
                    Console.WriteLine("You prepare a great attack");
                    this.DamageStack *= 2.5;
                    break;
                case "block":
                    Console.WriteLine("You will block the next attack.");
                    this.BlockStack += this.Block;
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
            if (this.Experience >= 100)
            {
                this.Level++;
                this.MaxHealth += 2;
                this.MaxMana += 15;
                this.Incarnation++;
                this.Experience -= 100;
                Console.WriteLine("Congratulations, you level up!");
            }
        }
    }
}
