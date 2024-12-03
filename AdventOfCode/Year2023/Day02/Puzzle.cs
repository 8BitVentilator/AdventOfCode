namespace AdventOfCode.Year2023.Day02;

public class Puzzle : IPuzzle
{
    public PuzzleResult Result { get; } = new(
        ExamplePartOne: 8,
        ExamplePartTwo: 2286,
        PartOne: 2317,
        PartTwo: 74804
    );

    public object PartOne(string[] input) 
        => input.Select(Game)
                .Where(game => game.Red <= 12 && game.Green <= 13 && game.Blue <= 14)
                .Sum(game => game.Id);

    public object PartTwo(string[] input) 
        => input.Select(Game)
                .Sum(game => game.Red * game.Green * game.Blue);

    private static (int Id, int Red, int Green, int Blue) Game(string line)
        => (Id: Parse(line, @"Game (\d+)").First(),
            Red: Parse(line, @"(\d+) red").Max(),
            Green: Parse(line, @"(\d+) green").Max(),
            Blue: Parse(line, @"(\d+) blue").Max());

    private static IEnumerable<int> Parse(string line, string regex)
        => Regex.Matches(line, regex)
                .Select(match => int.Parse(match.Groups[1].Value));
}
