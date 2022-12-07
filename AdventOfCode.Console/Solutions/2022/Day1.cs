namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day1 : ISolution<int>
{
    private readonly string[] _input;
    
    public Day1(string[] input)
    {
        _input = input;
    }
    
    #region Implementation of ISolution<int,int>
    /// <inheritdoc />
    public int Part1()
    {
        var storage = new List<int>();
        var maxStorage = 0;

        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                var total = storage.Sum();
                if (total > maxStorage)
                {
                    maxStorage = total;
                }
        
                storage = new List<int>();
                continue;
            }

            var cal = Convert.ToInt32(line);
            storage.Add(cal);
        }

        return maxStorage;
    }

    /// <inheritdoc />
    public int Part2()
    {
        var calories = new List<List<int>>();
        var storage = new List<int>();

        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                var total = storage.Sum();
        
                calories.Add(storage);
                storage = new List<int>();
                continue;
            }

            var cal = Convert.ToInt32(line);
            storage.Add(cal);
        }
        
        var topThreeSum = calories
            .OrderByDescending(x => x.Sum())
            .Take(3)
            .Select(x => x.Sum())
            .ToList()
            .Sum();
        
        return topThreeSum;
    }
    #endregion
}