using System;

namespace Maze_Hunter
{
	// The central class for the game logic. 
	class Game
	{
		bool IsRunning = true;		// When set to false, the game loop stops and program exits.
		GameUI UI;					// The UI object holds the visual elements, but no game logic.
		MazeRoom Maze;              // The Maze object holds the game logic, but no UI elements.
		public Character Player;
		// Creates a new instance of the game. (Should only be called once in the Main method)
		public Game()
		{
			Maze = new MazeRoom();
			UI = new GameUI(Maze);
			Player = new Character();
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
                    SetMenuParams();
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
				//indicate that each of the options leads to its own screen
				
				else if (UI.GetMenu().GetCurrentOptionText() == "Guild")
				{
					UI.SetScreen("GuildScreen");
					
				}
                else if (UI.GetMenu().GetCurrentOptionText() == "Gender")
                {
                    UI.SetScreen("GenderScreen");

                }
                else if (UI.GetMenu().GetCurrentOptionText() == "Name")
                {
                    UI.SetScreen("NameScreen");
					
                }
                else if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("StartScreen");
                }
                else if (UI.GetMenu().GetCurrentOptionText() == "Attributes")
                {
                    UI.SetScreen("AttributesScreen");

                }
                else if (UI.GetMenu().GetCurrentOptionText() == "Randomize")
                {
                    UI.SetScreen("RandomizeScreen");

                }
            }
			//fill each of those screens with their own options

			else if(UI.currentScreen == "GuildScreen")
			{
                if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }
            else if (UI.currentScreen == "GenderScreen")
            {
                if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }
            else if (UI.currentScreen == "NameScreen")
            {
                if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
				else if (UI.GetMenu().GetCurrentOptionText() == "Enter Name")
				{
					UI.SetScreen("NameEnter");
					

                    if (UI.GetMenu().GetCurrentOptionText() == "Save Name")
                    {
                        NameEnter();
                        UI.SetScreen("NewGameScreen");
                        SetMenuParams(); // Updates New Name on Select screen
                    }
                }
            }
            else if (UI.currentScreen == "AttributesScreen")
            {
                if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }
            else if (UI.currentScreen == "RandomizeScreen")
            {
                if (UI.GetMenu().GetCurrentOptionText() == "Back")
                {
                    UI.SetScreen("NewGameScreen");
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
		void NameEnter()
		{
            Console.CursorVisible = true;
            Player.Name = Console.ReadLine();
            Console.CursorVisible = false;
		}

		void SetMenuParams()
		{
            if (Player.Guild != null)
			{
                UI.GetMenu().OptionParams[0] = Player.Guild;
            }
			
			if(Player.Name != null)
			{
				UI.GetMenu().OptionParams[2] = Player.Name;
			}
			
		}
	}
}
