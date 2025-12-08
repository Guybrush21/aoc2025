public class Day5
{

    string input = @"3-5
10-14
16-20
12-18

1
5
8
11
17
32";

    public Day5()
    {
    }

    [Fact]
    public void Part1()
    {
        var solver = new Solver5(4, input.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("3", solver.Part1());
    }

    [Fact]
    public void Part2()
    {
        var solver = new Solver5(4, input.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("14", solver.Part2());
    }

    [Fact]
    public void Part2Single()
    {
        var data = @"3-3";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("1", solver.Part2());
    }

    [Fact]
    public void Part2MultiSingle()
    {
        var data = @"3-3
4-4";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("2", solver.Part2());
    }

    [Fact]
    public void Part2Overlap()
    {
        var data = @"3-3
3-4";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("2", solver.Part2());
    }

    [Fact]
    public void Part2Include()
    {
        var data = @"3-3
1-5";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("5", solver.Part2());
    }

    [Fact]
    public void Part2MultiInclude()
    {
        var data = @"3-3
2-4
1-5";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("5", solver.Part2());
    }

    [Fact]
    public void Part2Include12()
    {
        var data = @"1-5
1-12";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("12", solver.Part2());
    }

    [Fact]
    public void Part2MultiIncludeStrange()
    {
        var data = @"1-5
1-12
3-7
5-15
7-14";
        var solver = new Solver5(4, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("15", solver.Part2());
    }
}
