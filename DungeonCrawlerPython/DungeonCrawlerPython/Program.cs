using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Modules;
using IronPython.SQLite;
using Microsoft.Scripting.Hosting;
using DungeonCrawlerPython.Weapons;
using DungeonCrawlerPython.Armors;
using DungeonCrawlerPython.Enemies;
using DungeonCrawlerPython.Shields;

namespace DungeonCrawlerPython
{
    class Program
    {
        static Player p;
        static bool playing = true;

        static int points;

        static void Main(string[] args)
        {
            Initialize();

            while (playing)
            {
                Console.Clear();

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine(string.Format("You are level {0}\nYour weapon is a {1} and gives {2} damage\nYour armor gives you {3} health and heals you {4} per turn\nYour shield can block {5} damage",
                    p.Level, p.Weapon.WeaponType, p.Weapon.Damage, p.Armor.Health, p.Armor.HealValue, p.Shield.BlockValue));


                Console.WriteLine(string.Format("You have {0} health", p.Health));

                Console.WriteLine("What do you want to do?\n1. Search\n2. Rest");
                Console.WriteLine("-----------------------------------------------------");

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
        }

        static void Initialize()
        {
            p = new Player();
            points = 0;
        }

        static void Search()
        {
            Random rnd = new Random();

            int result = rnd.Next(4);

            Console.Clear();
            Console.WriteLine("Searching");

            switch (result)
            {
                case 0:
                    Shield s = new Shield(p.Level);

                    Console.WriteLine("You have found a new shield\nIt can block {0} damage", s.BlockValue);
                    Console.WriteLine("Your own shield blocks {0} damage\nWould you like to replace it?", p.Shield.BlockValue);

                    if (YesNo())
                    {
                        p.Shield = s;
                    }

                    break;

                case 1:
                    Weapon w = new Weapon(p.Level);

                    Console.WriteLine("You have found a new {0}\nIt does {1} damage", w.WeaponType, w.Damage);
                    Console.WriteLine("Your own {0} does {1} damage\nWould you like to replace it?", p.Weapon.WeaponType, p.Weapon.Damage);

                    if (YesNo())
                    {
                        p.Weapon = w;
                    }

                    break;

                case 2:
                    Armor a = new Armor(p.Level);

                    Console.WriteLine("You have found a new armour\nIt gives {0} health and heals {1} per turn", a.Health, a.HealValue);
                    Console.WriteLine("Your own armor gives {0} health and heals {1} per turn\nWould you like to replace it?", p.Armor.Health, p.Armor.HealValue);

                    if (YesNo())
                    {
                        p.Armor = a;
                    }

                    break;

                case 3:
                    Battle();
                    break;
            }
        }

        static void Rest()
        {
            p.Heal(100);
        }

        static void Battle()
        {
            bool flee = false;
            bool fighting = true;

            Enemy m = new Enemy(p.Level);

            Console.Clear();

            while (fighting)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("You have " + p.Health + " health");
                Console.WriteLine("The " + m.EnemyType + " has " + m.Health + " health");
                Console.WriteLine("1. Attack\n2. Block\n3. Flee");
                Console.WriteLine("-----------------------------------------------------");

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
                    points += 5;
                    p.Leveling(m.Exp);
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

            Console.WriteLine("\nPlease enter your name");

            string input = Console.ReadLine();

            AddHighscore(input, points);

            Console.Clear();

            PrintHighscore();

            Console.WriteLine("\nWould you like to play again?");

            bool choice = YesNo();

            if (choice)
            {
                Initialize();
            }
            else if (!choice)
            {
                playing = false;
            }
        }

        static void AddHighscore(string name, int points)
        {
            try
            {
                ScriptEngine eng = Python.CreateEngine();

                dynamic scope = eng.CreateScope();

                List<string> m_searchPaths = new List<string>();
                m_searchPaths.Add(@"PythonScripts");
                eng.SetSearchPaths(m_searchPaths);

                eng.ExecuteFile(@"PythonScripts\HighScore_Script.py", scope);

                dynamic pFunc = scope.GetVariable("Add");

                pFunc(name, points, DateTime.Now.ToString());
            }
            catch
            {
                Console.WriteLine("Failed to load or call the add function of the database script");
            }
        }

        static void PrintHighscore()
        {
            try
            {
                ScriptEngine eng = Python.CreateEngine();

                dynamic scope = eng.CreateScope();

                List<string> m_searchPaths = new List<string>();
                m_searchPaths.Add(@"PythonScripts");
                eng.SetSearchPaths(m_searchPaths);

                eng.ExecuteFile(@"PythonScripts\HighScore_Script.py", scope);

                dynamic pFunc = scope.GetVariable("Read");

                pFunc();
            }
            catch
            {
                Console.WriteLine("Failed to load or call the read function of the database script");
            }
        }

        static bool YesNo()
        {
            bool choosing = true;
            Console.WriteLine("1.Yes\n2.No");
            while (choosing)
            {
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "yes":
                        return true;

                    case "2":
                    case "no":
                        return false;

                    default:
                        Console.WriteLine("Invalid input try again");
                        break;
                }
            }
            return false;
        }
    }
}
