using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day2 : IDay
	{
		public long CalculatePuzzle1(string[] lines)
		{
			long horizontal = lines.Where(l => l.StartsWith("forward")).Sum(l => int.Parse(l.Split(' ')[1]));
			long depth = lines.Where(l => l.StartsWith("down")).Sum(l => int.Parse(l.Split(' ')[1])) - lines.Where(l => l.StartsWith("up")).Sum(l => int.Parse(l.Split(' ')[1]));

			return horizontal * depth;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			long horizontal = 0;
			long depth = 0;
			long aim = 0;
			foreach (string line in lines)
			{
				var action = line.Split(' ');
				if(action[0] == "forward")
				{
					horizontal += int.Parse(action[1]);
					depth += aim * int.Parse(action[1]);
				}
				else if(action[0] == "down")
				{
					aim += int.Parse(action[1]);
				}
				else if(action[0] == "up")
				{
					aim -= int.Parse(action[1]);
				}
			}

			return horizontal * depth;
		}
	}
}
