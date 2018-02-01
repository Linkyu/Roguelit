
using System;

namespace Roguelit
{
    public class Player : Entity
    {
        public int ZonePoints { get; private set; }
        public int MaxHealth { get; private set; }

        public Player(string name)
        {
            Name = name;
            Health = 150;
            MaxHealth = Health;
            ZonePoints = 0;
            AttackDamage = 10;
        }

        public override void TakeDamage(int damage)
        {
            if (!Shielded())
            {
                base.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine(Name + " blocked the attack!");
            }
        }

        private static bool Shielded()
        {
            var dice = new Dice();
            return dice.Roll(3) == 1;
        }

        public void ObtainPoints(int value)
        {
            Console.WriteLine(Name + " gained " + value + " points.");
            ZonePoints += value;
        }

        public void LevelUp()
        {
            Health = MaxHealth;
        }
    }
}