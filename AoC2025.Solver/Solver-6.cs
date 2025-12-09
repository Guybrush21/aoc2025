using Microsoft.Extensions.Logging;

public class Solver6 : SolverBase
{
    class Problem
    {
        public List<int> numbers;
        public char operation;
        public Problem()
        {
            this.numbers = [];
            this.operation = '+';
        }

        public void setOperation(char op)
        {
            this.operation = op;
        }
    }

    public Solver6(int day, string[] input, ILogger logger) : base(day, input, logger)
    {
    }

    public override string Part1()
    {
        List<Problem> problems = this.BuildProblems();

        return this.ResolveProblems(problems);

    }

    private List<Problem> BuildProblems()
    {
        List<Problem> problems = InitProblems();

        for (var j = 0; j < this.Data.Length; j++)
        {
            var line = this.Data[j];
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                if (j == this.Data.Length - 1)
                {
                    var operation = parts[i].Trim()[0];
                    logger.LogDebug($"Setting operation for problem {i} to {operation}");
                    problems[i].setOperation(operation);
                }
                else
                {
                    var number = int.Parse(parts[i]);
                    problems[i].numbers.Add(number);
                }
            }
        }

        return problems;
    }

    private List<Problem> InitProblems()
    {
        var totalProblems = this.Data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        var problems = new List<Problem>(totalProblems);
        for (int i = 0; i < totalProblems; i++)
        {
            problems.Add(new Problem());
        }

        return problems;
    }

    private string ResolveProblems(List<Problem> problems)
    {
        var result = 0L;
        foreach (var item in problems)
        {
            var problemResult = 0L;
            if (item.operation == '*')
                problemResult = 1L;

            foreach (var number in item.numbers)
            {
                if (item.operation == '+')
                {
                    logger.LogDebug($"Adding {number} to {problemResult}");
                    problemResult += number;
                }
                else if (item.operation == '*')
                {
                    logger.LogDebug($"Multiplying {number} to {problemResult}");
                    problemResult *= number;
                }
            }
            result += problemResult;
            logger.LogDebug($"Problem result: {problemResult}, Total result: {result}");
        }
        return result.ToString();
    }

    public override string Part2()
    {
        var problems = this.BuildProblems();
        var transformedProblems = this.transformProblems(problems);
        throw new NotImplementedException();
    }

    private object transformProblems(List<Problem> problems)
    {
        var result = new List<Problem>();
        foreach (var problem in problems)
        {
            result.Add((this.transformProblem(problem)));
        }
        return result;
    }

    private Problem transformProblem(Problem problem)
    {
        var maxNumber = problem.numbers.Max();
        throw new NotImplementedException();
    }
}
