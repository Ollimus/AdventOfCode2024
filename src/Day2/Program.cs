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
            .Select(int.Parse))
            .ToList()
        .ToList();

        var result = input.Select(x =>
        {
            // if first is lower than second, it is ascending from the start. 
            var validator = new ValidationClass(2, x.First() < x.Skip(1).First());

            x.Aggregate((firstValue: x.First(), collection: x, validation: validator), (acc, nextValue) =>
            {


                return (nextValue, acc.collection, acc.validation);
            });

            return x;
        }).ToList();


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
