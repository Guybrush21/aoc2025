using Microsoft.Extensions.Logging;

namespace AoC2025.Test;

public class Day1
{
    private ILogger logger;
    public Day1()
    {
        this.logger = TestLogger.Instance;
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


    [Fact]
    public void Part2()
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

        Assert.Equal("6", solver.Part2());
    }

    [Fact]
    public void Part2MultipleClicks()
    {
        var input = @"L200";
        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("2", solver.Part2());
    }

    [Fact]
    public void Part2MultipleClicksWithStops()
    {
        var input = @"L100
R50";
        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("2", solver.Part2());
    }

    [Fact]
    public void P2LeftResetOnPositionEqualLenght()
    {
        var input = @"L50
L100";
        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("2", solver.Part2());
    }

    [Fact]
    public void P2LeftSingleEqualLenght()
    {
        var input = @"L50";
        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("1", solver.Part2());
    }

    [Fact]
    public void P2RightResetOnPositionEqualLenght()
    {
        var input = @"R50
R100";
        var solver = new Solver1(1, input.Split(Environment.NewLine), logger);

        Assert.Equal("2", solver.Part2());
    }

}
