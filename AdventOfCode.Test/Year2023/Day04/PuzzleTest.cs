using AdventOfCode.Year2023.Day04;

namespace AdventOfCode.Test.Year2023.Day04;

[Trait("Year", "2023")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle())
{
    protected override object? Result_Example_PartOne => 13;
    protected override object? Result_Example_PartTwo => 30;
    protected override object? Result_PartOne => 17782;
    protected override object? Result_PartTwo => 8477787;
}
