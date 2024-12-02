using System.Data;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day02;

public class Puzzle : IPuzzle
{
    public object PartOne(string[] input) 
        => Reports(input).Count(IsSafe);

    public object PartTwo(string[] input)
        => Reports(input).Count(report => IsSafe(report) || TolerantReports(report).Any(IsSafe));

    private static IEnumerable<IEnumerable<int>> Reports(string[] input)
        => input.Select(report => Regex.Matches(report, @"\d+"))
                .Select(levels => levels.Select(level => Convert.ToInt32(level.Value)));

    private static IEnumerable<IEnumerable<int>> TolerantReports(IEnumerable<int> report)
        => Enumerable.Range(0, report.Count())
                     .Select(x => report.Where((_, i) => i != x));

    private static bool IsSafe(IEnumerable<int> report)
    {
        static IEnumerable<int> AdjacentDifferences(IEnumerable<int> report)
            => Enumerable.Zip(report, report.Skip(1), (left, right) => right - left);

        static bool IsPositive(int difference) => difference > 0;
        static bool IsNegative(int difference) => difference < 0;
        static bool IsLessOrEqualThree(int difference) => Math.Abs(difference) <= 3;

        var adjacentDifferences = AdjacentDifferences(report).ToList();
        return adjacentDifferences.All(x => IsPositive(x) && IsLessOrEqualThree(x))
            || adjacentDifferences.All(x => IsNegative(x) && IsLessOrEqualThree(x));
    }
}
