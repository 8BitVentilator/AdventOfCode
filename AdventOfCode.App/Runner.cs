using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode.App;
internal class Runner(Settings settings)
{
    private string RegexPattern
        => $"Year{settings.Year}.Day({string.Join('|', settings.Days.Select(x => x.ToString("00")))})";

    private IEnumerable<IPuzzle> Puzzles
        => Assembly.GetAssembly(typeof(IPuzzle))!
                   .GetTypes()
                   .Where(type => type.IsClass && type.IsAssignableTo(typeof(IPuzzle)) && Regex.IsMatch(type.FullName!, RegexPattern))
                   .OrderBy(type => type.FullName)
                   .Select(type => (IPuzzle)Activator.CreateInstance(type)!);

    public IEnumerable<PuzzleResult> Run()
    {
        static int[] YearAndDay(string @namespace) => Regex.Matches(@namespace, "[0-9]+").Select(match => int.Parse(match.Value)).ToArray();
        static string Folder(string @namespace)
        {
            var yearAndDay = YearAndDay(@namespace);
            return $@"Year{yearAndDay[0]}\Day{yearAndDay[1]:00}";
        }

        var sw = new Stopwatch();
        foreach (var puzzle in Puzzles)
        {
            var input = File.ReadAllLines($@"{Folder(puzzle.GetType().FullName!)}\input.txt");
            sw.Start();
            var resultPartOne = puzzle.PartOne(input);
            sw.Stop();
            var timePartOne = sw.ElapsedMilliseconds;

            sw.Restart();
            var resultPartTwo = puzzle.PartTwo(input);
            sw.Stop();
            var timePartTwo = sw.ElapsedMilliseconds;

            yield return new PuzzleResult(
                puzzle.GetType().FullName!,
                resultPartOne, timePartOne,
                resultPartTwo, timePartTwo);
        }
    }
}
