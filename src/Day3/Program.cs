/*
 * Task description within README.md
*/

using Shared;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Transactions;




//new Day3().Part1();
new Day3().Part2();

Console.ReadKey();



public class Day3
{
    public const string @do = "do()";
    public const string dont = "don't()";

    public void Part1()
    {
        // Find each instances of:
        // mul({value1}, {value2})
        var regexPattern = new Regex(@"mul\((\d+,\d+)\)");
        var extractedStrings = ExtractValues(new FileReader().ReadAllText(), regexPattern);

        var result = extractedStrings
             .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                 .Select(x =>
                 {
                     // If can't be parsed (data in incorrect format), return 0 so the next part will be x * 0 in these edge cases.
                     var isParsed = int.TryParse(x, out var result);

                     return (isParsed) ? result : 0;
                 })
                 .ToList())
             .Select(innerList => innerList.Aggregate((acc, num) => acc * num)) //Starting value of one, multiply the first value with second.
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
        Regex regexPattern = new Regex(@"mul\((\d+,\d+)\)|do\(\)|don't\(\)");

        var result = ExtractValues(new FileReader().ReadAllText(), regexPattern)
            .Aggregate((Sum: 0, ProcessCurrentValue: true), (acc, nextValue) =>
            {
                // Is true, false or null. The latter if value is an integer.
                var processNextValue = IsDoOrDont(nextValue);

                // If processNextValue is null, it means it is an integer and therefore can be processed if the current instruction is to process.
                if (acc.ProcessCurrentValue && processNextValue is null)
                {
                    // Split string into an array, parse it into ints and multiply.
                    var multipliedSum = nextValue.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Aggregate((x, y) => x * y);

                    // Return acc sum with the multiplied sum and assign previous instruction (true in this case).
                    return (acc.Sum + multipliedSum, acc.ProcessCurrentValue);
                }

                // If value was an integer but instruction was to ignore it, we assign current instruction (false in this case)
                processNextValue ??= acc.ProcessCurrentValue;
                
                // Return previous values unchanged.
                return (acc.Sum, processNextValue.Value);
            });

        Console.WriteLine("Result is: " + result.Sum);
    }

    static List<string> ExtractValues(string input, Regex regexPattern)
    {
        List<string> values = []; // Just trying to remember how to use the new way of creating lists.
        MatchCollection matches = regexPattern.Matches(input);

        foreach (Match match in matches)
        {
            // value 0 is for 'don't() and 'do()'. Value 1 in these are empty.
            // Value 1 is for mul values. Value 0 contains the whole mul -value but value1 contains string of ie. "11,12" 
            var value = match.Groups.Values.Any(x => string.IsNullOrEmpty(x.Value))
                ? match.Groups[0].Value : match.Groups[1].Value;

            values.Add(value);
        }

        return values;
    }

    // True
    // False
    // Null
    private static bool? IsDoOrDont(string input)
        => !(input == @do || input == dont) ?null : input == @do;
}



//.Select(x =>
//{


//    return new
//    {
//        Original = x, // Always keep the original value as a string,
//        Command = x == @do ? @do : x == dont ? dont : null,
//        Computed = (x == @do || x == dont) ? (int?)null :
//                   x.Split(',', StringSplitOptions.RemoveEmptyEntries)
//                    .Select(int.Parse)
//                    .Aggregate((a, b) => a * b) // Keep it as an int
//    };
//});

// Input made into format of:
// 
//var extractedValues = ExtractValues(new FileReader().ReadAllText(), regexPattern)
//    .Select(x =>
//    {


//        return new
//        {
//            Original = x, // Always keep the original value as a string,
//            Command = x == @do ? @do : x == dont ? dont : null,
//            Computed = (x == @do || x == dont) ? (int?)null :
//                       x.Split(',', StringSplitOptions.RemoveEmptyEntries)
//                        .Select(int.Parse)
//                        .Aggregate((a, b) => a * b) // Keep it as an int
//        };
//    });

//var result = extractedValues.Aggregate((sum: 0, calculateNextValue: false), (acc, nextvalue) =>
//{
//    if (!acc.calculateNextValue)
//        return (acc.sum, (nextvalue.Command != null ? nextvalue.Command : acc.calculateNextValue));

//    return ((acc.sum + nextvalue.Computed), (nextvalue.Command != null ? nextvalue.Command : acc.calculateNextValue));
//});


//var result = extractedValues.Aggregate((sum: 0, calculateNextValue: false), (acc, nextvalue) =>
//{
//    if (!acc.calculateNextValue)
//        return (acc.sum, nextvalue. == @do ? true : nextvalue == dont ? false : acc.calculateNextValue);

//    var canConvert = int.TryParse(nextvalue, out var intValue);

//    return canConvert ? (acc.sum + intValue, nextvalue == @do ? true : acc.calculateNextValue) : (acc.sum, acc.calculateNextValue);
//});