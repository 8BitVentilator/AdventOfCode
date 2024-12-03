namespace AdventOfCode.Year2023.Day05;

public partial class Puzzle : IPuzzle
{
    public PuzzleResult Result { get; } = new(
        ExamplePartOne: 35L,
        ExamplePartTwo: 0,
        PartOne: 173706076L,
        PartTwo: 0
    );

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    record Map(long Destination, long Source, long Range);
    
    record Almanac(IReadOnlySet<long> Seeds,
                   IReadOnlySet<Map> SeedToSoil,
                   IReadOnlySet<Map> SoilToFertilizer,
                   IReadOnlySet<Map> FertilizerToWater,
                   IReadOnlySet<Map> WaterToLight,
                   IReadOnlySet<Map> LightToTemperature,
                   IReadOnlySet<Map> TemperatureToHumidity,
                   IReadOnlySet<Map> HumidityToLocation);

    public object PartOne(string[] input)
    {
        var almanac = Parse(input);

        return almanac.Seeds
                .Select(seed => Map2(seed, almanac.SeedToSoil))
                .Select(soil => Map2(soil, almanac.SoilToFertilizer))
                .Select(fertilizer => Map2(fertilizer, almanac.FertilizerToWater))
                .Select(water => Map2(water, almanac.WaterToLight))
                .Select(light => Map2(light, almanac.LightToTemperature))
                .Select(temperture => Map2(temperture, almanac.TemperatureToHumidity))
                .Select(humidity => Map2(humidity, almanac.HumidityToLocation))
                .Min();
    }



    public object PartTwo(string[] input)
    {
        return "";
    }

    private long Map2(long source, IReadOnlySet<Map> maps)
    {
        var map = maps.FirstOrDefault(map => source >= map.Source && source <= map.Source + map.Range);
        
        return map is not default(Map)
                ? map.Destination + (source - map.Source)
                : source;
    }

    private Almanac Parse(string[] input)
    {
        IEnumerable<string> Section(string name)
            => input.SkipWhile(line => !line.StartsWith(name))
                    .TakeWhile(line => !string.IsNullOrEmpty(line));

        IReadOnlySet<long> ParseSeeds()
            => NumberRegex().Matches(Section("seeds").First())
                .Select(match => long.Parse(match.Value))
                .ToHashSet();

        IReadOnlySet<Map> ParseMap(string name)
            => Section(name).Skip(1)
                .Select(line => NumberRegex().Matches(line))
                .Select(matches => new Map(
                    Destination: long.Parse(matches[0].Value),
                    Source: long.Parse(matches[1].Value),
                    Range: long.Parse(matches[2].Value)))
                .ToHashSet();

        return new(
            Seeds: ParseSeeds(),
            SeedToSoil: ParseMap("seed-to-soil map"),
            SoilToFertilizer: ParseMap("soil-to-fertilizer map"),
            FertilizerToWater: ParseMap("fertilizer-to-water map"),
            WaterToLight: ParseMap("water-to-light map"),
            LightToTemperature: ParseMap("light-to-temperature map"),
            TemperatureToHumidity: ParseMap("temperature-to-humidity map"),
            HumidityToLocation: ParseMap("humidity-to-location map")
       );
    }
}
