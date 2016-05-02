using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawlerPython.Weapons;
using DungeonCrawlerPython.Shields;


namespace DungeonCrawlerPython
{
    class Player
    {
        #region fields
        int maxHealth;
        int health;
        bool blocking;
        Weapon weapon;
        Shield shield;
        #endregion

        #region properties
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

        public Player(int health)
        {
            this.maxHealth = health;
            this.health = maxHealth;

            weapon = new Weapon();
            shield = new Shield();
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
            if (blocking)
            {
                health -= shield.Block(damage);
            }
            else health -= damage;
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
