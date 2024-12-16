using Shared;
using System.Linq.Expressions;

var file = new FileReader().Read();

//Part1();
Part2();

void Part2()
{
    var input = file.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
    int safeReports = 0;

    foreach (var report in input)
    {
        bool hasError = false;
        bool passed = true;
        bool isAscending = false;

        for (int i = 0; i < report.Count() - 1; i++)
        {
            var difference = 0;
            var currentLevel = int.Parse(report[i]);
            var nextLevel = int.Parse(report[i + 1]);

            if (i == 0)
            {
                isAscending = (currentLevel < nextLevel) ? true : false;
            }

            else if (isAscending)
            {
                if (currentLevel > nextLevel)
                {
                    passed = false;

                    if (!hasError)
                    {
                        hasError = true;
                        report.RemoveAt(i + 1);
                        i = 0;
                    }

                    break;
                }
            }

            else
            {
                if (currentLevel < nextLevel)
                {
                    passed = false;

                    if (!hasError)
                    {
                        hasError = true;
                        report.RemoveAt(i + 1);
                        i = 0;
                    }

                    break;
                }
            }

            difference = Math.Abs(currentLevel - nextLevel);

            if (!(difference >= 1 && difference <= 3))
            {
                passed = false;

                if (!hasError)
                {
                    hasError = true;
                    report.RemoveAt(i + 1);
                    i = 0;
                }

                break;
            }
        }

        if (passed)
            ++safeReports;
    }

    Console.WriteLine("Safe reports count: " + safeReports);
}

void Part1()
{
    var input = file.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();
	int safeReports = 0;

    foreach (var report in input)
    {
        bool passed = true;
        bool isAscending = false;

        for (int i = 0; i < report.Count() - 1; i++)
        {
            var difference = 0;
            var currentLevel = int.Parse(report[i]);
            var nextLevel = int.Parse(report[i + 1]);

            if (i == 0)
            {
                isAscending = (currentLevel < nextLevel) ? true : false;
            }

            else if (isAscending)
            {
                if (currentLevel > nextLevel)
                {
                    passed = false;
                    break;
                }
            }

            else
            {
                if (currentLevel < nextLevel)
                {
                    passed = false;
                    break;
                }
            }


            difference = Math.Abs(currentLevel - nextLevel);

            if (!(difference >= 1 && difference <= 3))
            {
                passed = false;
                break;
            }
        }

        if (passed)
            ++safeReports;
    }

    Console.WriteLine("Safe reports count: " + safeReports);
}