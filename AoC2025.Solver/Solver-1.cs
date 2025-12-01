using Microsoft.Extensions.Logging;

public class Solver1 : SolverBase
{

    public Solver1(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
    }

    public override string Part2()
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in this.Data)
        {
            var split = line.Split("   ");
            left.Add(Convert.ToInt32(split[0]));
            right.Add(Convert.ToInt32(split[1]));
        }

        left.Sort();
        right.Sort();

        var score = 0;
        foreach (var l in left)
        {
            score += l * right.FindAll(r => r == l).Count;
        }
        return score.ToString();
    }

    public override string Part1()
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in this.Data)
        {
            var split = line.Split("   ");
            left.Add(Convert.ToInt32(split[0].Trim()));
            right.Add(Convert.ToInt32(split[1].Trim()));
        }

        left.Sort();
        right.Sort();

        var distanceSum = 0;
        for (var i = 0; i < left.Count; i++)
        {
            this.logger.LogDebug($"distanceSum is {distanceSum}");
            distanceSum += int.Abs(left[i] - right[i]);
        }
        return distanceSum.ToString();
    }
}
