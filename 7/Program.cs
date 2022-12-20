// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 7");

StreamReader reader = System.IO.File.OpenText("input.txt");
var consoleOutput = reader.ReadToEnd();
var consoleOutputLines = consoleOutput.Split("\r\n").ToList();
var baseDirectory = ParseDirectory(consoleOutputLines);
var totalOfDirectoriesUpTo100000 = SumOfDirectoriesUpTo100000(baseDirectory);

Console.WriteLine("Total of Directories upto 100000: " + totalOfDirectoriesUpTo100000);

//Pt 2

var sizeOfDeletableDirectory = FindDeleteableDirectory(ParseDirectory(consoleOutputLines, false));

Console.WriteLine("Size of Directory to Delete: " + sizeOfDeletableDirectory);

Directory ParseDirectory(List<string> input, bool part1 = true)
{
    var baseDirectory = new Directory("/", null);

    var workingDirectory = baseDirectory;

    foreach (var line in input)
    {
        if (line.StartsWith("dir"))
        {
            workingDirectory.Directories.Add(new Directory(line.Substring(4), workingDirectory));
            continue;
        }

        if (Char.IsDigit(line.First()))
        {
            var data = line.Split(" ");
            var file = new File(data[1], long.Parse(data[0]));
            workingDirectory.Files.Add(file);
            if (part1)
                workingDirectory.IncreaseSize(file.Size);
            else 
                workingDirectory.Size += file.Size;
            continue;
        }

        if (line == "$ cd /")
        {
            workingDirectory = baseDirectory;
            continue;
        }

        if (line.StartsWith("$ cd"))
        {
            if (line.Contains(".."))
            {
                workingDirectory = workingDirectory.ParentDirectory;
                continue;
            }  
            else 
            {
                var target = line.Substring(5);
                workingDirectory = workingDirectory.Directories.First(w => w.Name == target);
                continue;
            }
        }        
    }

    return baseDirectory;
}

long SumOfDirectoriesUpTo100000(Directory dir)
{
    long total = 0;

    if (dir.Size <= 100000)
        total += dir.Size;

    foreach (var childDir in dir.Directories)
    {
        total += SumOfDirectoriesUpTo100000(childDir);
    }

    return total;
}

long FindDeleteableDirectory(Directory baseDirectory)
{
    long totalSpace = 70000000;
    long updateSpace = 30000000;
    var usedSpace = CalculateUsedSpace(baseDirectory);

    long availableSpace = totalSpace - usedSpace;
    long requiredSpace = updateSpace - availableSpace;

    Console.WriteLine("Space Required To Perform Update: " + requiredSpace);

    var smallestDirSize = CalculateSmallestDeletableDirectory(baseDirectory, requiredSpace);

    return smallestDirSize;
}

long CalculateUsedSpace(Directory dir)
{
    var total = dir.Size;

    foreach (var childDir in dir.Directories)
    {
        total += CalculateUsedSpace(childDir);
    }

    return total;
}

long CalculateSmallestDeletableDirectory(Directory baseDirectory, long requiredSpace) 
{
    var smallestDirSize = CalculateUsedSpace(baseDirectory);

    foreach (var childDir in baseDirectory.Directories)
    {
        var dirSize = CalculateSmallestDeletableDirectory(childDir, requiredSpace);

        if (dirSize > requiredSpace && dirSize < smallestDirSize)
            smallestDirSize = dirSize;
    }

    return smallestDirSize;
}