using Microsoft.Extensions.Logging;

namespace AoC2025.Test;

public class Day1
{
    private ILogger logger;
    public Day1()
    {
        ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug));
        this.logger = factory.CreateLogger("Test AOC2025");
    }
    [Fact]
    public void Part1()
    {
        var input = @"3   4
  4   3
  2   5
  1   3
  3   9
  3   3";

        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("11", solver.Part1());
    }
}
