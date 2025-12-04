using Microsoft.Extensions.Logging;

public class Solver3 : SolverBase
{
    public Solver3(int day, string[] input, ILogger logger) : base(day, input, logger)
    {

    }

    public override string Part1()
    {
        var sum = 0;

        foreach (var line in Data)
        {
            var arr = line.ToArray().Select(x => Convert.ToByte(x.ToString())).ToArray();

            // line.Select(x => Convert.ToByte(x)).ToArray();

            var first = findMaxIndex(arr[0..^1]);
            var firstValue = arr[first];

            logger.LogDebug($"First = {firstValue}");

            first += 1;
            var slice = arr[first..^0];
            var second = findMaxIndex(slice);
            var secondValue = slice[second];

            logger.LogDebug($"Second= {secondValue}");

            sum += firstValue * 10 + secondValue;
            logger.LogDebug($"Sum = {sum}");
        }

        return sum.ToString();
    }

    private int findMaxIndex(byte[] line)
    {
        var firstMax = line[0];
        var firstIndex = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] > firstMax)
            {
                firstMax = line[i];
                firstIndex = i;
            }
        }

        return firstIndex;
    }

    public override string Part2()
    {
        return "";
    }


}
