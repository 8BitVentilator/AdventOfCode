using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode.App;

internal class Runner(Settings settings)
{
    public IEnumerable<PuzzleResult> Run()
    {
        static int[] YearAndDay(string @namespace) => Regex.Matches(@namespace, "[0-9]+").Select(match => int.Parse(match.Value)).ToArray();
        static string Folder(string @namespace)
        {
            var yearAndDay = YearAndDay(@namespace);
            return $@"Year{yearAndDay[0]}\Day{yearAndDay[1]:00}";
        }

        foreach (var puzzle in Puzzles)
        {
            var input = File.ReadAllLines($@"{Folder(puzzle.GetType().FullName!)}\input.txt");
            var (partOneresult, partOneElapsedMilliseconds) = RunPuzzlePart(() => puzzle.PartOne(input));
            var (partTworesult, partTwoElapsedMilliseconds) = RunPuzzlePart(() => puzzle.PartTwo(input));

            yield return new PuzzleResult(
                puzzle.GetType().Namespace ?? "",
                partOneresult, partOneElapsedMilliseconds,
                partTworesult, partTwoElapsedMilliseconds
            );
        }
    }
    private string RegexPattern
    => $"Year{settings.Year}.Day({string.Join('|', settings.Days.Select(x => x.ToString("00")))})";

    private IEnumerable<IPuzzle> Puzzles
        => Assembly.GetAssembly(typeof(IPuzzle))!
                   .GetTypes()
                   .Where(type => type.IsClass && type.IsAssignableTo(typeof(IPuzzle)) && Regex.IsMatch(type.FullName!, RegexPattern))
                   .OrderBy(type => type.FullName)
                   .Select(type => (IPuzzle)Activator.CreateInstance(type)!);

    private static (object? result, long? elapsedMilliseconds) RunPuzzlePart(Func<object> part)
    {
        try
        {
            var sw = Stopwatch.StartNew();
            var result = part.Invoke();
            sw.Stop();

            return (result, sw.ElapsedMilliseconds);
        }
        catch (NotImplementedException)
        {
            return (null, null);
        }
    }
}
