using Shared;

/*
 * Task description within README.md
*/

new Day2().Part1();


Console.ReadKey();

public class Day2
{
    public void Part1()
    {
        var input = new FileReader().Read()
        .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList())
        .ToList();

        var result = input.Select(rows =>
        {
            var isAscending = rows.Zip(rows.Skip(1), (x, y) => x <= y).All(x => x);
            var isDescending = rows.Zip(rows.Skip(1), (x, y) => x >= y).All(x => x);

            if (!isAscending && !isDescending)
                return 0;


            var isWithinParameters = rows.Zip(rows.Skip(1), (x, y) =>
            {
                var difference = Math.Abs(x - y);
                return (difference >= 1 && difference <= 3);
            }).All(x => x);

            return isWithinParameters ? 1 : 0;
        })
            .Sum();

        Console.WriteLine("Result is: " + result);
    }

    public void Part2()
    {
    }
}

public class ValidationClass
{
    public int ThresholdParameter { get; set; } = 0;
    public bool IsAscending { get; set; } = true;
    public bool IsValid { get; set; } = true;

    public ValidationClass(int thresholdParameter, bool isAscending)
    {
        ThresholdParameter = thresholdParameter;
        IsAscending = isAscending;
    }

    public bool AreValuesAscending(int x, int y)
    {
        if (IsAscending)
        {
            if (x > y)
            {
                IsValid = false;
                IsAscending = false;
                return false;
            }

            return true;
        }

        else
        {
            if (x < y)
            {
                IsValid = false;
                IsAscending = true;
                return true;
            }

            return false;
        }
    }
}
