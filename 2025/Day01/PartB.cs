#!/home/jeff/.dotnet/dotnet run

int dial = 50;
int counter = 0;
while (Console.ReadLine() is string line)
{
    int sign = line[0] == 'L' ? -1 : 1;
    int distance = int.Parse(line.AsSpan()[1..]);
    int value = sign * (distance % 100);
    counter += distance / 100;
    if (value != 0)
    {
        dial += value;
        if (dial == 0)
        {
            counter++;
        }
        else if (dial < 0)
        {
            if (dial - value != 0)
            {
                counter++;
            }
            dial += 100;
        }
        else if (dial >= 100)
        {
            counter++;
            dial -= 100;
        }
    }
}
Console.WriteLine(counter);
