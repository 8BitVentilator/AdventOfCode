using AdventOfCode.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
var settings = builder.Configuration.Get<Settings>()!;

var runner = new Runner(settings);
foreach (var puzzle in runner.Run())
{
    Console.WriteLine(puzzle.Name);
    Console.WriteLine($"\tPart One: {puzzle.PartOne}");
    Console.WriteLine($"\tPart Two: {puzzle.PartTwo}");
}
