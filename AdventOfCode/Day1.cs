using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day1 : IDay
	{
		public long CalculatePuzzle1(string[] lines)
		{
			var depths = lines.Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s)).ToList();

			int count = 0;
			for (int i = 1; i < depths.Count; i++)
			{
				if (depths[i] > depths[i - 1]) ++count;
			}

			return count;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			var depths = lines.Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s)).ToList();

			int count = 0;
			for (int i = 1; i < depths.Count - 2; i++)
			{
				if ((depths[i] + depths[i + 1] + depths[i + 2]) > (depths[i - 1] + depths[i] + depths[i + 1])) ++count;
			}

			return count;
		}
	}
}
