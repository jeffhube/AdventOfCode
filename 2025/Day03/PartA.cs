#!/home/jeff/.dotnet/dotnet run

int total = 0;
while (Console.ReadLine() is string line)
{
    char first = line[^2];
    char second = line[^1];
    for (int i = line.Length - 3; i >= 0; i--)
    {
        char c = line[i];
        if (c >= first)
        {
            if (first > second)
            {
                second = first;
            }
            first = c;
        }
    }
    total += 10 * (first - '0') + second - '0';
}
Console.WriteLine(total);
