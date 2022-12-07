namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day6 : ISolution<int>
{
    private readonly string _input;

    public Day6(string[] input)
    {
        _input = input[0];
    }
    
    #region Implementation of ISolution<out int,out int>
    /// <inheritdoc />
    public int Part1()
    {
        return GetResultForLength(4);
    }

    /// <inheritdoc />
    public int Part2()
    {
        return GetResultForLength(14);
    }

    private int GetResultForLength(int lengthOfString)
    {
        var result = 0;

        for (var i = lengthOfString - 1; i < _input.Length; i++)
        {
            var last4CharactersOfInput = _input[(i - (lengthOfString - 1))..(i + 1)];
            var last4AsSet = last4CharactersOfInput.Distinct();

            if (last4AsSet.Count() != lengthOfString)
            {
                continue;
            }

            result = i + 1;
            break;
        }

        return result;
    }
    #endregion
}