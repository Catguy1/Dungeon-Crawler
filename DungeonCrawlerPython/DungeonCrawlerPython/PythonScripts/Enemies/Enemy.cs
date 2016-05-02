using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace DungeonCrawlerPython.Enemies
{
    class Enemy
    {
        private dynamic scope;
        private dynamic pFunc;

        string enemyType;

        int health;
        int damage;

        public string EnemyType
        {
            get
            {
                pFunc = scope.GetVariable("GetName");
                return enemyType = pFunc(scope);
            }
        }

        public int Health
        {
            get
            {
                pFunc = scope.GetVariable("GetHealth");
                return health = pFunc(scope);
            }
        }

        public int Damage
        {
            get
            {
                pFunc = scope.GetVariable("GetDamage");
                return damage = pFunc(scope);
            }
        }

        /// <summary>
        /// Generates a random enemy from the enemies folder
        /// </summary>
        public Enemy()
        {
            LoadRandomFile();

            pFunc = scope.GetVariable("Initialize");
            pFunc(scope);
        }

        /// <summary>
        /// Generates a specific enemy defined by the file path given
        /// </summary>
        /// <param name="dest">The file path to the enemy you wish to create</param>
        public Enemy(string dest)
        {
            LoadFile(dest);
        }

        private void LoadFile(string dest)
        {
            ScriptEngine eng = Python.CreateEngine();

            scope = eng.CreateScope();

            eng.ExecuteFile(dest, scope);

            pFunc = scope.GetVariable("Initialize");
        }

        private void LoadRandomFile()
        {
            Random rnd = new Random();

            ScriptEngine eng = Python.CreateEngine();

            scope = eng.CreateScope();

            string[] files = Directory.GetFiles(@"..\..\PythonScripts\Enemies\", "*.py");

            int e = rnd.Next(files.Length);

            eng.ExecuteFile(files[e], scope);

            pFunc = scope.GetVariable("Initialize");
        }

        public int Attack()
        {
            var pFunc = scope.GetVariable("Attack");

            return pFunc(scope);
        }

        public void TakeDamage(int d)
        {
            var pFunc = scope.GetVariable("TakeDamage");

            pFunc(scope, d);
        }
    }
}
