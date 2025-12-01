
using Microsoft.Extensions.Logging;

public abstract class SolverBase
{
    public int Day { get; set; }
    protected string[] Data;
    protected ILogger logger;

    public SolverBase(int day, string[] data, ILogger logger)
    {
        this.logger = logger;
        this.Day = day;
        this.Data = data;
    }
    public abstract string Part1();
    public abstract string Part2();
}
