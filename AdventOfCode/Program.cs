using AdventOfCode;
using System.Reflection;

int currentDay;
IDay day;
if(args.Length > 0)
{
	currentDay = int.Parse(args[0]);
	day = Activator.CreateInstance((string)Assembly.GetExecutingAssembly().GetName().ToString(), $"Day{currentDay}").Unwrap() as IDay;
}
else
{
	var dayType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(nameof(IDay)) != null).OrderByDescending(t => t.Name).FirstOrDefault();
	currentDay = int.Parse(dayType.Name[3..]);

	day = Activator.CreateInstance(dayType) as IDay;
}

var client = new HttpClient
{
	BaseAddress = new Uri("https://adventofcode.com")
};
client.DefaultRequestHeaders.Add("Cookie", $"session={Environment.GetEnvironmentVariable("cookie")}");

var response = await client.GetAsync($"2021/day/{currentDay}/input");
var input = await response.Content.ReadAsStringAsync();
var lines = input.Split('\n');

Console.WriteLine($"Puzzle 1: {day.CalculatePuzzle1(lines)}");
Console.WriteLine($"Puzzle 2: {day.CalculatePuzzle2(lines)}");
