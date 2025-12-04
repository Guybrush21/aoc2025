using Microsoft.Extensions.Logging;

public class Solver
{
    private List<SolverBase> solvers = new List<SolverBase>();
    private ILogger logger;
    public Solver(ILogger logger)
    {
        this.logger = logger;

        RegisterDay(1, day => new Solver1(day, LoadInput(day), logger));
        RegisterDay(2, day => new Solver2(day, LoadInput(day), logger));
        RegisterDay(3, day => new Solver3(day, LoadInput(day), logger));
    }

    private string[] LoadInput(int day)
    {
        var path = $"./input/{day}";
        if (!File.Exists(path))
        {
            logger.LogError("Input file not found for day {day}: {path}", day, path);
            return Array.Empty<string>();
        }
        return File.ReadAllLines(path);
    }

    private void RegisterDay(int day, Func<int, SolverBase> factory)
    {
        try
        {
            var instance = factory(day);
            solvers.Add(instance);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to register day {day}", day);
        }
    }

    public void Solve(int? day, int? part = null)
    {
        if (!day.HasValue)
            day = solvers.Count;

        var solver = this.solvers.FirstOrDefault(x => x.Day == day);
        if (solver == null)
        {
            logger.LogError("No solver registered for day {day}", day);
            return;
        }

        if (part.HasValue && part.Value != 1 && part.Value != 2)
        {
            logger.LogError("Invalid part {part}. Use 1 or 2.", part);
            return;
        }

        logger.LogInformation("Solution for day {day}", day);
        if (part == null || part == 1)
        {
            logger.LogInformation("Part 1: {result}", solver.Part1());
        }
        if (part == null || part == 2)
        {
            logger.LogInformation("Part 2: {result}", solver.Part2());
        }
    }
}
