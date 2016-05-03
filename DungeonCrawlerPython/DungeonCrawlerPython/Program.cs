using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace DungeonCrawlerPython
{
    class Program
    {
        static Player p;
        static bool playing = true;

        static void Main(string[] args)
        {
            while (playing)
            {
                Console.Clear();

                Console.WriteLine(string.Format("You have {0} Attack and {1} Health", p.Weapon.Damage, p.Health));
                Console.WriteLine("What do you want to do?\n1. Search\n2. Rest");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "search":
                        Search();
                        break;

                    case "2":
                    case "rest":
                        Rest();
                        break;
                }
            }

            Console.ReadKey();
        }

        static void Initialize()
        {
            p = new Player();
        }

        static void Search()
        {
            Console.Clear();
            Console.WriteLine("Searching");

            Battle();
        }

        static void Rest()
        {
            p.Heal(100);
        }

        static void Battle()
        {
            bool flee = false;
            bool fighting = true;

            Enemies.Enemy m = new Enemies.Enemy();

            Console.Clear();

            while (fighting)
            {
                Console.WriteLine("\nYou have " + p.Health + " health");
                Console.WriteLine("The " + m.EnemyType + " has " + m.Health + " health");
                Console.WriteLine("1. Attack\n2. Block\n3. Flee");

                string input = Console.ReadLine();

                Console.Clear();

                switch (input.ToLower())
                {
                    case "1":
                    case "attack":
                        m.TakeDamage(p.Attack());
                        break;

                    case "2":
                    case "blocking":
                        p.Block();
                        break;
                    case "3":
                    case "flee":
                        flee = true;
                        break;
                }

                if (m.Health <= 0 && flee != true)
                {
                    Console.WriteLine("You have beaten the monster and everyone is happy");
                    fighting = false;
                }
                else if (flee != true)
                {
                    p.TakeDamage(m.Attack());
                    if (p.Health <= 0)
                    {
                        GameOver();
                        fighting = false;
                    }
                }
                else if (flee)
                {
                    fighting = false;
                }


            }
        }

        static void GameOver()
        {
            Console.WriteLine("You have lost and everyone is sad, except the monsters, they're happy, they're having a picnic right now, everything is good in monsterland");
            playing = false;
        }
    }
}
