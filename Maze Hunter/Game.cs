using System;

namespace Maze_Hunter
{
	// The central class for the game logic. 
	class Game
	{
		Random rand = new Random();
		bool IsRunning = true;		// When set to false, the game loop stops and program exits.
		GameUI UI;					// The UI object holds the visual elements, but no game logic.
		MazeRoom Maze;              // The Maze object holds the game logic, but no UI elements.
		public Character Player;

		// Creates a new instance of the game. (Should only be called once in the Main method)
		public Game()
		{
			Maze = new MazeRoom();
			Player = new Character();
			UI = new GameUI(Maze, Player);
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
			string currentOptionText = UI.GetMenu().GetCurrentOptionText();

			if (UI.currentScreen == "StartScreen")
			{   
				if (currentOptionText == "New Game")
				{
					UI.SetScreen("NewGameScreen");
                }
				else if (currentOptionText == "History")
				{
					UI.SetScreen("HistoryScreen");
				}
				else if (currentOptionText == "Exit")
				{
					IsRunning = false;
				}
			}

			else if (UI.currentScreen == "NewGameScreen")
			{
				if (currentOptionText == "Start Game")
				{
					UI.SetScreen("MazeScreen");
				}

				// For now the other options in the New Game screen do nothing.
				else if (currentOptionText == "Back")
				{
					UI.SetScreen("StartScreen");
				}
				//indicate that each of the options leads to its own screen
				
				else if (currentOptionText == "Guild")
				{
					UI.SetScreen("GuildScreen");
				}
                else if (currentOptionText == "Gender")
                {
                    UI.SetScreen("GenderScreen");
                }
                else if (currentOptionText == "Name")
                {
                    UI.SetScreen("NameScreen");
                }
                else if (currentOptionText == "Back")
                {
                    UI.SetScreen("StartScreen");
                }
                else if (currentOptionText == "Attributes")
                {
					UI.SetScreen("AttributesScreen");
				}
                else if (currentOptionText == "Randomize")
                {
                    UI.SetScreen("RandomizeScreen");
                }
            }

			else if (UI.currentScreen == "GuildScreen")
			{
				if (currentOptionText == "Guild Of Thieves")
                {
                    Player.GuildChecker = 1;
                    Player.Guilds();
					UI.SetScreen("NewGameScreen");
				}
				else if (currentOptionText == "Guild Of Assassins")
                {
                    Player.GuildChecker = 2;
                    Player.Guilds();
					UI.SetScreen("NewGameScreen");
				}
                else if (currentOptionText == "Random")
                {
                    Player.RandomGuild();
                    UI.SetScreen("NewGameScreen");
                }
                else if (currentOptionText == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }

            else if (UI.currentScreen == "GenderScreen")
            {
                if (currentOptionText == "Male")
                {
					Player.Male();
                    UI.SetScreen("NewGameScreen");
                }
                if (currentOptionText == "Female")
                {
					Player.Female();
                    UI.SetScreen("NewGameScreen");
                }
                if (currentOptionText == "Random")
                {
					Player.RandomGender();	
                    UI.SetScreen("NewGameScreen");
                }
                if (currentOptionText == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }

            else if (UI.currentScreen == "NameScreen")
            {
                if (currentOptionText == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
				else if (currentOptionText == "Enter Name")
				{
					UI.SetScreen("NameEnter");
					

                    if (UI.GetMenu().GetCurrentOptionText() == "Save Name")
                    {
                        NameEnter();
                        UI.SetScreen("NewGameScreen");
                    }
                }
				else if(currentOptionText == "Random Name")
				{
					Player.RandomName();
                    UI.SetScreen("NewGameScreen");
                }
            }

            else if (UI.currentScreen == "AttributesScreen")
            {
				if (currentOptionText == "Health:")
				{
					Player.IncreaseAttribute = "Health";
					Player.DecreaseAttrtibute = "Health";
				} 
				if (currentOptionText == "Attack:")
                {
                    Player.IncreaseAttribute = "Attack";
                    Player.DecreaseAttrtibute = "Attack";
                }
				if (currentOptionText == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
            }

            else if (UI.currentScreen == "RandomizeScreen")
            {
                
                if (currentOptionText == "Back")
                {
                    UI.SetScreen("NewGameScreen");
                }
				else if(currentOptionText == "Randomize all")
				{
                    Player.RandomGender();
                    Player.RandomName();
					Player.RandomAttributes();
					Player.RandomGuild();
					UI.SetScreen("NewGameScreen");
					//RandomAttributes( *when ready* ); 
				}
            }

            else if (UI.currentScreen == "HistoryScreen")
			{
				// For now only the Back option is available.
				if (currentOptionText == "Back")
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
		
	}
}
