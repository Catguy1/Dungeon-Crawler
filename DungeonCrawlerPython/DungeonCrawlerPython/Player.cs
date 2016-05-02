using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerPython
{
    class Player
    {
        int maxHealth;
        int damage;
        int health;

        public int Damage
        {
            get
            {
                return damage;
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

        public Player(int damage, int health)
        {
            this.damage = damage;
            this.maxHealth = health;
            this.health = maxHealth;
        }

        public int Attack()
        {
            return damage;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
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
