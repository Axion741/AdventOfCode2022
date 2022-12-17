// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 1");

StreamReader reader = File.OpenText("input.txt");
var fullText = reader.ReadToEnd();

var inventoryStrings = fullText.Split("\r\n\r\n").ToList();

List<Inventory> inventories = new List<Inventory>();

foreach (var inventory in inventoryStrings)
{
    var inventoryItems = inventory.Split("\r\n");
    var intList = new List<int>();

    foreach (var item in inventoryItems)
    {
        var value = int.TryParse(item, out var result);

        if (value)
            intList.Add(result);
    }

    inventories.Add(new Inventory(intList));
}

inventories = inventories.OrderByDescending(o => o.Total).ToList();

Console.WriteLine("Highest Value: " + inventories.First().Total);

//Pt 2

Console.WriteLine("Sum of Top Three: " + inventories.GetRange(0, 3).Sum(s => s.Total));

