using AdventOfCode.Console.Solutions;
using AdventOfCode.Console.Solutions._2022;

const string filePath = @"aoc.txt";
var lines = File.ReadAllLines(filePath);

// Just replace the content of the file with your input
ISolution<int> solution = new Day6(lines);

Console.WriteLine($"Part 1: {solution.Part1()}");
Console.WriteLine($"Part 2: {solution.Part2()}");