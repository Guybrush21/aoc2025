using Microsoft.Extensions.Logging;

public class Solver1 : SolverBase
{

    public Solver1(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
    }

    public override string Part1()
    {
        var dial = new Dial();

        int zeroPosition = 0;
        foreach (var line in this.Data)
        {
            var rawDirection = line[0];
            var direction = rawDirection == 'L' ? Dial.Direction.Left : Dial.Direction.Right;
            var clicks = int.Parse(line.Substring(1));

            this.logger.LogDebug("Click And Direction: {clicks} - {direction}", clicks, direction);
            this.logger.LogDebug("Position before: {position}", dial.Position);

            dial.Move(clicks, direction);

            this.logger.LogDebug("Position after: {position}", dial.Position);

            if (dial.Position == 0) zeroPosition++;


        }

        return zeroPosition.ToString();

    }

    public override string Part2()
    {
        return "";
    }

    class Dial
    {

        public Dial(int initialPosition = 50, int lenght = 100)
        {
            Position = initialPosition;
            Lenght = lenght;
        }

        int Lenght { get; set; }
        public int Position { get; set; }

        public enum Direction
        {
            Left, Right
        }

        public void Move(int clicks, Direction direction)
        {
            while (clicks > Lenght)
            {
                clicks = clicks - Lenght;
            }

            if (direction == Direction.Right)
            {
                this.Position += clicks;
                if (Position > Lenght)
                    Position = Position - Lenght;

            }
            if (direction == Direction.Left)
            {
                this.Position -= clicks;
                if (Position < 0)
                    Position = Lenght - int.Abs(Position);
            }

            if (Position == Lenght)
            {
                Position = 0;
            }
        }
    }
}
