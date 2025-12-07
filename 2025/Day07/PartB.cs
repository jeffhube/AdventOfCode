#!/home/jeff/.dotnet/dotnet run

List<string> lines = [];
while (Console.ReadLine() is string line)
{
    lines.Add(line);
}

Dictionary<int, long> current = [];
current.Add(lines[0].IndexOf('S'), 1);
long total = 1;
foreach (string line in lines.Skip(1))
{
    Dictionary<int, long> next = [];
    foreach ((int i, long value) in current)
    {
        if (line[i] == '^')
        {
            next[i - 1] = value + next.GetValueOrDefault(i - 1);
            next[i + 1] = value + next.GetValueOrDefault(i + 1);
            total += value;
        }
        else
        {
            next[i] = value + next.GetValueOrDefault(i);
        }
    }
    current = next;
}
Console.WriteLine(total);
