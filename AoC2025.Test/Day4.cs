public class Day4
{

    public Day4()
    {
    }

    [Fact]
    public void Part1Test()
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
