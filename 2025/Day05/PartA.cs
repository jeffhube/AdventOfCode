#!/home/jeff/.dotnet/dotnet run

List<Range> ranges = [];
while (Console.ReadLine() is string range && range != "")
{
    string[] pieces = range.Split('-');
    long start = long.Parse(pieces[0]);
    long end = long.Parse(pieces[1]);
    ranges.Add(new Range(start, end));
}
ranges.Sort((x, y) => x.Start.CompareTo(y.Start));

int total = 0;
while (Console.ReadLine() is string ingredientString)
{
    long ingredient = long.Parse(ingredientString);
    foreach (Range range in ranges)
    {
        if (ingredient >= range.Start)
        {
            if (ingredient <= range.End)
            {
                total++;
                break;
            }
        }
        else
        {
            break;
        }
    }
}
Console.WriteLine(total);

record struct Range(long Start, long End);
