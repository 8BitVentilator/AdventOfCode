using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day01;

public class Puzzle : IPuzzle
{
    public object Result_Example_PartOne => 11;
    public object Result_Example_PartTwo => 31;
    public object Result_PartOne => 1765812;
    public object Result_PartTwo => 20520794;

    public object PartOne(string[] input)
        => Enumerable.Zip(Left(input).OrderBy(x => x), Right(input).OrderBy(x => x))
            .Sum(x => Math.Abs(x.First - x.Second));

    public object PartTwo(string[] input)
    {
        var counts = Right(input).CountBy(x => x).ToDictionary();
        return Left(input).Sum(x => x * counts.GetValueOrDefault(x, 0));
    }

    private static IEnumerable<int> Left(string[] input)
        => input.Select(line => Convert.ToInt32(Regex.Match(line, @"\d+").Value));

    private static IEnumerable<int> Right(string[] input)
        => input.Select(line => Convert.ToInt32(Regex.Match(line, @"\d+", RegexOptions.RightToLeft).Value));
}
