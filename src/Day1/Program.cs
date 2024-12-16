using Shared;
using System.IO;

var file = new FileReader().Read();

//Part1();
Part2();

Console.ReadKey();


void Part2()
{
    var input = file.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

    List<int> firstColumn = new();
    List<int> secondColumn = new();
    int similarityScore = 0;

    foreach (var line in input)
    {
        Console.WriteLine($"{line[0]} {line[1]}");

        firstColumn.Add(int.Parse(line[0]));
        secondColumn.Add(int.Parse(line[1]));
    }

    foreach (var number in firstColumn)
    {
        var count = secondColumn.Count(x => x == number);
        similarityScore += count * number;
    }

    Console.WriteLine("Similarity Score: " + similarityScore);
}


void Part1()
{
    var input = file.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

    List<int> firstColumn = new();
    List<int> secondColumn = new();
    int distance = 0;

    foreach (var line in input)
    {
        Console.WriteLine($"{line[0]} {line[1]}");

        firstColumn.Add(int.Parse(line[0]));
        secondColumn.Add(int.Parse(line[1]));
    }

    var sortedFirst = firstColumn.OrderBy(x => x).ToList();
    var sortedSecond = secondColumn.OrderBy(x => x).ToList();

    for (int i = 0; i < sortedFirst.Count; i++)
    {
        var x = sortedFirst[i];
        var y = sortedSecond[i];

        distance += Math.Abs(x - y);
    }

    Console.WriteLine("Total distance: " + distance);
}