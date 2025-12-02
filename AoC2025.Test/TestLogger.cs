using Microsoft.Extensions.Logging;

public static class TestLogger
{
    private static readonly Lazy<ILogger> _logger = new(() => CreateLogger());

    public static ILogger Instance => _logger.Value;

    private static ILogger CreateLogger()
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
            .SetMinimumLevel(LogLevel.Information)
        );
        return factory.CreateLogger("AOC");
    }
}
