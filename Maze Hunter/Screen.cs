using System;

namespace Maze_Hunter
{
	class Screen
	{
		public string Title;
		public OptionsMenu Menu;

		public Screen(string title, OptionsMenu menu)
		{
			Title = title;
			Menu = menu;
		}

		public virtual void Draw()
		{
			Console.Clear();
			Console.WriteLine(Title);

			for (int i = 0; i < Menu.Options.Length; i++)
			{
				if (Menu.SelectedOptionIndex == i)
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
				}
				Console.WriteLine(Menu.Options[i]);
				Console.BackgroundColor = ConsoleColor.Black;
			}
		}

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

	class MazeScreen : Screen
	{
		private MazeRoom Maze;

		public MazeScreen(string title, OptionsMenu menu, MazeRoom maze) 
			: base (title, menu)
		{
			Maze = maze;
		}

		public override void Draw()
		{
			base.Draw();

			Maze.Draw();
		}

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
		}
	}
}
