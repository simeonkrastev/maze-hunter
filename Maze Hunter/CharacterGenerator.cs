

using System;
using System.IO.Pipes;

namespace Maze_Hunter
{
    internal class CharacterGenerator
    {
        public static Character Generate(string guild = "")
        {
            if(guild == "")
            {
                Random rand = new Random();
                int guildChecker = rand.Next(1,3);

                if(guildChecker == 1)
                {
                    guild = "Thieves";
                }
                else
                {
                    guild = "Assassins";
                }
            }

            if (guild == "Thieves") 
            {
                Character npc = new Character();
                npc.Guild = "Thieves";
                npc.RandomGender();
                npc.RandomName();
                npc.RandomStats();
                return npc;
            } 
            else if (guild == "Assassins")
            {
                Character npc = new Character();
                npc.Guild = "Assassins";
                npc.RandomGender();
                npc.RandomName();
                npc.RandomStats();
                return npc;
            }

            return null;
        }
    }
}
