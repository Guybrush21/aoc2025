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
        var input = @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";

        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("3", solver.Part1());
    }
}
