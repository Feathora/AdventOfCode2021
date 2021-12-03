using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day3 : IDay
	{
		public long CalculatePuzzle1(string[] lines)
		{
			var result = "";
			int bits = lines[0].Length;

			for(int i = 0; i < bits; ++i)
			{
				result += lines.GroupBy(l => l[i]).OrderByDescending(gp => gp.Count()).First().Key;
			}

			long gamma = Convert.ToInt64(result, 2);
			long epsilon = (~gamma << (64 - bits)) >> (64 - bits);

			return gamma * epsilon;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			var ratings = lines;
			int i = 0;
			while(ratings.Count() > 1)
			{
				char common = ratings.GroupBy(l => l[i]).OrderByDescending(gp => gp.Key).OrderByDescending(gp => gp.Count()).First().Key;
				ratings = ratings.Where(l => l[i] == common).ToArray();

				++i;
			}

			long oxygen = Convert.ToInt64(ratings.Single(), 2);

			ratings = lines;
			i = 0;
			while (ratings.Count() > 1)
			{
				char uncommon = ratings.GroupBy(l => l[i]).OrderBy(gp => gp.Key).OrderBy(gp => gp.Count()).First().Key;
				ratings = ratings.Where(l => l[i] == uncommon).ToArray();

				++i;
			}

			long co2 = Convert.ToInt64(ratings.Single(), 2);

			return oxygen * co2;
		}
	}
}
