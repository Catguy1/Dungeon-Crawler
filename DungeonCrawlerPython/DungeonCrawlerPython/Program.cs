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
        struct Player
        {
            int maxHealth;
            public int attack;
            public int health;

            public void Init(int attack, int health)
            {
                this.attack = attack;
                this.maxHealth = health;
                this.health = maxHealth;
            }

            public int Attack()
            {
                return attack;
            }

            public void TakeDamage(int damage)
            {
                health -= damage;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }

        struct Monster
        {
            public int attack;
            public int health;

            public void Init(int a, int h)
            {
                attack = a;
                health = h;
            }

            public int Attack()
            {
                return attack;
            }

            public void TakeDamage(int damage)
            {
                health -= damage;
            }
        }


        static Player p = new Player();
        static bool playing = true;

        static void Main(string[] args)
        {

            Enemies.Enemy e = new Enemies.Enemy();

            Console.WriteLine("In front of you stands a {0}\nIt has {1} health and {2} attack", e.enemyType, e.health, e.damage);

            //p.Init(10, 100);

            //while (playing)
            //{
            //    Console.Clear();

            //    Console.WriteLine("You have " + p.attack + " Attack and " + p.health + " Health");
            //    Console.WriteLine("What do you want to do?\n1. Search\n2. Rest");

            //    string input = Console.ReadLine();

            //    switch (input.ToLower())
            //    {
            //        case "1":
            //        case "search":
            //            Search();
            //            break;

            //        case "2":
            //        case "rest":
            //            Rest();
            //            break;
            //    }
            //}

            Console.ReadKey();
        }



        static void Search()
        {
            Battle();
        }

        static void Rest()
        {
            p.TakeDamage(-25);
        }

        static void Battle()
        {
            bool flee = false;
            bool fighting = true;


            Monster m = new Monster();
            m.Init(10, 50);

            while (fighting)
            {
                Console.Clear();
                Console.WriteLine("You have " + p.health + " health");
                Console.WriteLine("The monster has " + m.health + " health");
                Console.WriteLine("1. Attack\n2. Flee");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "attack":
                        m.TakeDamage(p.Attack());
                        break;

                    case "2":
                    case "flee":
                        flee = true;
                        break;
                }

                if (m.health <= 0 && flee != true)
                {
                    Console.WriteLine("You have beaten the monster and everyone is happy");
                    fighting = false;
                }
                else if (flee != true)
                {
                    p.TakeDamage(m.Attack());
                    if (p.health <= 0)
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
