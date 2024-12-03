namespace AdventOfCode;

public interface IPuzzle
{
    object Result_Example_PartOne { get; }
    object Result_Example_PartTwo { get; }
    object Result_PartOne { get; }
    object Result_PartTwo { get; }

    object PartOne(string[] input);
    object PartTwo(string[] input);
}
