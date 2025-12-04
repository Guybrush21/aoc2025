using Microsoft.Extensions.Logging;

public class Solver2 : SolverBase
{
    public Solver2(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
    }

    public override string Part1()
    {
        long pairSum = 0;

        string[] ranges = Data[0].Split(',');
        List<Range> rangeList = new List<Range>();

        foreach (var r in ranges)
        {
            var parts = r.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            rangeList.Add(new Range(start, end));
        }


        foreach (var range in rangeList)
        {
            for (long i = range.Start; i <= range.End; i++)
            {
                logger.LogDebug("Checking number: {0}", i);
                var n = i.ToString();
                var mid = n.Length / 2;
                if (n.Substring(0, mid) == n.Substring(mid))
                {
                    logger.LogDebug("Found matching pair: {0}", n);
                    pairSum += i;
                }
            }
        }


        return pairSum.ToString();
    }

    public override string Part2()
    {
        long pairSum = 0;

        string[] ranges = Data[0].Split(',');
        List<Range> rangeList = new List<Range>();

        foreach (var r in ranges)
        {
            var parts = r.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            rangeList.Add(new Range(start, end));
        }

        foreach (var range in rangeList)
        {
            for (long i = range.Start; i <= range.End; i++)
            {

                logger.LogDebug("Checking number: {0}", i);
                var n = i.ToString();

                for (var divider = n.Length / 2; divider >= 1; divider--)
                {
                    if (n.Length % divider != 0)
                        // Not evenly divisible
                        continue;

                    var chunks = n.Chunk(divider).Select(x => new string(x));

                    // Check all chunks are the same length
                    if (!chunks.All(x => x.Length == chunks.First().Length))
                        continue;

                    var lastChunk = string.Empty;
                    foreach (var c in chunks)
                    {
                        if (lastChunk == string.Empty)
                            lastChunk = c;

                        if (c != lastChunk)
                        {
                            lastChunk = string.Empty;
                            break;
                        }

                    }

                    if (lastChunk != string.Empty)
                    {
                        logger.LogDebug("Found matching pair: {0}", n);
                        pairSum += i;
                        break;
                    }
                }
            }

        }

        return pairSum.ToString();
    }

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

}
