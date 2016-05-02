using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawlerPython.Weapons;

namespace DungeonCrawlerPython
{
    class Player
    {
        int maxHealth;
        int health;
        bool blocking;
        int blockAmount;
        Weapons.Weapon weapon;

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

        public Player(int health)
        {
            this.maxHealth = health;
            this.health = maxHealth;

            weapon = new Weapons.Weapon();
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
                health -= (damage - blockAmount);
            }
            else if (!blocking)
            {
                health -= damage;
            }
        }

        public void Heal(int healAmount)
        {
            health += healAmount;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
