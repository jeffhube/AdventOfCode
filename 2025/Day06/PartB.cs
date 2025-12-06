#!/home/jeff/.dotnet/dotnet run

List<string> lines = [];
while (Console.ReadLine() is string line)
{
    lines.Add(line);
}

int operatorRowIndex = lines.Count - 1;
string operators = lines[operatorRowIndex];
long total = 0;
long current = 0;
Func<long, long, long> aggregator = null!;
for (int c = 0; c < operators.Length; c++)
{
    if (operators[c] == '*')
    {
        total += current;
        aggregator = (a, b) => a * b;
        current = 1;
    }
    else if (operators[c] == '+')
    {
        total += current;
        aggregator = (a, b) => a + b;
        current = 0;
    }

    long operand = 0;
    for (int r = 0; r < operatorRowIndex; r++)
    {
        char ch = lines[r][c];
        if (ch != ' ')
        {
            operand = operand * 10 + ch - '0';
        }
    }

    if (operand != 0)
    {
        current = aggregator(current, operand);
    }
}
Console.WriteLine(total + current);
