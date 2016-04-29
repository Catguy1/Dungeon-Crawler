using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace DungeonCrawlerPython.Enemies
{
    class Enemy
    {
        public string enemyType;

        public int health;
        public int damage;

        public Enemy()
        {
            LoadRandomFile();
        }

        private void LoadFile(int i)
        {
            ScriptEngine eng = Python.CreateEngine();

            dynamic scope = eng.CreateScope();

            string[] files = Directory.GetFiles(@"..\..\Enemies\", "*.py");

            eng.ExecuteFile(files[i], scope);

            enemyType = scope.GetVariable("type");

            health = scope.GetVariable("health");
            damage = scope.GetVariable("damage");
        }

        private void LoadRandomFile()
        {
            Random rnd = new Random();

            ScriptEngine eng = Python.CreateEngine();

            dynamic scope = eng.CreateScope();

            string[] files = Directory.GetFiles(@"..\..\Enemies\", "*.py");

            int enemy = rnd.Next(files.Length);

            eng.ExecuteFile(files[enemy], scope);

            enemyType = scope.GetVariable("type");

            health = scope.GetVariable("health");
            damage = scope.GetVariable("damage");
        }
    }
}
