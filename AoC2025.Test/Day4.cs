public class Day4
{

    public Day4()
    {
    }

    [Fact]
    public void Part1()
    {
        var input = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";
        var solver = new Solver4(4, input.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("13", solver.Part1());
    }


    [Fact]
    public void Part2()
    {
        var input = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";
        var solver = new Solver4(4, input.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("13", solver.Part1());
    }
}
