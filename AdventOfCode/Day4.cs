using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	internal class Day4 : IDay
	{
		class Card
		{
			public KeyValuePair<int, bool>[,] Numbers { get; set; } = new KeyValuePair<int, bool>[5, 5];

			public int Score
			{
				get
				{
					int result = 0;
					foreach(var pair in Numbers)
					{
						if (!pair.Value) result += pair.Key;
					}
					return result;
				}
			}

			public bool SetNumber(int number)
			{
				for(int y = 0; y < Numbers.GetLength(0); y++)
				{
					for(int x = 0; x < Numbers.GetLength(1); x++)
					{
						if(Numbers[y, x].Key == number)
						{
							Numbers[y, x] = new KeyValuePair<int, bool>(number, true);

							return CheckRow(y) || CheckColumn(x);
						}
					}
				}

				return false;
			}

			private bool CheckRow(int row)
			{
				for(int column = 0; column < Numbers.GetLength(1); column++)
				{
					if (!Numbers[row, column].Value) return false;
				}

				return true;
			}

			private bool CheckColumn(int column)
			{
				for(int row = 0; row < Numbers.GetLength(0); row++)
				{
					if(!Numbers[row, column].Value) return false;
				}

				return true;
			}
		}

		private List<Card> InitializeCards(string[] lines)
		{
			var cards = new List<Card>();

			for (int i = 2; i < lines.Length; i += 5)
			{
				var card = new Card();
				for (int y = 0; y < 5; ++y)
				{
					var rowNumbers = lines[i + y].Trim().Replace("  ", " ").Split(' ');
					for (int x = 0; x < 5; x++)
					{
						card.Numbers[y, x] = new KeyValuePair<int, bool>(int.Parse(rowNumbers[x]), false);
					}
				}
				cards.Add(card);

				i += 1;
			}

			return cards;
		}

		public long CalculatePuzzle1(string[] lines)
		{
			var input = lines[0].Split(",").Select(l => int.Parse(l));
			var cards = InitializeCards(lines);

			foreach(var number in input)
			{
				foreach(var card in cards)
				{
					if(card.SetNumber(number))
					{
						return card.Score * number;
					}
				}
			}

			return 0;
		}

		public long CalculatePuzzle2(string[] lines)
		{
			var input = lines[0].Split(",").Select(l => int.Parse(l));
			var cards = InitializeCards(lines);

			foreach(var number in input)
			{
				for(int i = cards.Count - 1; i >= 0; i--)
				{
					if(cards[i].SetNumber(number))
					{
						if(cards.Count > 1)
						{
							cards.RemoveAt(i);
						}
						else
						{
							return cards[i].Score * number;
						}
					}
				}
			}

			return 0;
		}
	}
}
