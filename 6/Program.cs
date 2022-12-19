// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 6");

StreamReader reader = File.OpenText("input.txt");
var buffer = reader.ReadToEnd();
var marker = FindMarkerFromBuffer(buffer);

Console.WriteLine("Marker Length: " + marker.Length);

//Pt2

var message = FindMessageFromBuffer(buffer);

Console.WriteLine("Message Length: " + message.Length);

string FindMarkerFromBuffer(string buffer)
{
    var bufferChars = buffer.ToCharArray();
    var markerChars = new List<char>();
    var markerEndIndex = 0;

    foreach (var chr in bufferChars)
    {
        markerEndIndex++;
        
        while (markerChars.Contains(chr))
        {
            markerChars.RemoveAt(0);
        }
            
        markerChars.Add(chr);

        if (markerChars.Count == 4)
            break;
    }

    return buffer.Substring(0, markerEndIndex);
}

string FindMessageFromBuffer(string buffer)
{
    var bufferChars = buffer.ToCharArray();
    var markerChars = new List<char>();
    var markerEndIndex = 0;

    foreach (var chr in bufferChars)
    {
        markerEndIndex++;
        
        while (markerChars.Contains(chr))
        {
            markerChars.RemoveAt(0);
        }
            
        markerChars.Add(chr);

        if (markerChars.Count == 14)
            break;
    }

    return buffer.Substring(0, markerEndIndex);
}