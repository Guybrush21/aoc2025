using Microsoft.Extensions.Logging;

public class Solver
{
    private List<SolverBase> solvers = new List<SolverBase>();
    private ILogger logger;
    public Solver(ILogger logger)
    {
        this.logger = logger;
        this.solvers.Add(new Solver1(1, File.ReadAllLines($"./input/{1}"), logger));
    }

    public void Solve(int day = 2)
    {
        var solver = this.solvers.First(x => x.Day == day);

        logger.LogInformation($"Solution for day {day}");
        logger.LogInformation($"Part 1: {solver.Part1()}");
        logger.LogInformation($"Part 2: {solver.Part2()}");
    }

}

