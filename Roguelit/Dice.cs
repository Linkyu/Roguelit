using System;

namespace Roguelit
{
    public class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();;
        }

        public int Roll()
        {
            return random.Next(1, 7);
        }
        
        public int Roll(int sides)
        {
            return random.Next(1, sides+1);
        }
    }
}