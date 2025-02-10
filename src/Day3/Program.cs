/*
 * Task description within README.md
*/

using Shared;
using System.Text.RegularExpressions;

new Day3().Part1();
new Day3().Part2();

Console.ReadKey();



public class Day3
{
    public void Part1()
    {
        // Find each instances of:
        // mul({value1}, {value2})
        var regex = new Regex(@"mul\((\d+,\d+)\)");
        var extractedStrings = ExtractValues(new FileReader().ReadAllText(), regex);

        var result = extractedStrings
             .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                 .Select(x =>
                 {
                     // If can't be parsed (data in incorrect format), return 0 so the next part will be x * 0 in these edge cases.
                     var isParsed = int.TryParse(x, out var result);

                     return (isParsed) ? result : 0;
                 })
                 .ToList())
             .Select(innerList => innerList.Aggregate((acc, num) => { Console.WriteLine(acc + " " + num); return acc * num; })) //Starting value of one, multiply the first value with second.
             .ToList()
             .Sum(); // Sum it all up.

        Console.WriteLine("Result is: " + result);
    }

    public void Part2()
    {
        // Find each instances of:
        // mul({value1}, {value2})
        // do()
        // don't
        var regex = new Regex(@"mul\((\d+,\d+)\)|do\(\)|don't\(\)");
        var extractedStrings = ExtractValues(new FileReader().ReadAllText(), regex);

        //Console.WriteLine("Result is: " + result);
    }

    // Regex still taken off the internet :)
    static List<string> ExtractValues(string input, Regex regex)
    {
        List<string> values = []; // Just trying to remember how to use the new way of creating lists.
        MatchCollection matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            values.Add(match.Groups[1].Value);
        }

        return values;
    }
}

