using Microsoft.Extensions.Logging;

public class Solver1 : SolverBase
{

    Dial dial;

    public Solver1(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
        dial = new Dial(this.logger);

        foreach (var line in this.Data)
        {
            var rawDirection = line[0];
            var direction = rawDirection == 'L' ? Dial.Direction.Left : Dial.Direction.Right;
            var clicks = int.Parse(line.Substring(1));
            dial.Move(clicks, direction);

        }

    }

    public override string Part1()
    {

        return dial.ZeroEndPositionCount.ToString();

    }

    public override string Part2()
    {
        var result = dial.ZeroClick;
        return result.ToString();
    }

    class Dial
    {
        private readonly ILogger logger;

        public Dial(ILogger logger, int initialPosition = 50, int lenght = 100)
        {
            this.logger = logger;
            Position = initialPosition;
            Lenght = lenght;
            this.logger.LogDebug("Dial initialized at position {position} with lenght {lenght}", Position, Lenght);
        }

        int Lenght { get; set; }
        public int Position { get; set; }
        public int ZeroClick { get; set; } = 0;
        public int ZeroEndPositionCount { get; set; } = 0;

        public enum Direction
        {
            Left, Right
        }

        public void Move(int clicks, Direction direction)
        {

            logger.LogDebug($"New Move {direction}{clicks}");
            while (clicks >= Lenght)
            {
                clicks = clicks - Lenght;
                ZeroClick++;
                logger.LogTrace("  Full revolution: clicks={clicks}, ZeroClick={zeroClick}", clicks, ZeroClick);
            }

            if (clicks <= 0)
            {
                logger.LogTrace("  No remaining clicks, staying at position {position}", Position);
                return;
            }

            if (direction == Direction.Right)
            {
                if (this.Position + clicks >= Lenght)
                    ZeroClick++;

                this.Position += clicks;
                if (Position >= Lenght)
                {
                    Position -= Lenght;
                }
            }
            if (direction == Direction.Left)
            {
                if (this.Position != 0 && this.Position - clicks <= 0)
                    ZeroClick++;

                this.Position -= clicks;

                if (Position <= 0)
                {
                    Position = Lenght - Math.Abs(Position);
                }
                if (Position == Lenght)
                {
                    Position = 0;
                }
            }

            if (Position == 0)
            {
                ZeroEndPositionCount++;
            }

            logger.LogDebug("Result: pos={position}, ZeroClick={zeroClick}, EndZero={endZero}", Position, ZeroClick, ZeroEndPositionCount);
        }
    }
}
