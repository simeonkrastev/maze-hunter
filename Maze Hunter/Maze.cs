using System.CodeDom.Compiler;

namespace Maze_Hunter
{
    // The MazeRoom class manages the movement and actions in the maze.
    // The maze is a 8x8 matrix of characters.
    // The P character represents the Player.
    // The A and T characters represent the Assasins and Thieves
    // The ' ' character represent an empty spot.
    class MazeRoom
    {
        public char[,] Grid = new char[8, 8];

        public static int[] position;
        public Character npc;

        // Checks whether the Grid is empty (does not contain any NPCs)
        public bool IsMazeEmpty()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    char c = Grid[i, j];
                    if (c == 'A' || c == 'T')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public MazeRoom()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Grid[i, j] = ' ';
                }
            }

            position = new int[2] { 0, 0 };

            // place player, thief and assassin
            Grid[0, 0] = 'P';
            Grid[0, 2] = 'T';
            Grid[2, 0] = 'A';

        }

        public void MoveUp()
        {
            if (position[0] >= 0)
            {
                int row = position[0] + 1;
                Grid[row, position[1]] = ' ';
                Grid[position[0], position[1]] = 'P';
            }
        }

        public void MoveDown()
        {
            if (position[0] <= Grid.GetLength(0) - 1)
            {
                int row = position[0] - 1;
                Grid[row, position[1]] = ' ';
                //position[0]++;
                Grid[position[0], position[1]] = 'P';
            }
        }

        public void MoveLeft()
        {
            if (position[1] >= 0)
            {
                int column = position[1] + 1;
                Grid[position[0], column] = ' ';
                //position[1]--;
                Grid[position[0], position[1]] = 'P';
            }
        }

        public void MoveRight()
        {
            if (position[1] <= Grid.GetLength(1) - 1)
            {
                int column = position[1] - 1;
                Grid[position[0], column] = ' ';
                //position[1]++;
                Grid[position[0], position[1]] = 'P';
            }
        }

        public Character EncounteredNPC(char[,] Grid, int[] position) // Check for encounters with NPC's
        {
            if (Grid[position[0], position[1]] == 'T')
            {
                Character npc = CharacterGenerator.Generate("Thieves");

                // Example parameters
                /*npc.Name = "Hristo";
                npc.Guild = "Guild Of Thieves";
                npc.MaxStats = 10;
                npc.Health = 7;
                npc.Attack = 3;
                npc.GuildChecker = 1;*/
                return npc;
            }
            else if (Grid[position[0], position[1]] == 'A')
            {
                Character npc = CharacterGenerator.Generate("Assassins"); // Example parameters
                /*npc.Name = "Viki";
                npc.Guild = "Guild Of Assassins";
                npc.MaxStats = 10;
                npc.Health = 6;
                npc.Attack = 4;
                npc.GuildChecker = 2;*/
                return npc;
            }
            else
            {
                return null;
            }
        }

        public bool CheckIsPositionValid(int[] position, char[,] Grid)
        {
            bool validRow = false;
            bool validColumn = false;

            if (position[0] < Grid.GetLength(0) && position[0] >= 0)
            {
                validRow = true;
            }

            if (position[1] < Grid.GetLength(1) && position[1] >= 0)
            {
                validColumn = true;
            }

            if(validRow && validColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
