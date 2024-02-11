using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day05;

public partial class Puzzle : IPuzzle
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    record Range(ulong Start, ulong Length)
    {
        public ulong End => Start + Length - 1;
    }

    record Mapping(ulong Destination, Range Source)
    {
        public Range? Map(Range range)
        {
            var start = Math.Max(range.Start, Source.Start);
            var end = Math.Min(range.End, Source.End);

            return start <= end
                ? new Range(Destination + (start - Source.Start), end - start + 1)
                : null;
        }
    }

    record MappingCollection(IReadOnlyCollection<Mapping> Mappings)
    {
        public IEnumerable<Range> Map(Range range)
        {
            var result = Mappings.Select(mapping => mapping.Map(range))
                                 .Where(mapping => mapping is not null);

            return result.Any()
                    ? result.Cast<Range>()
                    : [range];
        }
    }
    
    record Almanac(IEnumerable<Range> Seeds,
                   MappingCollection SeedToSoil,
                   MappingCollection SoilToFertilizer,
                   MappingCollection FertilizerToWater,
                   MappingCollection WaterToLight,
                   MappingCollection LightToTemperature,
                   MappingCollection TemperatureToHumidity,
                   MappingCollection HumidityToLocation);

    public object PartOne(string[] input)
        => LowestLocation(Parse(input, ParseSeedsPartOne));

    public object PartTwo(string[] input) 
        => LowestLocation(Parse(input, ParseSeedsPartTwo));

    private ulong LowestLocation(Almanac almanac)
        => almanac.Seeds
            .SelectMany(almanac.SeedToSoil.Map)
            .SelectMany(almanac.SoilToFertilizer.Map)
            .SelectMany(almanac.FertilizerToWater.Map)
            .SelectMany(almanac.WaterToLight.Map)
            .SelectMany(almanac.LightToTemperature.Map)
            .SelectMany(almanac.TemperatureToHumidity.Map)
            .SelectMany(almanac.HumidityToLocation.Map)
            .Min(x => x.Start);

    private IEnumerable<Range> ParseSeedsPartOne(IEnumerable<ulong> seeds)
        => seeds.Select(x => new Range(x, 1));

    private IEnumerable<Range> ParseSeedsPartTwo(IEnumerable<ulong> values)
        => values.Chunk(2).Select(x => new Range(x[0], x[1]));

    private Almanac Parse(string[] input, Func<IEnumerable<ulong>, IEnumerable<Range>> parseSeeds)
    {
        IEnumerable<string> Section(string name)
            => input.SkipWhile(line => !line.StartsWith(name))
                    .TakeWhile(line => !string.IsNullOrEmpty(line));

        IEnumerable<ulong> SeedValues()
            => NumberRegex().Matches(Section("seeds").Single())
                .Select(match => ulong.Parse(match.Value));

        IReadOnlyCollection<Mapping> ParseMapping(string name)
            => Section(name).Skip(1)
                .Select(line => NumberRegex().Matches(line))
                .Select(matches => new Mapping(
                    Destination: ulong.Parse(matches[0].Value),
                    Source: new Range(
                        Start: ulong.Parse(matches[1].Value),
                        Length: ulong.Parse(matches[2].Value))
                    )
                ).ToList();

        return new(
            Seeds: parseSeeds(SeedValues()),
            SeedToSoil: new MappingCollection(ParseMapping("seed-to-soil map")),
            SoilToFertilizer: new MappingCollection(ParseMapping("soil-to-fertilizer map")),
            FertilizerToWater: new MappingCollection(ParseMapping("fertilizer-to-water map")),
            WaterToLight: new MappingCollection(ParseMapping("water-to-light map")),
            LightToTemperature: new MappingCollection(ParseMapping("light-to-temperature map")),
            TemperatureToHumidity: new MappingCollection(ParseMapping("temperature-to-humidity map")),
            HumidityToLocation: new MappingCollection(ParseMapping("humidity-to-location map"))
       );
    }
}
