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

long total = 0;
long current = 0;
foreach (Range range in ranges)
{
    long start = Math.Max(range.Start, current);
    if (range.End >= start)
    {
        current = range.End + 1;
        total += current - start;
    }
}
Console.WriteLine(total);

record struct Range(long Start, long End);
