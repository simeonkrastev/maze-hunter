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
    }
}
