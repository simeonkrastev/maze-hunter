using System;

namespace Maze_Hunter
{
	// The central class for the game logic. 
	class Game
	{
		bool IsRunning = true;		// When set to false, the game loop stops and program exits.
		GameUI UI;					// The UI object holds the visual elements, but no game logic.
		MazeRoom Maze;              // The Maze object holds the game logic, but no UI elements.
		Character Player;
		// Creates a new instance of the game. (Should only be called once in the Main method)
		public Game()
		{
			Maze = new MazeRoom();
			UI = new GameUI(Maze);
		}

		// All games have a central game loop. The process goes as follows:
		// Read input => Apply action => Repeat
		public void Loop()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			while (IsRunning)
			{
				// .Key as in key from the keyboard. Not to be confused with dictionary keys.
				if (keyInfo.Key == ConsoleKey.Escape)		// Whenever ESC is pressed, exit the app.
				{
					IsRunning = false;
				}
				else if (keyInfo.Key == ConsoleKey.Enter)	// Whenever Enter is pressed, apply action.
				{
					Update();
				}
				else
				{                                           // All other keys are passed to the
					UI.HandleKey(keyInfo.Key);              // currently active screen. Each screen 
				}											// has specific logic for different keys

				if (IsRunning)
				{
					UI.Draw();								// Redraw the UI each time a key is pressed.
					keyInfo = Console.ReadKey();
				}
			}

			// When the while-loop is over, the app exits.
		}

		// Handles the user selected options in the menus.
		// The outer if-else block separates different sections for different screens.
		// Each inner if-else block handles the selected options of the corresponding screen.
		void Update()
		{
			if (UI.currentScreen == "StartScreen")
			{
				if (UI.GetMenu().GetCurrentOptionText() == "New Game")
				{
					UI.SetScreen("NewGameScreen");
				}
				else if (UI.GetMenu().GetCurrentOptionText() == "History")
				{
					UI.SetScreen("HistoryScreen");
				}
				else if (UI.GetMenu().GetCurrentOptionText() == "Exit")
				{
					IsRunning = false;
				}

			}
			else if (UI.currentScreen == "NewGameScreen")
			{
				if (UI.GetMenu().GetCurrentOptionText() == "Start Game")
				{
					UI.SetScreen("MazeScreen");
				}
				// For now the other options in the New Game screen do nothing.
				else if (UI.GetMenu().GetCurrentOptionText() == "Back")
				{
					UI.SetScreen("StartScreen");
				}
			}
			else if (UI.currentScreen == "HistoryScreen")
			{
				// For now only the Back option is available.
				if (UI.GetMenu().GetCurrentOptionText() == "Back")
				{
					UI.SetScreen("StartScreen");
				}
			}
			else if (UI.currentScreen == "MazeScreen")
			{
				// TODO: Use a key or an option to get back from the maze to the game menus.
			}
		}
	}
}
