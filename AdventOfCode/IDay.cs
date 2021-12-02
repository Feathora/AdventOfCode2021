using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal interface IDay
	{
		long CalculatePuzzle1(string[] lines);
		long CalculatePuzzle2(string[] lines);
	}
}
