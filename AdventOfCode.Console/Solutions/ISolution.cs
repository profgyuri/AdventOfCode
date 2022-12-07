namespace AdventOfCode.Console.Solutions;

/// <summary>
/// Contract for a solution to an Advent of Code problem.
/// </summary>
/// <typeparam name="TResult1">The type of the result of the first part.</typeparam>
/// <typeparam name="TResult2">The type of the result of the second part.</typeparam>
internal interface ISolution<out T>
{
    /// <summary>
    /// Solution for the first part of the given day's problem.
    /// </summary>
    /// <returns>The solution to the first part of the problem.</returns>
    T Part1();
    
    /// <summary>
    /// Solution for the second part of the given day's problem.
    /// </summary>
    /// <returns>The solution to the second part of the problem.</returns>
    T Part2();
}