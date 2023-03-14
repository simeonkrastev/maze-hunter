using System;

namespace Maze_Hunter
{
	internal class UI
	{
		public static string currentScreen;
		public static string Title = "";
		public static string[] Options = { };
		public static int SelectedOption = 0;

		public static void Init()
		{
			Console.SetWindowSize(50, 25);
			Console.SetBufferSize(50, 25);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;

			SetScreen("SelectAlliance");
			Draw();
		}

		public static void Draw()
		{
			Console.Clear();
			Console.WriteLine(Title);

			for (int i = 0; i < Options.Length; i++)
			{
				string brackets = "  "; // double space
				if (SelectedOption == i)
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
					brackets = "[]";
				}
				Console.WriteLine(brackets[0] + Options[i] + brackets[1]);
				Console.BackgroundColor = ConsoleColor.Black;
			}

			if (currentScreen == "MazeScreen")
			{
				Maze.Draw();
			}
		}

		public static void SelectNextOption()
		{
			SelectedOption = (SelectedOption + 1) % Options.Length;
		}

		public static void SelectPreviousOption()
		{
			if (SelectedOption == 0)
			{
				SelectedOption = Options.Length;
			}
			SelectedOption = (SelectedOption - 1) % Options.Length;
		}

		public static string GetCurrentOption()
		{
			return Options[SelectedOption].Trim();
		}

		public static void SetScreen(string newScreen)
		{
			currentScreen = newScreen;
			SelectedOption = 0;

			if (currentScreen == "SelectAlliance")
			{
				Title = "==================================================\n" +
						"=====            Select Alliance!            =====\n" +
						"==================================================\n";

				Options = new string[] {
					"   Good  ",
					"   Evil  "
				};
			} 
			else if (currentScreen == "SelectGender")
			{
				Title = "==================================================\n" +
						"=====             Select Gender!             =====\n" +
						"==================================================\n";

				Options = new string[] {
					"    Male   ",
					"   Female  "
				};
			} if (currentScreen == "MainScreen")
			{
				Title = "==================================================\n" +
						"=====              Hello Hunter!             =====\n" +
						"==================================================\n";

				Options = new string[] {
					"     Enter Maze    ",
					"   View Character  ",
					" Rebuild Character ",
					"        Exit       "
				};
			} else if (currentScreen == "MazeScreen")
			{
				Title = "==================================================\n" +
						"=====                  MAZE!                 =====\n" +
						"==================================================\n";

				Options = new string[] { };
			}
		}
	}
}