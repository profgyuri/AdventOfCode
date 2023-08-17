namespace AdventOfCode.Console.Solutions._2022.Day7;

internal class Directory
{
    public string Name { get; set; }
    public Directory Parent { get; set; }
    public List<Directory> Children { get; set; } = new();
    public int Size { get; set; }
}