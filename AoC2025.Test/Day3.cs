public class Day3
{
    public Day3()
    {

    }

    [Fact]
    public void D3P1()
    {

        var data = @"987654321111111
811111111111119
234234234234278
818181911112111";

        var solver = new Solver3(3, data.Split(Environment.NewLine), TestLogger.Instance);
        Assert.Equal("357", solver.Part1());

    }



}

