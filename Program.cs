using System;

class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }

    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }

    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage");
        return target.Health;
    }
}

class Wizard : Human
{
    public Wizard(string name) : base(name, 10, 25, 10, 50) { }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} lanzo un hechizo a {target.Name} por {dmg} de daño y se curo por {dmg}!");
        return target.Health;
    }

    public void Heal(Human target)
    {
        int healAmount = Intelligence * 3;
        target.Health += healAmount;
        Console.WriteLine($"{Name} curo a {target.Name} por {healAmount}!");
    }
}

class Ninja : Human
{
    public Ninja(string name) : base(name, 10, 10, 75, 100) { }

    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        if (new Random().Next(1, 6) == 1) // 20% de probabilidad de infligir daño adicional
        {
            dmg += 10;
        }
        target.Health -= dmg;
        Console.WriteLine($"{Name} atacó a {target.Name} por {dmg} de daño!");
        return target.Health;
    }

    public void Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine($"{Name} robo 5 de salud de {target.Name}!");
    }
}

class Samurai : Human
{
    public Samurai(string name) : base(name, 15, 10, 10, 200) { }

    public override int Attack(Human target)
    {
        int remainingHealth = base.Attack(target);
        if (remainingHealth < 50)
        {
            target.Health = 0;
            Console.WriteLine($"{Name} realizo un ataque mortal contra {target.Name} y redujo su salud a 0");
        }
        return target.Health;
    }

    public void Meditar()
    {
        Health = 200; // Restaura la salud del Samurai a su máximo
        Console.WriteLine($"{Name} medito y restauro su salud al maximo.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Wizard mago = new Wizard("Gandalf");
        Ninja ninja = new Ninja("Hattori Hanzo");
        Samurai samurai = new Samurai("Kenshin Himura");

        mago.Attack(ninja);
        ninja.Steal(samurai);
        samurai.Meditar();
    }
}
