using System;
using System.Collections.Generic;

namespace Maze_Hunter
{
	// The GameUI class manages the cretion of different screens and switching between them.
	// All the game screens are initialized on program start and are kept in a dictionary.
	// Only one screen is active at a time.
	class GameUI
	{
		public string currentScreen;				// The key to the currently active screen
		Dictionary<string, Screen> gameScreens;

		public GameUI(MazeRoom maze)
		{
			Console.SetWindowSize(50, 25);			
			Console.SetBufferSize(50, 25);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;			// No need for a blinking cursor.

			InitScreens(maze);
			SetScreen("StartScreen");
		}

		public void Draw()							// Draws the currently active screen.
		{
			gameScreens[currentScreen].Draw();
		}

		public OptionsMenu GetMenu()				// Returns the menu of the current screen.
		{
			return gameScreens[currentScreen].Menu;
		}

		public void SetScreen(string newScreen)		// Sets a screen by key.
		{
			currentScreen = newScreen;
			Draw();
		}

		public void HandleKey(ConsoleKey key)		// When a key is pressed, this method forwards
		{											// the command to the current screen.
			gameScreens[currentScreen].HandleKey(key);
		}

		private void InitScreens(MazeRoom maze)     // Creates a dict with all the screens in the game.
		{
			gameScreens = new Dictionary<string, Screen>();

			// To create a new screen, add a method that returns 
			// a new Screen instance and invoke that method here.
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
				// TODO: add more options here when implementing the History feature.
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

			// The Maze screen has no menu in it.
			string[] options = new string[] {};

			OptionsMenu menu = new OptionsMenu(options);

			return new MazeScreen(title, menu, maze);
		}
	}
}