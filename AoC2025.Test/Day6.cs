public class Day6
{

    string input = @"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   + ";

    public Day6()
    {
    }

    [Fact]
    public void Part1()
    {
        var solver = new Solver6(6, input.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("4277556", solver.Part1());
    }


}
