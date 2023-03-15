using System;
using System.Collections.Generic;

namespace Maze_Hunter
{
	internal class GameUI
	{
		public string currentScreen;
		Dictionary<string, Screen> gameScreens;

		public GameUI(MazeRoom maze)
		{
			Console.SetWindowSize(50, 25);
			Console.SetBufferSize(50, 25);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;

			InitScreens(maze);
			SetScreen("StartScreen");
		}

		public void Draw()
		{
			gameScreens[currentScreen].Draw();
		}

		public OptionsMenu GetMenu()
		{
			return gameScreens[currentScreen].Menu;
		}

		public void SetScreen(string newScreen)
		{
			currentScreen = newScreen;
			Draw();
		}

		public void HandleKey(ConsoleKey key)
		{
			gameScreens[currentScreen].HandleKey(key);
		}

		private void InitScreens(MazeRoom maze)
		{
			gameScreens = new Dictionary<string, Screen>();

			gameScreens["StartScreen"] = CreateStartScreen();
			gameScreens["NewGameScreen"] = CreateNewGameScreen();
			gameScreens["HistoryScreen"] = CreateHistoryScreen();
			gameScreens["MazeScreen"] = CreateMazeScreen(maze);
		}

		private Screen CreateStartScreen()
		{
			string title =	"==================================================\n" +
							"=====              Hello Warrior!            =====\n" +
							"==================================================\n";

			string[] options = new string[] {
				"   New Game  ",
				"   History   ",
				"   Exit      "
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new Screen(title, menu);

		}

		private Screen CreateNewGameScreen()
		{
			string title =	"==================================================\n" +
							"=====                New Game!               =====\n" +
							"==================================================\n";

			string[] options = new string[] {
				"   Guild       ",
				"   Gender      ",
				"   Name        ",
				"   Attributes  ",
				"   Randomize   ",
				"   Start Game  ",
				"   Back  ",
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new Screen(title, menu);
		}

		private Screen CreateHistoryScreen()
		{
			string title =  "==================================================\n" +
							"=====                 History!               =====\n" +
							"==================================================\n";

			string[] options = new string[] {
				"    Back    "
			};

			OptionsMenu menu = new OptionsMenu(options);

			return new Screen(title, menu);
		}

		private Screen CreateMazeScreen(MazeRoom maze)
		{
			string title =	"==================================================\n" +
							"=====                  MAZE!                 =====\n" +
							"==================================================\n";

			string[] options = new string[] {};

			OptionsMenu menu = new OptionsMenu(options);

			return new MazeScreen(title, menu, maze);
		}
	}
}