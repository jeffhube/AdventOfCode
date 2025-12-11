#!/home/jeff/.dotnet/dotnet run

long total = 0;
while (Console.ReadLine() is string line)
{
    string[] pieces = line.Split(' ');
    int indicatorLength = pieces[0].Length - 2;
    long indicators = pieces[0][1..^1].Aggregate(0, (a, b) => (a << 1) + (b == '#' ? 1 : 0));
    List<long> buttons = [.. pieces[1..^1].Select(str => str[1..^1].Split(',').Sum(x => 1L << indicatorLength - 1 - int.Parse(x)))];
    total += CountPresses(indicators, buttons);
}
Console.WriteLine(total);

static int CountPresses(long indicators, List<long> buttons)
{
    State initial = new(0, 0);
    Queue<State> states = [];
    states.Enqueue(initial);
    while (true)
    {
        State current = states.Dequeue();
        int newPresses = current.Presses + 1;
        foreach (long button in buttons)
        {
            long newIndicators = current.Indicators ^ button;
            if (newIndicators == indicators)
            {
                return newPresses;
            }
            states.Enqueue(new State(newIndicators, newPresses));
        }
    }
}

record struct State(long Indicators, int Presses);
