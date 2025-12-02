using Microsoft.Extensions.Logging;

public class Day2
{

    private ILogger logger;
    public Day2()
    {
        ILoggerFactory factory = LoggerFactory.Create(builder =>
            builder.AddConsole(options =>
            {
                options.FormatterName = "simple";
            })
            .AddSimpleConsole(options =>
            {
                options.ColorBehavior = Microsoft.Extensions.Logging.Console.LoggerColorBehavior.Enabled;
                options.SingleLine = true;
                options.TimestampFormat = "";
                options.IncludeScopes = false;
            })
            .SetMinimumLevel(LogLevel.Debug)
        );
        this.logger = factory.CreateLogger("AOC");
    }
    [Fact]
    public void D2P1()
    {

        var data = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124";

        Solver2 solver = new Solver2(2, [data], logger);
        Assert.Equal("1227775554", solver.Part1());

    }
}

