using Microsoft.Extensions.Logging;
internal class Program
{
    private static void Main(string[] args)
    {
        ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        Microsoft.Extensions.Logging.ILogger logger = factory.CreateLogger("Program");
        logger.LogInformation("AOC 2025");

        var solver = new Solver(logger);
        solver.Solve();
    }
}
