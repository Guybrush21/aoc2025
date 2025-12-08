using System.CommandLine;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

internal class Program
{
    private static int Main(string[] args)
    {
        var dayOption = new Option<int?>(
            name: "--day",
            description: "Day to run");
        dayOption.AddAlias("-d");

        var partOption = new Option<int?>(
            name: "--part",
            description: "Part to run (1 or 2). Omit to run both.");
        partOption.AddAlias("-p");

        var cmd = new RootCommand("Advent of Code 2025 runner");
        cmd.AddOption(dayOption);
        cmd.AddOption(partOption);

        cmd.SetHandler((int? day, int? part) =>
        {
            ILoggerFactory factory = LoggerFactory.Create(builder =>
            {
                builder
                    .SetMinimumLevel(LogLevel.Debug)
                    .AddSimpleConsole(options =>
                    {
                        options.SingleLine = true;
                        options.TimestampFormat = "HH:mm:ss ";
                        options.ColorBehavior = LoggerColorBehavior.Enabled;
                        options.IncludeScopes = false;
                    });
            });

            var runnerLogger = factory.CreateLogger("Runner");
            var solverLogger = factory.CreateLogger("Solver");

            runnerLogger.LogInformation("AOC 2025");

            var solver = new Solver(solverLogger);
            solver.Solve(day, part);
        }, dayOption, partOption);

        return cmd.Invoke(args);
    }
}
