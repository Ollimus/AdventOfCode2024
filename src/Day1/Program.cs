using Shared;

/*
 * Task description within README.md
*/

var input = new FileReader().Read()
.Aggregate(
    (First: new List<int>(), Second: new List<int>()),
    (collections, nextValue) =>
    {
        var split = nextValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        collections.First.Add(int.Parse(split[0]));
        collections.Second.Add(int.Parse(split[1]));
        return collections;
    });

var processor = new InputProcessor(input.First, input.Second);
processor.Part1();
processor.Part2();

Console.ReadKey();

public class InputProcessor
{
    private ICollection<int> FirstCollection { get; set; }
    private ICollection<int> SecondCollection { get; set; }

    public InputProcessor(ICollection<int> firstList, ICollection<int> secondList)
    {
        SecondCollection = secondList;
        FirstCollection = firstList;
    }

    public void Part1()
    {
        // Order them from smallest to largest since we always compare smallest value from left collection to the right's.
        FirstCollection = FirstCollection.OrderBy(x => x).ToList();
        SecondCollection = SecondCollection.OrderBy(x => x).ToList();

        // 'Zip' through the collection and get absolute value and add it all together.
        // Absolute value is a must since comparison can result in both negative and positive numbers.
        var result = FirstCollection.Zip(SecondCollection, (x, y) => Math.Abs(x - y))
            .Sum();

        Console.WriteLine($"Result is: {result}");
    }

    public void Part2()
    {
        /*
         * Gets how many times element in 1st collection appears in 2nd collection and multiplies it by the first's element.
         * Then sums all together. 
        */
        var result = FirstCollection
            .Select(x => SecondCollection.Count(y => y == x) * x)
            .Sum();

        Console.WriteLine($"Result is: {result}");
    }
}
