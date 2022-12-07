namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day4 : ISolution<int>
{
    private readonly string[] _input;

    public Day4(string[] input)
    {
        _input = input;
    }
    
    #region Implementation of ISolution<out int,out int>
    /// <inheritdoc />
    public int Part1()
    {
        var total = 0;
        
        foreach (var line in _input)
        {
            var ranges = line.Split(',');
            var leftRange = ranges[0].Split('-');
            var rightRange = ranges[1].Split('-');
            var leftStart = int.Parse(leftRange[0]);
            var leftEnd = int.Parse(leftRange[1]);
            var rightStart = int.Parse(rightRange[0]);
            var rightEnd = int.Parse(rightRange[1]);
            
            var leftRangeContainsRightRange = leftStart <= rightStart && leftEnd >= rightEnd;
            var rightRangeContainsLeftRange = rightStart <= leftStart && rightEnd >= leftEnd;
            
            if (leftRangeContainsRightRange || rightRangeContainsLeftRange)
            {
                total++;
            }
        }
        
        return total;
    }

    /// <inheritdoc />
    public int Part2()
    {
        var total = 0;
        
        foreach (var line in _input)
        {
            var ranges = line.Split(',');
            var leftRange = ranges[0].Split('-');
            var rightRange = ranges[1].Split('-');
            var leftStart = int.Parse(leftRange[0]);
            var leftEnd = int.Parse(leftRange[1]);
            var rightStart = int.Parse(rightRange[0]);
            var rightEnd = int.Parse(rightRange[1]);
            
            if (leftEnd >= rightStart && rightEnd >= leftStart)
            {
                total++;
            }
        }
        
        return total;
    }
    #endregion
}