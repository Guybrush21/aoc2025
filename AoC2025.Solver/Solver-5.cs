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
                if (ingredient >= range.Start && ingredient <= range.End)
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
        var ranges = new List<Range>(this.rangeList);
        ranges.Sort((a, b) =>
        {
            if (a.Start - b.Start != 0) return a.Start.CompareTo(b.Start);
            else return a.End.CompareTo(b.End);
        });

        for (int i = 0; i < ranges.Count - 1; i++)
        {
            if (ranges[i + 1].Start <= ranges[i].End)
            {
                var newEnd = ranges[i + 1].End;
                var newStart = ranges[i].End + 1;

                ranges[i + 1] = new Range
                {
                    Start = newStart,
                    End = newEnd
                };
            }
        }

        var sum = 0L;
        var lastBigEnd = 0L;
        foreach (var r in ranges)
        {
            logger.LogDebug($"Range {r.Start}-{r.End}");
            if (r.End < lastBigEnd)
            {
                logger.LogDebug($"Skipping range {r.Start}-{r.End}");
                continue;
            }
            var minStart = Math.Max(r.Start, lastBigEnd + 1);
            sum += r.End - Math.Abs(minStart) + 1;

            lastBigEnd = r.End;
            logger.LogDebug($"Sum is: {sum}. New lastBigEnd is {lastBigEnd}");
        }

        return sum.ToString();

    }
}

