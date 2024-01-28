using System.Data;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day03;

public partial class Puzzle : IPuzzle
{
    private record PartNumber(int Value, int Row, Range Columns);
    private record Symbol(string Value, int Row, int Column);

    [GeneratedRegex(@"\d+")]
    private static partial Regex PartNumberRegex();

    [GeneratedRegex(@"[^\d.]")]
    private static partial Regex SymbolRegex();

    public object PartOne(string[] input)
        => PartNumbersWithAdjacentSymbols(input)
            .DistinctBy(x => x.PartNumber)
            .Sum(x => x.PartNumber.Value);

    public object PartTwo(string[] input)
        => PartNumbersWithAdjacentSymbols(input)
            .GroupBy(x => x.Symbol)
            .Where(x => x.Key.Value == "*" && x.Count() == 2)
            .Sum(x => x.Aggregate(1, (x, y) => x * y.PartNumber.Value));

    // Die Lösung erzeugt ein Kreuzprodukt mit den Teilenummern und den Symbolen.
    // Dann werden die Kombinationen herausgesucht, bei denen Teilenummer und Symbol benachbart sind.
    // Das Ergebnis ist eine Menge aus allen möglichen Kombinationen.
    private IEnumerable<(PartNumber PartNumber, Symbol Symbol)> PartNumbersWithAdjacentSymbols(string[] input)
    {
        static bool IsAdjacent(PartNumber partNumber, Symbol symbol)
            => Math.Abs(symbol.Row - partNumber.Row) <= 1
                && symbol.Column >= partNumber.Columns.Start.Value - 1
                && symbol.Column <= partNumber.Columns.End.Value + 1;
        
        return PartNumbers(input)
                .SelectMany(_ => Symbols(input), (partNumber, symbol) => (partNumber, symbol))
                .Where(x => IsAdjacent(x.partNumber, x.symbol));
    }

    private IEnumerable<PartNumber> PartNumbers(string[] input)
        => this.Matches(input, PartNumberRegex())
               .Select(x => new PartNumber(int.Parse(x.Match.Value), x.Row, x.Match.Index..(x.Match.Index + x.Match.Length - 1)));

    private IEnumerable<Symbol> Symbols(string[] input)
        => this.Matches(input, SymbolRegex())
               .Select(x => new Symbol(x.Match.Value, x.Row, x.Match.Index));

    private IEnumerable<(int Row, Match Match)> Matches(string[] input, Regex regex)
        => input.Select((line, row) => (row, matches: regex.Matches(line)))
                .SelectMany(x => x.matches, (x, match) => (x.row, match));
}
