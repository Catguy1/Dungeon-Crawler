using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawlerPython.Armors;
using DungeonCrawlerPython.Weapons;
using DungeonCrawlerPython.Shields;

namespace DungeonCrawlerPython
{
    class Player
    {
        #region properties
        int health;
        bool blocking;

        int level;

        int exp;

        Weapon weapon;
        Shield shield;
        Armor armor;
        #endregion

        #region fields
        public Weapon Weapon
        {
            get
            {
                return weapon;
            }

            set
            {
                weapon = value;
            }
        }

        public Armor Armor
        {
            get
            {
                return armor;
            }

            set
            {
                armor = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
        }

        public int Exp
        {
            get
            {
                return exp;
            }

            set
            {
                exp = value;
            }
        }

        public Shield Shield
        {
            get
            {
                return shield;
            }

            set
            {
                shield = value;
            }
        }
        #endregion

        public Player()
        {
            level = 1;
            exp = 0;

            weapon = new Weapon(level);
            armor = new Armor(level);
            shield = new Shield(level);
            this.Health = armor.Health;
        }

        public int Attack()
        {
            blocking = false;
            return weapon.Attack();
        }

        public void Block()
        {
            weapon.Blocking();
            blocking = true;
        }

        public void TakeDamage(int damage)
        {
            if (blocking)
            {
                Health -= shield.Block(damage);
            }
            else if (!blocking)
            {
                Health -= damage;
            }
            Heal(armor.Ability());
        }

        public void Heal(int healAmount)
        {
            Health += healAmount;

            if (Health > armor.Health)
            {
                Health = armor.Health;
            }
        }

        public void Leveling(int earned)
        {
            exp += earned;
            if (exp >= level * 100)
            {
                exp -= level * 100;
                level++;
            }
        }
    }
}
