namespace Maze_Hunter
{
	// The OptionsMenu class manages navigation with the menus.
	// The menus are array of selectable options, where each option is just a string.
	class OptionsMenu
	{
		public string[] Options;
		public string[] OptionParams;
		public int SelectedOptionIndex;

		public OptionsMenu(string[] options)
		{
			Options = options;
			OptionParams = new string[options.Length];
			SelectedOptionIndex = 0;
		}

		public void SelectNextOption()
		{
			// The ... % Options.Length; ... part is used to rotate after the last option.
			SelectedOptionIndex = (SelectedOptionIndex + 1) % Options.Length;
		}

		public void SelectPreviousOption()
		{
			// When the cursor is on the first option, the previous should rotate to the last.
			if (SelectedOptionIndex == 0)
			{
				SelectedOptionIndex = Options.Length;
			}
			SelectedOptionIndex = SelectedOptionIndex - 1;
		}

		public string GetCurrentOptionText()
		{
			return Options[SelectedOptionIndex].Trim();
		}
	}
}
