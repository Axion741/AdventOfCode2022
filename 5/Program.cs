Console.WriteLine("Advent of Code: Day 5");

StreamReader reader = File.OpenText("input.txt");
var fullText = reader.ReadToEnd();
var textList = fullText.Split("\r\n").ToList();

var pileLists = textList.Where(w => w.Trim().StartsWith('[')).ToList();
var numberLine = textList[8];
var pilesList = BuildInitialPiles(pileLists, numberLine);

var moveLines = textList.Where(w => w.Trim().StartsWith("move")).ToList();
var moveList = BuildMoves(moveLines);

foreach (var move in moveList)
{
    pilesList = PerformMove(pilesList, move);
}

var answerStr = "";

foreach (var pile in pilesList)
{
    answerStr = answerStr + pile.Crates.First();
}

Console.WriteLine("Top crates in each pile: " + answerStr);

//Pt 2

var pilesList2 = BuildInitialPiles(pileLists, numberLine);

foreach (var move in moveList)
{
    pilesList2 = PerformUpgradedMove(pilesList2, move);
}

var answerStr2 = "";

foreach (var pile in pilesList2)
{
    answerStr2 = answerStr2 + pile.Crates.First();
}

Console.WriteLine("Top crates in each pile with 9001: " + answerStr2);

List<Pile> BuildInitialPiles(List<string> input, string numberLine)
{
    var sanitizedInput = new List<string>();
    var numberChars = numberLine.ToCharArray();
    var piles = new List<Pile>();

    for (int i = 0; i < numberLine.Length; i++)
    {
        if (Char.IsDigit(numberChars[i]) == false)
            continue;

        var newPile = new Pile();

        newPile.Number = int.Parse(numberChars[i].ToString());

        var crateList = new List<string>();

        foreach (var line in input)
        {
            var lineChars = line.ToCharArray();

            if (lineChars[i] == ' ')
                continue;

            crateList.Add(lineChars[i].ToString());
        }

        newPile.Crates = crateList;

        piles.Add(newPile);
    }

    return piles;
}

List<Move> BuildMoves(List<string> moveStrings)
{
    var moves = new List<Move>();

    foreach (var str in moveStrings)
    {
        var move = new Move();

        var numberStr = str.Replace("move ", string.Empty).Replace(" from ", " ").Replace(" to ", " ");
        var numberStrArr = numberStr.Split(' ');
        var numberList = new List<int>();

        foreach (var numStr in numberStrArr)
        {
            numberList.Add(int.Parse(numStr));
        }

        move.Amount = int.Parse(numberList[0].ToString());
        move.Source = int.Parse(numberList[1].ToString());
        move.Destination = int.Parse(numberList[2].ToString());

        moves.Add(move);
    }

    return moves;
}

List<Pile> PerformMove(List<Pile> pileList, Move move)
{
    var sourcePile = pileList.First(f => f.Number == move.Source);
    var destinationPile = pileList.First(f => f.Number == move.Destination);
    
    for (int i = 0; i < move.Amount; i++)
    {
        var crate = sourcePile.Crates.FirstOrDefault();

        if(crate == null)
            break;

        destinationPile.Crates.Insert(0, crate);
        sourcePile.Crates.Remove(crate);
    }

    return pileList;
}

List<Pile> PerformUpgradedMove(List<Pile> pileList, Move move)
{
    var sourcePile = pileList.First(f => f.Number == move.Source);
    var destinationPile = pileList.First(f => f.Number == move.Destination);

    if (sourcePile.Crates.Count == 0)
        return pileList;

    if (move.Amount > sourcePile.Crates.Count)
        move.Amount = sourcePile.Crates.Count;

    destinationPile.Crates.InsertRange(0, sourcePile.Crates.GetRange(0, move.Amount));
    sourcePile.Crates.RemoveRange(0, move.Amount);

    return pileList;
}