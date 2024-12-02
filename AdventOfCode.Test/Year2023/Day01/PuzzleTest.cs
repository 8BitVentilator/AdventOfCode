using AdventOfCode.Year2023.Day01;

namespace AdventOfCode.Test.Year2023.Day01;

[Trait("Year", "2023")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle())
{
    protected override object? Result_Example_PartOne => 142;
    protected override object? Result_Example_PartTwo => 281;
    protected override object? Result_PartOne => 55607;
    protected override object? Result_PartTwo => 55291;
}
