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
}
