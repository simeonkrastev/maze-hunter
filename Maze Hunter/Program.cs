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
				if (UI.screenName == "SelectAlliance")
				{
					// TODO: Assign alliance to the hunter.

					UI.SetScreen("SelectGender"); // Go to next screen
				}
				else if (UI.screenName == "SelectGender")
				{
					// TODO: Assign geender to the hunter.

					UI.SetScreen("MainScreen"); // Go to next screen
				}
			}
		}
	}
}

// > Select Alliance
//		Good
//		Evil
// > Select Gender
//		Male
//		Female
// > Select Name
//		Enter name
//		Generate name
// > Distribute stats

// Welcome to Maze Hunter
// - Enter Maze
// - View Character
// - Rebuild Character
// - Exit
