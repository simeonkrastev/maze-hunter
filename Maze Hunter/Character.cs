using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Hunter
{
    internal class Character
    {
        public string Name;
        public string Guild;
        public string Gender;
        public int Health;
        public int Attack;
        public int MaxStats;
        public string IncreaseAttribute;
        public string DecreaseAttrtibute;
        public int GuildChecker;
        public int HealthBonus = 0;
        public int AttackBonus = 0;


        public Character()
        {
            MaxStats = 10;
            Health = 0;
            Attack = 0;
            IncreaseAttribute = "";
            DecreaseAttrtibute = "";
        }

        public void IncreaseHealth()
        {
            if (Health < 10 && MaxStats > 0)
            {
                Health++;
                MaxStats--;
            }
        }

        public void DecreaseHealth()
        {
            if (Health > 0 && MaxStats < 10)
            {
                Health--;
                MaxStats++;
            }
        }

        public void IncreaseAttack()
        {
            if (Attack < 10 && MaxStats > 0)
            {
                Attack++;
                MaxStats--;
            }
        }

        public void DecreaseAttack()
        {
            if (Attack > 0 && MaxStats < 10)
            {
                Attack--;
                MaxStats++;
            }
        }

        public void Guilds()
        {
            if(GuildChecker == 1)
            {
                if(HealthBonus <= 0)
                {
                    Guild = "Guild Of Thieves";
                    if(AttackBonus > 0)
                    {
                        Attack -= 2;
                    }
                    HealthBonus = 2;
                    AttackBonus = 0;

                    Attack += AttackBonus;
                    Health += HealthBonus;
                }
            }
            else if (GuildChecker == 2)
            {
                if(AttackBonus <= 0)
                {
                    Guild = "Guild Of Assassins";
                    if(HealthBonus > 0)
                    {
                        Health -= 2;
                    }
                    HealthBonus = 0;
                    AttackBonus = 2;

                    Attack += AttackBonus;
                    Health += HealthBonus;
                }
            }
        }

        public void Male()
        {
            Gender = "Male";
        }

        public void Female()
        {
            Gender = "Female";
        }
    }
}
