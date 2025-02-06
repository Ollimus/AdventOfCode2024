/*
 * Task description within README.md
*/

using Shared;

new Day3().Part1();


Console.ReadKey();



public class Day3
{
    public void Part1()
    {
       var extractedStrings = ExtractAllBetween(new FileReader().ReadAllText(), "mul(", ")");

       var result = extractedStrings
            .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => 
                {
                    // If can't be parsed (data in incorrect format), return 0 so the next part will be x * 0 in these edge cases.
                    var isParsed = int.TryParse(x, out var result);

                    return (isParsed) ? result : 0;
                })
                .ToList())
            .Select(innerList => innerList.Aggregate(1, (acc, num) => acc * num)) //Starting value of one, multiply the first value with second.
            .ToList()
            .Sum(); // Sum it all up.

        Console.WriteLine("Result is: " + result);
    }

    public void Part2()
    {

    }

    // Online solution of getting values between markers.
    static List<string> ExtractAllBetween(string input, string start, string end)
    {
        List<string> matches = [];
        int startIndex = 0;

        while (startIndex < input.Length)
        {
            // Find the next occurrence of the start marker
            startIndex = input.IndexOf(start, startIndex);
            if (startIndex == -1) break; // Stop if no more occurrences of "start" are found

            // Find the next occurrence of the end marker *after* the start marker
            int endIndex = input.IndexOf(end, startIndex + start.Length);
            if (endIndex == -1) break; // Stop if no matching "end" is found

            // Extract the substring between "start" and "end"
            string match = input.Substring(startIndex + start.Length, endIndex - (startIndex + start.Length));
            matches.Add(match);

            // Move past this match to search for the next one
            startIndex = endIndex + end.Length;
        }

        return matches;
    }
}

