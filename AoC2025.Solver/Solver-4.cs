using Microsoft.Extensions.Logging;

public class Solver4 : SolverBase
{

    readonly int columns = 0;
    readonly int rows = 0;

    const char ROLL = '@';

    public Solver4(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
        rows = input.Length;
        columns = input[0].Length;
    }

    public override string Part1()
    {
        var movableRoll = 0;

        for (var r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (Data[r][c] == ROLL)
                    if (RollsAround(r, c) < 4)
                    {
                        movableRoll++;
                    }
            }
        }

        return movableRoll.ToString();
    }

    private int RollsAround(int row, int column)
    {

        logger.LogDebug($"Checking rolls around {row},{column}");

        int rolls = 0;

        var up = row - 1 >= 0 && Data[row - 1][column] == ROLL;
        var down = row + 1 < rows && Data[row + 1][column] == ROLL;
        var left = column - 1 >= 0 && Data[row][column - 1] == ROLL;
        var right = column + 1 < columns && Data[row][column + 1] == ROLL;

        var upLeft = row - 1 >= 0 && column - 1 >= 0 && Data[row - 1][column - 1] == ROLL;
        var upRight = row - 1 >= 0 && column + 1 < columns && Data[row - 1][column + 1] == ROLL;

        var downLeft = row + 1 < rows && column - 1 >= 0 && Data[row + 1][column - 1] == ROLL;
        var downRight = row + 1 < rows && column + 1 < columns && Data[row + 1][column + 1] == ROLL;

        if (up) rolls++;
        if (down) rolls++;
        if (left) rolls++;
        if (right) rolls++;
        if (upLeft) rolls++;
        if (upRight) rolls++;
        if (downLeft) rolls++;
        if (downRight) rolls++;

        return rolls;
    }

    public override string Part2()
    {

        var movableRoll = 0;
        var lastMovableRoll = 0;

        char[,] grid = new char[rows, columns];
        char[,] nextGrid = new char[rows, columns];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                grid[r, c] = Data[r][c];
                nextGrid[r, c] = Data[r][c];
            }
        }

        do
        {
            lastMovableRoll = movableRoll;
            for (var r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (grid[r, c] == ROLL)
                        if (RollsAround(r, c, grid) < 4)
                        {
                            movableRoll++;
                            nextGrid[r, c] = '.';
                        }
                }
            }

            grid = nextGrid.Clone() as char[,];

        } while (movableRoll != lastMovableRoll);

        return movableRoll.ToString();
    }

    private int RollsAround(int row, int column, char[,] grid)
    {
        logger.LogDebug($"Checking rolls around {row},{column}");

        int rolls = 0;

        var up = row - 1 >= 0 && grid[row - 1, column] == ROLL;
        var down = row + 1 < rows && grid[row + 1, column] == ROLL;
        var left = column - 1 >= 0 && grid[row, column - 1] == ROLL;
        var right = column + 1 < columns && grid[row, column + 1] == ROLL;

        var upLeft = row - 1 >= 0 && column - 1 >= 0 && grid[row - 1, column - 1] == ROLL;
        var upRight = row - 1 >= 0 && column + 1 < columns && grid[row - 1, column + 1] == ROLL;

        var downLeft = row + 1 < rows && column - 1 >= 0 && grid[row + 1, column - 1] == ROLL;
        var downRight = row + 1 < rows && column + 1 < columns && grid[row + 1, column + 1] == ROLL;

        if (up) rolls++;
        if (down) rolls++;
        if (left) rolls++;
        if (right) rolls++;
        if (upLeft) rolls++;
        if (upRight) rolls++;
        if (downLeft) rolls++;
        if (downRight) rolls++;

        return rolls;
    }
}
