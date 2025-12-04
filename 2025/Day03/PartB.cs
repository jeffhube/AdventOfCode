#!/home/jeff/.dotnet/dotnet run

const int BATTERY_COUNT = 12;
long total = 0;
while (Console.ReadLine() is string line)
{
    char[] batteries = line.AsSpan()[^BATTERY_COUNT..].ToArray();
    for (int i = line.Length - BATTERY_COUNT - 1; i >= 0; i--)
    {
        char current = line[i];
        for (int j = 0; j < BATTERY_COUNT; j++)
        {
            if (current >= batteries[j])
            {
                (batteries[j], current) = (current, batteries[j]);
            }
            else
            {
                break;
            }
        }
    }
    long value = 0;
    for (int i = 0; i < BATTERY_COUNT; i++)
    {
        value = value * 10 + batteries[i] - '0';
    }
    total += value;
}
Console.WriteLine(total);
