namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day2 : ISolution<int>
{
    private readonly string[] _input;

    private readonly Dictionary<string, Decision> _decisions = new()
    {
        {"A", Decision.Rock},
        {"B", Decision.Paper},
        {"C", Decision.Scissors},
        {"X", Decision.Rock},
        {"Y", Decision.Paper},
        {"Z", Decision.Scissors},
    };

    public Day2(string[] input)
    {
        _input = input;
    }
    
    #region Implementation of ISolution<out int,out int>
    /// <inheritdoc />
    public int Part1()
    {
        var score = 0;
        
        foreach (var line in _input)
        {
            var parts = line.Split();
            var opp = parts[0];
            var me = parts[1];
            
            var oppDecision = _decisions[opp];
            var myDecision = _decisions[me];
            
            if (oppDecision == myDecision)
            {
                score += 3;
            }
            else
            {
                switch (oppDecision)
                {
                    case Decision.Rock when myDecision == Decision.Paper:
                    case Decision.Paper when myDecision == Decision.Scissors:
                    case Decision.Scissors when myDecision == Decision.Rock:
                        score += 6;
                        break;
                }
            }
            
            score += (int) myDecision;
        }
        
        return score;
    }

    /// <inheritdoc />
    public int Part2()
    {
        var score = 0;
        
        foreach (var line in _input)
        {
            var parts = line.Split();
            var opp = parts[0];
            var myStrategy = parts[1];
            
            var oppDecision = _decisions[opp];
            score += oppDecision switch
            {
                Decision.Rock => myStrategy switch
                {
                    "X" => 0 + (int) Decision.Scissors,
                    "Y" => 3 + (int) Decision.Rock,
                    "Z" => 6 + (int) Decision.Paper
                },
                Decision.Paper => myStrategy switch
                {
                    "X" => 0 + (int) Decision.Rock,
                    "Y" => 3 + (int) Decision.Paper,
                    "Z" => 6 + (int) Decision.Scissors
                },
                Decision.Scissors => myStrategy switch
                {
                    "X" => 0 + (int) Decision.Paper,
                    "Y" => 3 + (int) Decision.Scissors,
                    "Z" => 6 + (int) Decision.Rock
                }
            };
        }
        
        return score;
    }
    #endregion
}

enum Decision
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}