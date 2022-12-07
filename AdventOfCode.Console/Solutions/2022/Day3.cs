namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day3 : ISolution<int>
{
    private readonly string[] _input;

    public Day3(string[] input)
    {
        _input = input;
    }
    
    // alphabet contains lower and upper case letters
    private const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    #region Implementation of ISolution<out int,out int>
    /// <inheritdoc />
    public int Part1()
    {
        var total = 0;
        
        foreach (var line in _input)
        {
            // get which letter appears in both halves of the string
            var letter = 
                line[..(line.Length / 2)]
                .Intersect(line[(line.Length / 2)..])
                .FirstOrDefault();
            
            var index = alphabet.IndexOf(letter);
            
            total += index + 1;
        }
        
        return total;
    }

    /// <inheritdoc />
    public int Part2()
    {
        var total = 0;
        
        for (var i = 0; i < _input.Length - 2; i += 3)
        {
            var line1 = _input[i];
            var line2 = _input[i + 1];
            var line3 = _input[i + 2];
            
            // get which letter appears in all three lines
            var letter = 
                line1.Intersect(line2)
                .Intersect(line3)
                .FirstOrDefault();
            
            total += alphabet.IndexOf(letter) + 1;
        }
        
        return total;
    }
    #endregion
}