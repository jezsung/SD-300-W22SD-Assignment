
Game game = new Game(
    new Hero("Yummi", 3, 3, 10, WeaponList.Stick, ArmourList.Mask),
    new List<Monster> {
        new Monster("Gagaga", 3, 3, 8),
        new Monster("Gugugu", 6, 3, 8),
        new Monster("Gigigi", 3, 2, 8),
    }
    );

game.Start();

class Game
{
    public string PlayerName { get; set; }
    public int GamePlayCount { get; set; }
    public int WinCount { get; set; }
    public int LossCount { get; set; }
    public Hero Hero { get; set; }
    public List<Monster> Monsters { get; set; }

    private List<Monster> AvilableMonsters { get; set; }

    public Game(Hero hero, List<Monster> monsters)
    {
        Hero = hero;
        Monsters = monsters;
        AvilableMonsters = monsters;
    }

    public void Start()
    {
        AskName();
        while (true)
        {
            DisplayMainMenu();
        }
    }

    public void AskName()
    {
        string name;
        do
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("==================================================\n");
        } while (name == null || name.Length == 0);

        PlayerName = name;
    }

    public void DisplayMainMenu()
    {
        string selectedKey;
        do
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(
                "a) Display Statistics\n" +
                "b) Display Inventory\n" +
                "c) Fight"
                );
            selectedKey = Console.ReadLine();
            Console.WriteLine("==================================================\n");
        } while (selectedKey != "a" && selectedKey != "b" && selectedKey != "c");

        switch (selectedKey)
        {
            case "a":
                DisplayStatistics();
                break;
            case "b":
                DisplayInventory();
                break;
            case "c":
                Fight();
                break;
        }
    }

    public void DisplayStatistics()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine(
            $"Number of Game Played: {GamePlayCount}\n" +
            $"Number of Fight Won: {WinCount}\n" +
            $"Number of Fight Lost: {LossCount}\n"
            );
        Console.WriteLine("==================================================\n");
    }

    public void DisplayInventory()
    {
        string selectedKey;
        do
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(
                "a) Change Weapon\n" +
                "b) Change Armour\n" +
                "c) Exit"
                );
            selectedKey = Console.ReadLine();
            Console.WriteLine("==================================================\n");
        } while (selectedKey != "a" && selectedKey != "b" && selectedKey != "c");

        switch (selectedKey)
        {
            case "a":
                ChangeWeapon();
                break;
            case "b":
                ChangeArmour();
                break;
            case "c":
                break;
        }
    }

    public void ChangeWeapon()
    {
        string selectedKey;
        do
        {
            Console.WriteLine(
                $"a) {WeaponList.Stick.Name}({WeaponList.Stick.Power}){(Hero.EquippedWeapon == WeaponList.Stick ? " *" : "")}\n" +
                $"b) {WeaponList.Sword.Name}({WeaponList.Sword.Power}){(Hero.EquippedWeapon == WeaponList.Sword ? " *" : "")}\n" +
                $"c) {WeaponList.Knife.Name}({WeaponList.Knife.Power}){(Hero.EquippedWeapon == WeaponList.Knife ? " *" : "")}\n" +
                $"d) {WeaponList.Spear.Name}({WeaponList.Spear.Power}){(Hero.EquippedWeapon == WeaponList.Spear ? " *" : "")}\n" +
                $"e) {WeaponList.Boomerang.Name}({WeaponList.Boomerang.Power}){(Hero.EquippedWeapon == WeaponList.Boomerang ? " *" : "")}\n" +
                "f) Exit"
                );
            selectedKey = Console.ReadLine();
        } while (selectedKey != "a" && selectedKey != "b" && selectedKey != "c" && selectedKey != "d" && selectedKey != "e" && selectedKey != "f");

        switch (selectedKey)
        {
            case "a":
                Hero.EquippedWeapon = WeaponList.Stick;
                break;
            case "b":
                Hero.EquippedWeapon = WeaponList.Sword;
                break;
            case "c":
                Hero.EquippedWeapon = WeaponList.Knife;
                break;
            case "d":
                Hero.EquippedWeapon = WeaponList.Spear;
                break;
            case "e":
                Hero.EquippedWeapon = WeaponList.Boomerang;
                break;
            case "f":
                break;
        }
    }

    public void ChangeArmour()
    {
        string selectedKey;
        do
        {
            Console.WriteLine(
                $"a) {ArmourList.Cloak.Name}({ArmourList.Cloak.Power}){(Hero.EquippedArmour == ArmourList.Cloak ? " *" : "")}\n" +
                $"b) {ArmourList.Gloves.Name}({ArmourList.Gloves.Power}){(Hero.EquippedArmour == ArmourList.Gloves ? " *" : "")}\n" +
                $"c) {ArmourList.Boots.Name}({ArmourList.Boots.Power}){(Hero.EquippedArmour == ArmourList.Boots ? " *" : "")}\n" +
                $"d) {ArmourList.Pants.Name}({ArmourList.Pants.Power}){(Hero.EquippedArmour == ArmourList.Pants ? " *" : "")}\n" +
                $"e) {ArmourList.Mask.Name}({ArmourList.Mask.Power}){(Hero.EquippedArmour == ArmourList.Mask ? " *" : "")}\n" +
                "f) Exit"
                );
            selectedKey = Console.ReadLine();
        } while (selectedKey != "a" && selectedKey != "b" && selectedKey != "c" && selectedKey != "d" && selectedKey != "e" && selectedKey != "f");

        switch (selectedKey)
        {
            case "a":
                Hero.EquippedArmour = ArmourList.Cloak;
                break;
            case "b":
                Hero.EquippedArmour = ArmourList.Gloves;
                break;
            case "c":
                Hero.EquippedArmour = ArmourList.Boots;
                break;
            case "d":
                Hero.EquippedArmour = ArmourList.Pants;
                break;
            case "e":
                Hero.EquippedArmour = ArmourList.Mask;
                break;
            case "f":
                break;
        }
    }

    public void Fight()
    {
        if (AvilableMonsters.Count == 0)
        {
            Console.WriteLine("The hero beat up all the monsters!");
            return;
        }

        Fight fight = new Fight(Hero, AvilableMonsters[0]);

        while (true)
        {
            int heroCurrentHealth = fight.Hero.CurrentHealth;
            int monsterCurrentHealth = fight.Monster.CurrentHealth;

            fight.HeroTurn();
            if (fight.Win())
            {
                AvilableMonsters.RemoveAt(0);
                Console.WriteLine("The hero won!");

                WinCount++;
                break;
            }

            fight.MonsterTurn();
            if (fight.Lose())
            {
                Hero.CurrentHealth = Hero.OriginalHealth;
                AvilableMonsters = Monsters;
                Console.WriteLine("The hero lost");

                LossCount++;
                break;
            }

            if (heroCurrentHealth == fight.Hero.CurrentHealth && monsterCurrentHealth == fight.Monster.CurrentHealth)
            {
                Console.WriteLine("None of them do damage to each other");
                break;
            }
        }

        GamePlayCount++;
    }
}

class Fight
{
    public Hero Hero { get; set; }
    public Monster Monster { get; set; }

    public Fight(Hero hero, Monster monster)
    {
        Hero = hero;
        Monster = monster;
    }

    public void HeroTurn()
    {
        int damage = Math.Max(Hero.BaseStrength + Hero.EquippedWeapon.Power - Monster.Defense, 0);
        Monster.CurrentHealth -= damage;
        Console.WriteLine(
            $"Hero {Hero.Name} damages {damage} to Monster {Monster.Name}\n" +
            $"Hero's Health: {Hero.CurrentHealth} / {Hero.OriginalHealth}\n" +
            $"Monster's Health: {Monster.CurrentHealth} / {Monster.OriginalHealth}\n"
            );
    }

    public void MonsterTurn()
    {
        int damage = Math.Max(Monster.Strength - (Hero.BaseDefence + Hero.EquippedArmour.Power), 0);
        Hero.CurrentHealth -= damage;
        Console.WriteLine(
            $"Monster {Monster.Name} damages {damage} to Hero {Hero.Name}\n" +
            $"Hero's Health: {Hero.CurrentHealth} / {Hero.OriginalHealth}\n" +
            $"Monster's Health: {Monster.CurrentHealth} / {Monster.OriginalHealth}\n"
            );
    }

    public bool Win()
    {
        return Monster.CurrentHealth <= 0;
    }

    public bool Lose()
    {
        return Hero.CurrentHealth <= 0;
    }
}

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefence { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armour EquippedArmour { get; set; }

    public Hero(string name, int baseStrength, int baseDefense, int health, Weapon weapon, Armour armour)
    {
        Name = name;
        BaseStrength = baseStrength;
        BaseDefence = baseDefense;
        OriginalHealth = health;
        CurrentHealth = health;
        EquippedWeapon = weapon;
        EquippedArmour = armour;
    }

    public void ShowStats()
    {
        Console.WriteLine(
            $"Hero's Name: {Name}\n" +
            $"Base Strength: {BaseStrength}\n" +
            $"Base Defense: {BaseDefence}\n" +
            $"Original Health: {OriginalHealth}\n" +
            $"Current Health: {CurrentHealth}"
            );
    }

    public void ShowInventory()
    {
        Console.WriteLine(
            $"Weapon: {EquippedWeapon.Name}\n" +
            $"Armour: {EquippedArmour.Name}"
            );
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        EquippedWeapon = newWeapon;
    }

    public void EquipArmour(Armour newArmour)
    {
        EquippedArmour = newArmour;
    }
}

class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }

    public Monster(string name, int strength, int defense, int health)
    {
        Name = name;
        Strength = strength;
        Defense = defense;
        OriginalHealth = health;
        CurrentHealth = health;
    }
}

class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }

    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

class Armour
{
    public string Name { get; set; }
    public int Power { get; set; }

    public Armour(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

static class WeaponList
{
    public static Weapon Stick { get; } = new Weapon("Stick", 1);
    public static Weapon Sword { get; } = new Weapon("Sword", 3);
    public static Weapon Knife { get; } = new Weapon("Knife", 2);
    public static Weapon Spear { get; } = new Weapon("Spear", 4);
    public static Weapon Boomerang { get; } = new Weapon("Boomerang", 2);

    public static List<Weapon> AllWeapons { get; } = new List<Weapon> { Stick, Sword, Knife, Spear, Boomerang };
}

static class ArmourList
{
    public static Armour Cloak { get; set; } = new Armour("Cloak", 5);
    public static Armour Gloves { get; set; } = new Armour("Gloves", 3);
    public static Armour Boots { get; set; } = new Armour("Pants", 2);
    public static Armour Pants { get; set; } = new Armour("Pants", 2);
    public static Armour Mask { get; set; } = new Armour("Mask", 1);


    public static List<Armour> AllArmours { get; } = new List<Armour> { Cloak, Gloves, Boots, Pants, Mask };
}
