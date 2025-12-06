#!/home/jeff/.dotnet/dotnet run

List<string> lines = [];
while (Console.ReadLine() is string line)
{
    lines.Add(line);
}

List<List<long>> operands = [.. lines[..^1].Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList())];
List<char> operators = [.. lines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x[0])];
long total = operators.Select((x, i) => operands.Select(o => o[i]).Aggregate(x == '*' ? (a, b) => a * b : (a, b) => a + b)).Sum();
Console.WriteLine(total);
