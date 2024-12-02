namespace AdventOfCode.Test;

public abstract partial class PuzzleTestBase(IPuzzle puzzle, int year, int day)
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

    private string[] ReadInput(string fileName) => File.ReadAllLines(@$"Year{year}\Day{day:00}\{fileName}");
}