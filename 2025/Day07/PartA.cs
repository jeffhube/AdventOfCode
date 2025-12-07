#!/home/jeff/.dotnet/dotnet run

List<string> lines = [];
while (Console.ReadLine() is string line)
{
    lines.Add(line);
}

HashSet<int> current = [lines[0].IndexOf('S')];
int total = 0;
foreach (string line in lines.Skip(1))
{
    HashSet<int> next = [];
    foreach (int i in current)
    {
        if (line[i] == '^')
        {
            next.Add(i - 1);
            next.Add(i + 1);
            total++;
        }
        else
        {
            next.Add(i);
        }
    }
    current = next;
}
Console.WriteLine(total);
