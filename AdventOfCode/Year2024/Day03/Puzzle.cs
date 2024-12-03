using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

public partial class Puzzle : IPuzzle
{
    [GeneratedRegex(@"(?<name>mul)\((?<x>\d+),(?<y>\d+)\)")]
    private static partial Regex PartOneRegex();

    [GeneratedRegex(@"(?<name>do)\(\)|(?<name>don't)\(\)|(?<name>mul)\((?<x>\d+),(?<y>\d+)\)")]
    private static partial Regex PartTwoRegex();

    public object PartOne(string[] input) => Process(Instructions(input, PartOneRegex()));

    public object PartTwo(string[] input) => Process(Instructions(input, PartTwoRegex()));

    private static IEnumerable<Match> Instructions(string[] input, Regex regex)
        => input.SelectMany(line => regex.Matches(line));

    private static int Process(IEnumerable<Match> instructions)
        => instructions.Aggregate((process: true, result: 0),
            (acc, instruction) => (instruction.Groups["name"].Value, acc.process) switch
            {
                ("do", _) => (true, acc.result),
                ("don't", _) => (false, acc.result),
                ("mul", true) => (true, acc.result += int.Parse(instruction.Groups["x"].Value) * int.Parse(instruction.Groups["y"].Value)),
                _ => acc
            }).result;
}