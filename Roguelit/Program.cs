using System;
using System.Threading;

namespace Roguelit
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please choose a name: ");
            var player = new Player(Console.ReadLine());
            const int pointsRequired = 30;
            var dice = new Dice();

            Console.WriteLine("Good luck!");
            Thread.Sleep(3000);
            Console.WriteLine();
            
            // Crawl starts
            while (player.IsAlive())
            {
                // Level 1
                if (player.ZonePoints < pointsRequired)
                {
                    var enemy = GenerateEnemy();
                    Thread.Sleep(1000);

                    // Fight starts
                    while (player.IsAlive() && enemy.IsAlive())
                    {
                        Console.WriteLine(player.Name + "'s health: [" + player.Health + "/" + player.MaxHealth + "]");
                        var playerRoll = dice.Roll();
                        var enemyRoll = dice.Roll();
                        Console.WriteLine(player.Name + ": " + playerRoll + " VS " + enemy.Name + ": " + enemyRoll);
                        Thread.Sleep(500);
                        
                        if (playerRoll >= enemyRoll)
                        {
                            player.Attack(enemy);
                        }

                        if (enemy.IsAlive())
                        {
                            playerRoll = dice.Roll();
                            enemyRoll = dice.Roll();
                            Console.WriteLine(enemy.Name + ": " + enemyRoll + " VS " + player.Name + ": " + playerRoll);
                            Thread.Sleep(500);
                            
                            if (enemyRoll > playerRoll)
                            {
                                enemy.Attack(player);
                            }
                        }
                        else
                        {
                            Console.WriteLine(enemy.Name + " is dead.");
                            player.ObtainPoints(enemy.Points);
                            Console.WriteLine(player.Name + " has " + player.ZonePoints + " points now.");
                        }
                    }
                    
                    Console.WriteLine();
                }
                else // Level 2
                {
                    Console.WriteLine(player.Name + " has reached the Boss Level!");
                    player.LevelUp();
                    var boss = new FinalBoss("EL BOSS DE LA MUERTE");
                    Console.WriteLine("Prepare to die.");
                    
                    // Fight starts
                    while (player.IsAlive() && boss.IsAlive())
                    {
                        Console.WriteLine(player.Name + "'s health: [" + player.Health + "/" + player.MaxHealth + "]");
                        Console.WriteLine(boss.Name + "'s health: [" + boss.Health + "/" + boss.MaxHealth + "]");
                        var playerRoll = dice.Roll(25);
                        Thread.Sleep(500);
                        
                        player.FinalAttack(boss, playerRoll);

                        if (boss.IsAlive())
                        {
                            var enemyRoll = dice.Roll(25);
                            Thread.Sleep(500);
                            boss.FinalAttack(player, enemyRoll);
                        }
                        else
                        {
                            Console.WriteLine(boss.Name + " is dead.");
                            player.ObtainPoints(boss.Points);
                            Console.WriteLine(player.Name + " has won.");
                            Thread.Sleep(5000);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static Enemy GenerateEnemy()
        {
            var dice = new Dice();
            return dice.Roll(2) == 1 ? new Enemy() : new EnemyHard();
        }
    }
}