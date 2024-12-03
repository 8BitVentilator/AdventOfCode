global using System.Text.RegularExpressions;

namespace AdventOfCode;

public interface IPuzzle
{
    PuzzleResult Result { get; }
    object PartOne(string[] input);
    object PartTwo(string[] input);
}

public record PuzzleResult(object ExamplePartOne, object ExamplePartTwo, object PartOne, object PartTwo);
