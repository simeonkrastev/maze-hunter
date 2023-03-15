using System;

namespace Maze_Hunter
{
	internal class Game
	{
		bool IsRunning = true;
		GameUI UI;
		MazeRoom Maze;

		public Game()
		{
			Maze = new MazeRoom();
			UI = new GameUI(Maze);
		}

		public void Loop()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			while (IsRunning)
			{
				if (keyInfo.Key == ConsoleKey.Escape)
				{
					IsRunning = false;
				}
				else if (keyInfo.Key == ConsoleKey.Enter)
				{
					Update();
				}
				else
				{
					UI.HandleKey(keyInfo.Key);
				}

				if (IsRunning)
				{
					UI.Draw();
					keyInfo = Console.ReadKey();
				}
			}

			Environment.Exit(0);
		}

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
				else if (UI.GetMenu().GetCurrentOptionText() == "Back")
				{
					UI.SetScreen("StartScreen");
				}
			}
			else if (UI.currentScreen == "HistoryScreen")
			{
				if (UI.GetMenu().GetCurrentOptionText() == "Back")
				{
					UI.SetScreen("StartScreen");
				}
			}
			else if (UI.currentScreen == "MazeScreen")
			{
				
			}
		}
	}
}
