﻿using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerPython.Weapons
{
    class Weapon
    {
        dynamic scope;
        dynamic pFunc;

        int damage;

        public int Damage
        {
            get
            {
                pFunc = scope.GetVariable("GetDamage");
                return pFunc(scope);
            }
        }

        public Weapon()
        {
            LoadRandomFile();

            pFunc = scope.GetVariable("Initialize");

            pFunc(scope, 10);
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

            string[] files = Directory.GetFiles(@"..\..\PythonScripts\Weapons\", "*.py");

            int e = rnd.Next(files.Length);

            eng.ExecuteFile(files[e], scope);
        }

        public int Attack()
        {
            pFunc = scope.GetVariable("Attack");
            return pFunc(scope);
        }
    }
}
