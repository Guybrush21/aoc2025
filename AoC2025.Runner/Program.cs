
public class MovingTotal
{

    List<int> totals = new List<int>();

    public void Append(int[] list)
    {
        int currentTotal = 0;
        int i = 0;
        foreach (var item in list)
        {
            currentTotal += item;
            i++;
            if (i > 2)
            {
                totals.Add(currentTotal);
                i = 0;
            }

        }

    }

    public bool Contains(int total)
    {
        return totals.Contains(total);
    }

    public static void Main(string[] args)
    {
        MovingTotal movingTotal = new MovingTotal();

        movingTotal.Append(new int[] { 1, 2, 3, 4 });

        Console.WriteLine(movingTotal.Contains(6));
        Console.WriteLine(movingTotal.Contains(9));
        Console.WriteLine(movingTotal.Contains(12));
        Console.WriteLine(movingTotal.Contains(7));

        movingTotal.Append(new int[] { 5 });

        Console.WriteLine(movingTotal.Contains(6));
        Console.WriteLine(movingTotal.Contains(9));
        Console.WriteLine(movingTotal.Contains(12));
        Console.WriteLine(movingTotal.Contains(7));
    }
}

