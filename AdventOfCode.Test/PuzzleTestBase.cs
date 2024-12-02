using System.Reflection;
using System.Text;

namespace AdventOfCode.Test;

public abstract partial class PuzzleTestBase(IPuzzle puzzle)
{
    protected abstract object? Result_Example_PartOne { get; }
    protected abstract object? Result_Example_PartTwo { get; }
    protected abstract object? Result_PartOne { get; }
    protected abstract object? Result_PartTwo { get; }

    [Fact]
    public void Example_PartOne() => Assert.Equal(Result_Example_PartOne, puzzle.PartOne(ReadInput("example_PartOne.txt")));
    [Fact]
    public void Example_PartTwo() => Assert.Equal(Result_Example_PartTwo, puzzle.PartTwo(ReadInput("example_PartTwo.txt")));
    [Fact]
    public void PartOne() => Assert.Equal(Result_PartOne, puzzle.PartOne(ReadInput("input.txt")));
    [Fact]
    public void PartTwo() => Assert.Equal(Result_PartTwo, puzzle.PartTwo(ReadInput("input.txt")));

    private string[] ReadInput(string fileName)
    {
        var puzzleType = puzzle.GetType();
        using var stream = Assembly.GetAssembly(puzzleType)!.GetManifestResourceStream($"{puzzleType.Namespace}.{fileName}");
        using var streamReader = new StreamReader(stream!, Encoding.UTF8);

        List<string> lines = [];
        string? line;
        while ((line = streamReader.ReadLine()) != null)
            lines.Add(line);

        return [.. lines];
    }
}