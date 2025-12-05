using Microsoft.Extensions.Logging;

public class Solver5 : SolverBase
{

    readonly List<Range> rangeList;
    readonly List<long> ingredients;

    private struct Range
    {
        public long Start;
        public long End;

        public Range(long start, long end)
        {
            Start = start;
            End = end;
        }
    }

    public Solver5(int day, string[] input, ILogger logger) : base(day, input, logger)
    {

        this.rangeList = new List<Range>();
        this.ingredients = new List<long>();

        string[] ranges = Data.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        ingredients.AddRange(Data.Skip(ranges.Length + 1).Select(line => long.Parse(line)).ToList());

        foreach (var r in ranges)
        {
            var parts = r.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            this.rangeList.Add(new Range(start, end));
        }


    }

    public override string Part1()
    {
        var freshIngredients = 0;

        foreach (var ingredient in this.ingredients)
        {
            var isfresh = false;
            foreach (var range in this.rangeList)
            {
                if (ingredient >= range.Start || ingredient <= range.End)
                {
                    logger.LogDebug($"Ingredient {ingredient} is fresh for range {range.Start}-{range.End}");
                    isfresh = true;
                }
                if (isfresh)
                    break;
            }
            if (isfresh)
                freshIngredients++;
        }

        return freshIngredients.ToString();
    }

    public override string Part2()
    {
        throw new NotImplementedException();
    }
}
