using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day7 : IDay
	{
		public long CalculatePuzzle1(string[] lines)
		{
			var crabs = lines[0].Split(',').Select(n => int.Parse(n));

			int start = crabs.Min();
			int end = crabs.Max();

			int lowest = int.MaxValue, fuel;
			for(int i = start; i <= end; i++)
			{
				fuel = 0;
				foreach(int crab in crabs)
				{
					fuel += Math.Abs(crab - i);
					if (fuel > lowest) break;
				}
				lowest = Math.Min(fuel, lowest);
			}

			return lowest;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			var crabs = lines[0].Split(',').Select(n => int.Parse(n));

			int start = crabs.Min();
			int end = crabs.Max();

			long lowest = long.MaxValue, fuel;
			for (int i = start; i <= end; i++)
			{
				fuel = 0;
				foreach (int crab in crabs)
				{
					int n = Math.Abs(crab - i);
					fuel += (n * (n + 1)) / 2;
					if (fuel > lowest) break;
				}
				lowest = Math.Min(fuel, lowest);
			}

			return lowest;
		}
	}
}
