using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerPython.Armors
{
    class Armor
    {
        dynamic scope;
        dynamic pFunc;

        public int Health
        {
            get
            {
                pFunc = scope.GetVariable("GetHealth");
                return pFunc(scope);
            }
        }

        public int HealValue
        {
            get
            {
                pFunc = scope.GetVariable("GetHealing");
                return pFunc(scope);
            }
        }

        public Armor(int level)
        {
            LoadRandomFile();

            pFunc = scope.GetVariable("Initialize");

            pFunc(scope, level);
        }

        private void LoadFile(string dest)
        {
            ScriptEngine eng = Python.CreateEngine();

            scope = eng.CreateScope();

            eng.ExecuteFile(dest, scope);
        }

        private void LoadRandomFile()
        {
            Random rnd = new Random();

            ScriptEngine eng = Python.CreateEngine();

            scope = eng.CreateScope();

            string[] files = Directory.GetFiles(@"..\..\PythonScripts\Armors\", "*.py");

            int e = rnd.Next(files.Length);

            eng.ExecuteFile(files[e], scope);
        }

        public int Ability()
        {
            pFunc = scope.GetVariable("Ability");
            return pFunc(scope);
        }
    }
}
