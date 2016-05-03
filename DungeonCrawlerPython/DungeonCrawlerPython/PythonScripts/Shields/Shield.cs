using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerPython.Shields
{
    class Shield
    {
        dynamic scope;
        dynamic pFunc;

        public int BlockValue
        {
            get
            {
                pFunc = scope.GetVariable("GetBlock");
                return pFunc(scope);
            }
        }

        public Shield(int level)
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

            string[] files = Directory.GetFiles(@"PythonScripts\Shields\", "*.py");

            int e = rnd.Next(files.Length);

            eng.ExecuteFile(files[e], scope);
        }

        public int Block(int damage)
        {
            pFunc = scope.GetVariable("Block");

            return pFunc(scope, damage);
        }
    }
}
