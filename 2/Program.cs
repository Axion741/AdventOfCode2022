// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code: Day 2");

StreamReader reader = File.OpenText("input.txt");
var fullText = reader.ReadToEnd();

var matchupStrings = fullText.Split("\r\n").ToList();

var matchups = new List<Matchup>();

foreach (var matchupString in matchupStrings)
{
    var opposingChar = matchupString.First();
    var playerChar = matchupString.Last();

    var opposingMove = GenerateMove(opposingChar);
    var playerMove = GenerateMove(playerChar);

    matchups.Add(new Matchup(opposingMove, playerMove));
} 

Console.WriteLine("Total Score: " + matchups.Sum(s => s.Result));

//Pt 2

var correctMatchups = new List<Matchup>();

foreach (var matchupString in matchupStrings)
{
    var opposingChar = matchupString.First();
    var playerActionChar = matchupString.Last();

    var opposingMove = GenerateMove(opposingChar);
    var playerMove = GenerateActionMove(opposingMove, playerActionChar);

    correctMatchups.Add(new Matchup(opposingMove, playerMove));
}

Console.WriteLine("Correct Total Score: " + correctMatchups.Sum(s => s.Result));

IMove GenerateMove(char ch) 
{
    switch (ch)
    {
        case 'A':
        case 'X':
            return new Rock(true);

        case 'B':
        case 'Y':
            return new Paper(true);

        case 'C':
        case 'Z':
            return new Scissors(true);

        default:
            return null;
    }
}

IMove GenerateActionMove(IMove opposingMove, char playerActionChar)
{
    switch (playerActionChar)
    {
        case 'X':
            return opposingMove.GenerateFullBeatsObject();

        case 'Y':
            return opposingMove;
        
        case 'Z':
            return opposingMove.GenerateFullLosingObject();
        
        default:
            return null;
    }
}