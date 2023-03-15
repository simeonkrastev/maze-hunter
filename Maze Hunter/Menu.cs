namespace Maze_Hunter
{
	internal class OptionsMenu
	{
		public string[] Options;
		public int SelectedOptionIndex;

		public OptionsMenu(string[] options)
		{
			Options = options;
			SelectedOptionIndex = 0;
		}

		public void SelectNextOption()
		{
			SelectedOptionIndex = (SelectedOptionIndex + 1) % Options.Length;
		}

		public void SelectPreviousOption()
		{
			if (SelectedOptionIndex == 0)
			{
				SelectedOptionIndex = Options.Length;
			}
			SelectedOptionIndex = (SelectedOptionIndex - 1) % Options.Length;
		}

		public string GetCurrentOptionText()
		{
			return Options[SelectedOptionIndex].Trim();
		}
	}
}
