using Microsoft.Extensions.Logging;

public class Solver3 : SolverBase
{
    public Solver3(int day, string[] input, ILogger logger) : base(day, input, logger)
    {

    }

    public override string Part1()
    {
        var sum = 0;

        foreach (var line in Data)
        {
            var arr = line.ToArray().Select(x => Convert.ToByte(x.ToString())).ToArray();

            var first = findMaxIndex(arr[0..^1]);
            var firstValue = arr[first];

            logger.LogDebug($"First = {firstValue}");

            first += 1;
            var slice = arr[first..^0];
            var second = findMaxIndex(slice);
            var secondValue = slice[second];

            logger.LogDebug($"Second= {secondValue}");

            sum += firstValue * 10 + secondValue;
            logger.LogDebug($"Sum = {sum}");
        }

        return sum.ToString();
    }

    private int findMaxIndex(byte[] line)
    {
        var firstMax = line[0];
        var firstIndex = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] > firstMax)
            {
                firstMax = line[i];
                firstIndex = i;
            }
        }

        return firstIndex;
    }


    public override string Part2()
    {

        var sum = 0;

        foreach (var line in Data)
        {

            var arr = line.ToArray().Select(x => Convert.ToByte(x.ToString())).ToArray();

            var joltages = new byte[12];

            var first = findMaxIndex(arr[0..^1]);
            var firstValue = arr[first];

            logger.LogDebug($"First = {firstValue}");

            first += 1;
            var slice = arr[first..^0];
            var second = findMaxIndex(slice);
            var secondValue = slice[second];

            logger.LogDebug($"Second= {secondValue}");

            sum += firstValue * 10 + secondValue;
            logger.LogDebug($"Sum = {sum}");
        }

        return sum.ToString();
    }


    // public override string Part2()
    // {
    //     var sum = 0L;
    //
    //     foreach (var line in Data)
    //     {
    //         var arr = line.ToArray().Select(x => Convert.ToByte(x.ToString())).ToArray();
    //
    //         for (int i = 0; i < 3; i++)
    //         {
    //             var idxToRemove = findMinIndex(arr);
    //
    //             if (idxToRemove == 0)
    //                 arr = arr[1..^0];
    //             else if (idxToRemove == arr.Length - 1)
    //                 arr = arr[0..^1];
    //             else
    //                 arr = arr[0..idxToRemove].Concat(arr[(idxToRemove + 1)..^0]).ToArray();
    //         }
    //
    //         logger.LogDebug($"Remaining digits: {string.Join("", arr)}");
    //         var numb = 0L;
    //         for (int i = 0; i < arr.Length; i++)
    //         {
    //             var n = (long)Math.Pow(10, arr.Length - i - 1);
    //             numb += (long)arr[i] * n;
    //         }
    //         logger.LogDebug($"Number formed: {numb}");
    //
    //         sum += numb;
    //
    //     }
    //
    //     return sum.ToString();
    // }


    // private int findMinIndex(byte[] line)
    // {
    //     var index = 0;
    //     for (int i = 0; i < line.Length; i++)
    //     {
    //         if (line[i] < line[index]
    //             && i + 1 < line.Length && line[i] < line[i + 1]
    //             )
    //         {
    //             index = i;
    //         }
    //     }
    //     return index;
    // }
}
