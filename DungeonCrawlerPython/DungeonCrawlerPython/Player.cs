using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawlerPython.Armors;
using DungeonCrawlerPython.Weapons;

namespace DungeonCrawlerPython
{
    class Player
    {
        int health;
        bool blocking;
        int blockAmount;
        
        Weapons.Weapon weapon;
        Armors.Armor armor;
        
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

        public Player()
        {
            weapon = new Weapons.Weapon();
            armor = new Armors.Armor();
            this.Health = armor.Health;
        }

        public int Attack()
        {
            blocking = false;
            return weapon.Attack();
        }

        public void Block()
        {
            blocking = true;
        }

        public void TakeDamage(int damage)
        {
            if (blocking && blockAmount < damage)
            {
                Health -= (damage - blockAmount);
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
    }
}
