namespace AdventOfCode.Year2023.Day01;

public class Puzzle : IPuzzle
{
    public PuzzleResult Result => new(
        ExamplePartOne: 142,
        ExamplePartTwo: 281,
        PartOne: 55607,
        PartTwo: 55291
    );

    public object PartOne(string[] input)
        => Solve(input, @"\d");

    public object PartTwo(string[] input)
        => Solve(input, @"\d|one|two|three|four|five|six|seven|eight|nine");

    private static object Solve(string[] input, string regex)
        => input.Select(line => (
                First: Regex.Match(line, regex).Value, 
                Last: Regex.Match(line, regex, RegexOptions.RightToLeft).Value)
            ).Sum(matches => 10 * Digit(matches.First) + Digit(matches.Last));

    private static int Digit(string text) => text switch
    {
       "one" => 1,
       "two" => 2,
       "three" => 3,
       "four" => 4,
       "five" => 5,
       "six" => 6,
       "seven" => 7,
       "eight" => 8,
       "nine" => 9,
        _ => int.Parse(text)
    };
    
}
