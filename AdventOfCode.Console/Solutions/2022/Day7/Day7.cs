namespace AdventOfCode.Console.Solutions._2022.Day7;

internal class Day7 : ISolution<int>
{
    private readonly string[] _input;

    private Directory _root = new() 
    {
        Name = "/"
    };
    private Directory _currentDirectory;
    private List<Directory> _directories = new();

    public Day7(string[] input)
    {
        _input = input;
        _directories.Add(_root);
    }

    public int Part1()
    {
        long result = 0;

        foreach (var line in _input)
        {
            switch (line)
            {
                case "$ cd /":
                    _currentDirectory = _root;
                    break;
                case "$ cd ..":
                    _currentDirectory = _currentDirectory.Parent;
                    break;
                case var l when l.StartsWith("$ cd ") && !l.EndsWith("/") && !l.EndsWith(".."):
                    var directoryName = l.Split()[^1];
                    var directory = _currentDirectory.Children.FirstOrDefault(d => d.Name == directoryName);
                    if (directory is null)
                    {
                        directory = new Directory
                        {
                            Name = directoryName,
                            Parent = _currentDirectory
                        };
                        _currentDirectory.Children.Add(directory);
                        _directories.Add(directory);
                    }

                    _currentDirectory = directory;
                    break;
                case var l when int.TryParse(l.Split()[0], out var size):
                    _currentDirectory.Size += size;
                    //_directories[_directories.IndexOf(_currentDirectory)].Size += size;

                    var tempDirectory = _currentDirectory;

                    while (tempDirectory.Parent is not null)
                    {
                        tempDirectory = tempDirectory.Parent;
                        tempDirectory.Size += size;
                        //_directories[_directories.IndexOf(_currentDirectory)].Size += size;
                    }

                    break;
                default:
                    break;
            }
        }

        return _directories.Where(x => x.Size <= 100000).Select(x => x.Size).Sum();
    }

    public int Part2()
    {
        int needed = _root.Size + 30_000_000 - 70_000_000;
        return _directories
            .OrderBy(x => x.Size)
            .Select(x => x.Size)
            .First(x => x >= needed);
    }
}