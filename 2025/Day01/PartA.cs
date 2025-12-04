#!/home/jeff/.dotnet/dotnet run

int dial = 50;
int counter = 0;
while (Console.ReadLine() is string line)
{
    int sign = line[0] == 'L' ? -1 : 1;
    int distance = int.Parse(line.AsSpan()[1..]);
    dial = (dial + sign * distance + 100) % 100;
    if (dial == 0)
    {
        counter++;
    }
}
Console.WriteLine(counter);