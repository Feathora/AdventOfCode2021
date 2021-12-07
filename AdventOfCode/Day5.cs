using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day5 : IDay
	{
		record class Line(int x1, int y1, int x2, int y2);

		private (int x, int y) ParsePoint(string point)
		{
			var parts = point.Split(',');
			return (int.Parse(parts[0]), int.Parse(parts[1]));
		}

		private List<Line> ParseInput(string[] input)
		{
			var lines = new List<Line>();

			foreach(var line in input)
			{
				var parts = line.Split(" -> ");
				var start = ParsePoint(parts[0]);
				var end = ParsePoint(parts[1]);

				lines.Add(new Line(start.x, start.y, end.x, end.y));
			}

			return lines;
		}

		public long CalculatePuzzle1(string[] input)
		{
			var lines = ParseInput(input);

			int width = Math.Max(lines.Max(l => l.x1), lines.Max(l => l.x2)) + 1;
			int height = Math.Max(lines.Max(l => l.y1), lines.Max(l => l.y2)) + 1;

			var field = new int[width, height];

			foreach(var line in lines.Where(l => l.x1 == l.x2 || l.y1 == l.y2))
			{
				for(int x = Math.Min(line.x1, line.x2); x <= Math.Max(line.x1, line.x2); ++x)
				{
					for(int y = Math.Min(line.y1, line.y2); y <= Math.Max(line.y1, line.y2); ++y)
					{
						++field[x, y];
					}
				}
			}

			long result = 0;
			foreach(int cell in field)
			{
				if (cell > 1) ++result;
			}

			return result;
		}

		public long CalculatePuzzle2(string[] input)
		{
			var lines = ParseInput(input);

			int width = Math.Max(lines.Max(l => l.x1), lines.Max(l => l.x2)) + 1;
			int height = Math.Max(lines.Max(l => l.y1), lines.Max(l => l.y2)) + 1;

			var field = new int[width, height];

			foreach (var line in lines)
			{
				int dx = Math.Sign(line.x2 - line.x1);
				int dy = Math.Sign(line.y2 - line.y1);

				int x = line.x1 - dx, y = line.y1 - dy;
				do
				{
					x += dx;
					y += dy;

					++field[x, y];
				}
				while (x != line.x2 || y != line.y2);
			}

			long result = 0;
			foreach (int cell in field)
			{
				if (cell > 1) ++result;
			}

			return result;
		}
	}
}
