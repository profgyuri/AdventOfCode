using System.Text;

namespace AdventOfCode.Console.Solutions._2022;

internal sealed class Day5 : ISolution<string>
{
    private readonly string[] _input;

    public Day5(string[] input)
    {
        _input = input;
    }
    
    #region Implementation of ISolution<out string,out string>
    /// <inheritdoc />
    public string Part1()
    {
        var stacks = GetStacks();
        var instructions = GetInstructions();

        foreach (var instruction in instructions)
        {
            var (amountNeededToReplace, takeFrom, putTo) = 
                (instruction[0], instruction[1], instruction[2]);

            for (var i = 0; i < amountNeededToReplace; i++)
            {
                stacks[putTo].Push(stacks[takeFrom].Pop());
            }
        }
        
        var result = new StringBuilder();
        foreach (var stack in stacks)
        {
            result.Append(stack.Pop());
        }

        return $"{result}";
    }
    
    /// <inheritdoc />
    public string Part2()
    {
        var stacks = GetStacks();
        var instructions = GetInstructions();

        foreach (var instruction in instructions)
        {
            var (amountNeededToReplace, takeFrom, putTo) = 
                (instruction[0], instruction[1], instruction[2]);
            var helper = new Stack<char>();

            for (var i = 0; i < amountNeededToReplace; i++)
            {
                helper.Push(stacks[takeFrom].Pop());
            }
            
            while (helper.Count > 0)
            {
                stacks[putTo].Push(helper.Pop());
            }
        }
        
        return GetTextFromStacks(stacks);
    }
    #endregion
    
    private Stack<char>[] GetStacks()
    {
        var stacks = new Stack<char>[9].Select(_ => new Stack<char>()).ToArray();

        // this iterates over the rows
        for (var i = 7; i >= 0; i--)
        {
            var line = _input[i];
            var items = line.Split(' ');
            var stackIndex = 0;
            
            // this iterates over the stacks
            for (var j = 0; j < items.Length; j++)
            {
                var item = items[j];
                if (!string.IsNullOrEmpty(item))
                {
                    stacks[stackIndex].Push(item[1]);
                }
                else
                {
                    j += 3;
                }
                
                stackIndex++;
            }
        }

        return stacks;
    }
    
    private List<int[]> GetInstructions()
    {
        var instructions = new List<int[]>();

        //this iterates through the instructions
        for (var i = 10; i < _input.Length; i++)
        {
            var line = _input[i];
            
            instructions.Add(new []
            {
                Convert.ToInt32(line.Split()[1]),
                Convert.ToInt32(line.Split()[3]) - 1,
                Convert.ToInt32(line.Split()[5]) - 1
            });
        }

        return instructions;
    }
    
    private static string GetTextFromStacks(IEnumerable<Stack<char>> stacks)
    {
        var result = new StringBuilder();
        foreach (var stack in stacks)
        {
            result.Append(stack.Pop());
        }

        return result.ToString();
    }
}