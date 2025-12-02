using Microsoft.Extensions.Logging;

public class Day2
{

    public Day2()
    {

    }

    [Fact]
    public void D2P1()
    {

        var data = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124";

        Solver2 solver = new Solver2(2, [data], TestLogger.Instance);
        Assert.Equal("1227775554", solver.Part1());

    }


    [Fact]
    public void D2P2()
    {

        var data = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124";

        Solver2 solver = new Solver2(2, [data], TestLogger.Instance);
        Assert.Equal("4174379265", solver.Part2());

    }



}

