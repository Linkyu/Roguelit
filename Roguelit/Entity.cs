using System;

namespace Roguelit
{
    public class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        protected int AttackDamage { get; set; }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public virtual void Attack(Entity target)
        {
            Console.WriteLine(Name + " attacks " + target.Name + "!");
            target.TakeDamage(AttackDamage);
        }

        public void FinalAttack(Entity target, int damage)
        {
            target.TakeDamage(damage);
        }

        public virtual void TakeDamage(int damage)
        {
            Console.WriteLine(Name + " took " + damage + " dmg!!!");
            Health -= damage;
        }
    }
}