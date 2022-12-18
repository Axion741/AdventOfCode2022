// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 4");

StreamReader reader = File.OpenText("input.txt");
var fullText = reader.ReadToEnd();

var cleaningPairs = fullText.Split("\r\n").ToList();
var overlappedPairs = new List<string>();

foreach (var pair in cleaningPairs)
{
    var assignments = pair.Split(',');
    var mappedAssignment1 = GenerateAssignmentList(assignments[0]);
    var mappedAssignment2 = GenerateAssignmentList(assignments[1]);

    if (CompareAssignments(mappedAssignment1, mappedAssignment2))
    {
        overlappedPairs.Add(pair);
    }
}

Console.WriteLine("Total Overlapped Pairs: " + overlappedPairs.Count);

//Pt 2

var overlappedAtAll = new List<string>();

foreach (var pair in cleaningPairs)
{
    var assignments = pair.Split(',');
    var mappedAssignment1 = GenerateAssignmentList(assignments[0]);
    var mappedAssignment2 = GenerateAssignmentList(assignments[1]);

    if (DoAssignmentsOverlapAtAll(mappedAssignment1, mappedAssignment2))
    {
        overlappedAtAll.Add(pair);
    }
}

Console.WriteLine("Total Overlapped At All Pairs: " + overlappedAtAll.Count);

List<int> GenerateAssignmentList(string bounds)
{
    var assignmentList = new List<int>();
    var assignmentStringList = bounds.Split('-');

    foreach (var str in assignmentStringList)
    {
        assignmentList.Add(int.Parse(str));
    }
    // var start = int.Parse(bounds.First().ToString());
    // var last = int.Parse(bounds.Last().ToString());

    // var assignmentList = new List<int>();

    // assignmentList.Add(start);
    // assignmentList.Add(last);
    // for (int i = start; i < last; i++)
    // {
    //     assignmentList.Add(i);
    // }

    return assignmentList;
}

bool CompareAssignments(List<int> first, List<int> second)
{
    if (first.First() >= second.First() && first.Last() <= second.Last())
        return true;

    if (second.First() >= first.First() && second.Last() <= first.Last())
        return true;

    return false;
}

bool DoAssignmentsOverlapAtAll(List<int> first, List<int> second)
{
    if (first.First() >= second.First() && first.First() <= second.Last())
        return true;

    if (first.Last() >= second.First() && first.Last() <= second.Last())
        return true;

    if (second.First() >= first.First() && second.First() <= first.Last())
        return true;

    if (second.Last() >= first.First() && second.Last() <= first.Last())
        return true;

        return false;
}