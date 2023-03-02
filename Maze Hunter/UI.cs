using System;

namespace Maze_Hunter
{
	internal class UI
	{
		public static string screenName;
		public static string screenData;
		public static string[] options;

		public static int selectedOption = 0;

		public static void Init()
		{
			Console.SetWindowSize(50, 20);
			Console.SetBufferSize(50, 20);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.CursorVisible = false;

			SetScreen("SelectAlliance");
			Draw();
		}

		public static void Draw()
		{
			Console.Clear();
			Console.WriteLine(screenData);

			for (int i = 0; i < options.Length; i++)
			{
				string brackets = "  "; // double space
				if (selectedOption == i)
				{
					brackets = "[]";
				}
				Console.WriteLine(brackets[0] + options[i] + brackets[1]);
			}
		}

		public static void SelectNextOption()
		{
			selectedOption = (selectedOption + 1) % options.Length;
		}

		public static void SelectPreviousOption()
		{
			if (selectedOption == 0)
			{
				selectedOption = options.Length;
			}
			selectedOption = (selectedOption - 1) % options.Length;
		}

		public static string GetCurrentOption()
		{
			return options[selectedOption].Trim();
		}

		public static void SetScreen(string newScreen)
		{
			screenName = newScreen;
			selectedOption = 0;
			switch (screenName)
			{
				case "SelectAlliance":
					UI.screenData = Screens.SelectAllianceScreen;
					UI.options = Screens.SelectAllianceOptions;
					break;
				case "SelectGender":
					UI.screenData = Screens.SelectGenderScreen;
					UI.options = Screens.SelectGenderOptions;
					break;
				case "MainScreen":
					UI.screenData = Screens.MainScreen;
					UI.options = Screens.MainScreenOptions;
					break;
			}
		}
	}
}