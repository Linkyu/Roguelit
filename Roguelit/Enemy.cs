
using System;
using System.Collections.Generic;

namespace Roguelit
{
    public class Enemy : Entity
    {
        public int Points { get; protected set; }
        
        public Enemy()
        {
            Name = GenerateName();
            Health = 10;
            Points = 1;
            AttackDamage = 10;
            Console.WriteLine("A " + Name + " appears!");
        }

        private static string GenerateName()
        {
            var dice = new Dice();
            var nameList = new List<string>
            {
                "Slime",
                "Skeleton",
                "Rat",
                "Mushroom",
                "Big butterfly",
                "Hawk",
                "Goblin",
                "Monkey",
                "Gnome",
                "Bat",
                "Sheep",
                "Chicken",
                "Boar",
                "Kobold"
            };
            return nameList[dice.Roll(nameList.Count)-1];
        }
    }
    
    public class EnemyHard : Enemy
    {
        public EnemyHard()
        {
            Name = GenerateName();
            Health = 1;
            Points = 2;
            AttackDamage = 10;
            Console.WriteLine("A " + Name + " appears!");
            Console.WriteLine("Looks like it will be a tough fight!!!");
        }

        public override void Attack(Entity target)
        {
            base.Attack(target);
            CastSpell(target);
        }

        private void CastSpell(Entity target)
        {
            var dice = new Dice();
            var result = dice.Roll();
            Console.WriteLine(Name + " casts a spell!");
            if (result < 6)
            {
                target.TakeDamage(result * 5);
            }
            else
            {
                Console.WriteLine("...but it missed.");
            }
        }

        private static string GenerateName()
        {
            var dice = new Dice();
            var nameList = new List<string>
            {
                "Orc",
                "Troll", 
                "Giant",
                "Grizzly",
                "Bugbear",
                "Giant Spider",
                "Draugr",
                "Undead Shaman",
                "Gnoll",
                "Adventurer",
                "Small Wyvern",
                "a BIG chicken"
            };
            return nameList[dice.Roll(nameList.Count)-1];
        }
    }

    public class FinalBoss : Enemy
    {
        public int MaxHealth { get; private set; }

        public FinalBoss(string name)
        {
            Name = name;
            Health = 250;
            MaxHealth = Health;
            AttackDamage = 10;
        }
        
    }
}