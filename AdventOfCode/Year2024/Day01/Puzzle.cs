using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day01;

public class Puzzle : IPuzzle
{
    public object PartOne(string[] input)
        => Left(input).OrderBy(x => x)
            .Zip(Right(input).OrderBy(x => x), (left, right) => Math.Abs(right - left))
            .Sum();

    public object PartTwo(string[] input)
    {
        var counts = Right(input)
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        return Left(input).Sum(x => x * counts.GetValueOrDefault(x, 0));
    }

    private IEnumerable<int> Left(string[] input)
        => input.Select(line => Convert.ToInt32(Regex.Match(line, @"\d+").Value));

    private IEnumerable<int> Right(string[] input)
        => input.Select(line => Convert.ToInt32(Regex.Match(line, @"\d+", RegexOptions.RightToLeft).Value));
}
