using System;
using System.Numerics;

namespace Maze_Hunter
{
    // The Screen class manages and draws a screen on the console.
    class Screen
    {
        public string Title;
        public OptionsMenu Menu;

        // Creates a new screen with a given title and menu.
        public Screen(string title, OptionsMenu menu)
        {
            Title = title;
            Menu = menu;
        }

        // Draw the screen on the console, using the WriteLine method.
        public virtual void Draw()
        {
            Console.Clear();                                // Reset the console, before drawing
            Console.WriteLine(Title);                       // Draw the title on top of the screen

            for (int i = 0; i < Menu.Options.Count; i++)    // Draw the menu
            {
                if (Menu.SelectedOptionIndex == i)          // The current selection is highlighted in blue
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                string currentOption = Menu.GetOptionAt(i);
                Console.Write("   " + currentOption + "   ");
                if (Menu.Options[currentOption] != null)
                {
                    Console.WriteLine(" - " + Menu.Options[currentOption]);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.BackgroundColor = ConsoleColor.Black; // Reset to black after the current selection is drawn.
            }
        }

        // Navigate up and down the menu of the screen.
        public virtual void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Menu.SelectPreviousOption();
                    break;
                case ConsoleKey.DownArrow:
                    Menu.SelectNextOption();
                    break;
            }
        }
    }

    class AttributesScreen : Screen
    {
        private Character Player;

        public AttributesScreen(string title, OptionsMenu menu, Character player)
            : base(title, menu)
        {
            Player = player;
        }

        public override void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Menu.SelectPreviousOption();
                    break;
                case ConsoleKey.DownArrow:
                    Menu.SelectNextOption();
                    break;
                case ConsoleKey.RightArrow:
                    if (Player.IncreaseAttribute == "Health")
                    {
                        Player.IncreaseHealth();
                    }
                    else if (Player.IncreaseAttribute == "Attack")
                    {
                        Player.IncreaseAttack();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Player.DecreaseAttrtibute == "Health")
                    {
                        Player.DecreaseHealth();
                    }
                    else if (Player.DecreaseAttrtibute == "Attack")
                    {
                        Player.DecreaseAttack();
                    }
                    break;
            }
        }
    }

    // This class manages a specific type of screen, only used for the maze.
    // The MazeScreen has no menu, instead the maze matrix is drawn.
    class MazeScreen : Screen
    {
        private MazeRoom Maze;
        private Character Player;
        private string Message;
        public MazeScreen(string title, OptionsMenu menu, MazeRoom maze, Character player)
            : base(title, menu)
        {
            Maze = maze;
            Player = player;
            Message = "";
        }

        public override void Draw()
        {
            // First draw everything that the regular screens have.
            base.Draw();

            // After that draw the maze.
            for (int i = 0; i < Maze.Grid.GetLength(0); i++)
            {
                Console.WriteLine("*-------------------------------*");
                for (int j = 0; j < Maze.Grid.GetLength(1); j++)
                {
                    Console.Write($"| {Maze.Grid[i, j]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("*-------------------------------*");

            Console.WriteLine(Message);

        }


        // For this screen, the arrow keys move the player, instead of menu selection.
        public override void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Maze.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    Maze.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    Maze.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    Maze.MoveRight();
                    break;
            }

            Character character = Maze.EncounteredNPC(Maze.Grid);

            if (character != null)
            {
                Message = Player.Encounter(character);
            }
            else
            {
                Message = "";
            }
        }
    }
}
