// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 3");

StreamReader reader = File.OpenText("input.txt");
var fullText = reader.ReadToEnd();

var rucksacks = fullText.Split("\r\n").ToList();

var duplicateItems = new List<char>();

foreach (var rucksack in rucksacks)
{
    var compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    var compartment2 = rucksack.Substring(rucksack.Length/2);

    foreach (var character in compartment1)
    {
        if (compartment2.Contains(character))
        {
            duplicateItems.Add(character);
            break;
        }        
    }
}

var totalValue = 0;

foreach (var item in duplicateItems)
{
    var value = (int)item % 32;
    if (char.IsUpper(item))
        value = value + 26;
    
    totalValue += value;
}

Console.WriteLine("Total Value: " + totalValue);

//Pt 2

var rucksackGroups = rucksacks.Chunk(3);

var groupChars = new List<char>();

foreach (var rucksackGroup in rucksackGroups)
{
    foreach (var ch in rucksackGroup[0])
    {
        if (rucksackGroup[1].Contains(ch) && rucksackGroup[2].Contains(ch))
        {
            groupChars.Add(ch);
            break;
        }
    }
}

var groupTotalValue = 0;

foreach (var ch in groupChars)
{
    var value = (int)ch % 32;
    if (char.IsUpper(ch))
        value = value + 26;
    
    groupTotalValue += value;
}

Console.WriteLine("Total Group Value: " + groupTotalValue);