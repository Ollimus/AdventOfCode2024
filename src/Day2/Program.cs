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

        // Find every succesful report and finally add them together as sum.
        var result = input.Select(rows =>
        {
            // Checks whether values are increasing or decreasing.
            // Unable to do it in one check in a smart way since collections can be unordered.
            var isAscending = rows.Zip(rows.Skip(1), (x, y) => x <= y).All(x => x);
            var isDescending = rows.Zip(rows.Skip(1), (x, y) => x >= y).All(x => x);

            // Since ALL values are not ascending nor descending, we know that values within collection jump back and forth.
            // Ie: 3 5 3 6 as a collection does not descend or ascend.
            if (!isAscending && !isDescending)
                return 0;

            // We check whether the first value on the collection is within parameters (more than 1, less than 3).
            var isWithinParameters = rows.Zip(rows.Skip(1), (x, y) =>
            {
                var difference = Math.Abs(x - y);
                return (difference >= 1 && difference <= 3);
            }).All(x => x);

            return isWithinParameters ? 1 : 0;
        }).Sum();

        Console.WriteLine("Result is: " + result);
    }


    /*
     * Not completed due it annoying me :) 
    */
    public void Part2()
    {

    }
}