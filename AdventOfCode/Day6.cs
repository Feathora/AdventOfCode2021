using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day6 : IDay
	{
		public long CalculatePuzzle1(string[] lines)
		{
			var fish = lines[0].Split(',').Select(n => int.Parse(n)).ToList();

			for(int i = 0; i < 80; ++i)
			{
				for(int f = fish.Count - 1; f >= 0; --f)
				{
					if(fish[f] == 0)
					{
						fish[f] = 6;
						fish.Add(8);
					}
					else
					{
						--fish[f];
					}
				}
			}

			return fish.Count;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			var fish = lines[0].Split(',').Select(n => int.Parse(n)).ToList();
			var cycles = new long[9];

			foreach(var f in fish)
			{
				++cycles[f];
			}

			for (int i = 0; i < 256; ++i)
			{
				long one = cycles[1];
				for(int c = 1; c < cycles.Length - 1; ++c)
				{
					cycles[c] = cycles[c + 1];
				}

				cycles[cycles.Length - 1] = cycles[0];
				cycles[cycles.Length - 3] += cycles[0];
				cycles[0] = one;
			}

			return cycles.Sum();
		}
	}
}
