using System;

namespace Maze_Hunter
{
	internal class MazeRoom
	{
		public char[,] Grid = new char[8, 8];

		public static int[] position;

		public MazeRoom()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Grid[i, j] = ' ';
				}
			}

			position = new int[2] {0, 0};
			Grid[position[0], position[1]] = 'P';
		}

		public string GetRowString(int row)
		{
			string rowString = "";

			for (int i = 0; i < 8; i++)
			{
				rowString += $"| {Grid[row, i]} ";
			}

			return rowString;
		}

		public void MoveUp()
		{
			if (position[0] > 0)
			{
				Grid[position[0], position[1]] = ' ';
				position[0]--;
				Grid[position[0], position[1]] = 'P';
			}
		}

		public void MoveDown()
		{
			if (position[0] < Grid.GetLength(0) - 1)
			{
				Grid[position[0], position[1]] = ' ';
				position[0]++;
				Grid[position[0], position[1]] = 'P';
			}
		}

		public void MoveLeft()
		{
			if (position[1] > 0)
			{
				Grid[position[0], position[1]] = ' ';
				position[1]--;
				Grid[position[0], position[1]] = 'P';
			}
		}

		public void MoveRight()
		{
			if (position[1] < Grid.GetLength(1) - 1)
			{
				Grid[position[0], position[1]] = ' ';
				position[1]++;
				Grid[position[0], position[1]] = 'P';
			}
		}

		public void Draw()
		{
			for (int i = 0; i < Grid.GetLength(0); i++)
			{
				Console.WriteLine("*-------------------------------*");
				for (int j = 0; j < Grid.GetLength(1); j++)
				{
					Console.Write($"| {Grid[i, j]} ");
				}
				Console.WriteLine("|");
			}
			Console.WriteLine("*-------------------------------*");
		}
	}
}
