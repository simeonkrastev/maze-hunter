using System;

namespace Maze_Hunter
{
	internal class Program
	{
		static bool IsRunning = true;

		static void Main(string[] args)
		{
			UI.Init();

			Loop();
		}

		static void Loop()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			while (IsRunning)
			{
				if (keyInfo.Key == ConsoleKey.Escape)
				{
					IsRunning = false;
				}
				else if (keyInfo.Key == ConsoleKey.DownArrow)
				{
					UI.SelectNextOption();
				}
				else if (keyInfo.Key == ConsoleKey.UpArrow)
				{
					UI.SelectPreviousOption();
				}
				else if (keyInfo.Key == ConsoleKey.Enter)
				{
					Update();
				}
				else if (keyInfo.Key == ConsoleKey.W)
				{
					Maze.MoveUp();
				}
				else if (keyInfo.Key == ConsoleKey.S)
				{
					Maze.MoveDown();
				}
				else if (keyInfo.Key == ConsoleKey.A)
				{
					Maze.MoveLeft();
				}
				else if (keyInfo.Key == ConsoleKey.D)
				{
					Maze.MoveRight();
				}

				if (IsRunning)
				{
					UI.Draw();
					keyInfo = Console.ReadKey();
				}
			}

			Environment.Exit(0);
		}

		static void Update()
		{
			if (UI.GetCurrentOption() == "Exit")
			{
				IsRunning = false;
			}
			else
			{
				if (UI.currentScreen == "SelectAlliance")
				{
					// TODO: Assign alliance to the hunter.

					UI.SetScreen("SelectGender"); // Go to next screen
				}
				else if (UI.currentScreen == "SelectGender")
				{
					// TODO: Assign gender to the hunter.

					UI.SetScreen("MainScreen"); // Go to next screen
				}
				else if (UI.currentScreen == "MainScreen")
				{
					if (UI.GetCurrentOption() == "Enter Maze")
					{
						Maze.Init();
						UI.SetScreen("MazeScreen"); // Go to maze
					}
				}
			}
		}
	}
}
