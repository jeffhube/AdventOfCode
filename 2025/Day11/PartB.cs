#!/home/jeff/.dotnet/dotnet run

Dictionary<string, int> deviceIdsByName = [];
Dictionary<int, Device> devicesById = [];
while (Console.ReadLine() is string line)
{
    int colon = line.IndexOf(':');
    Device device = GetDevice(line[..colon]);
    foreach (string output in line[(colon + 2)..].Split(' '))
    {
        device.Outputs.Add(GetDevice(output));
    }
}
Console.WriteLine((long)CountPaths("svr", "fft") * CountPaths("fft", "dac") * CountPaths("dac", "out"));

Device GetDevice(string name)
{
    if (!deviceIdsByName.TryGetValue(name, out int id))
    {
        id = deviceIdsByName.Count;
        deviceIdsByName[name] = id;
        Device device = new(id, []);
        devicesById[id] = device;
    }
    return devicesById[id];
}

int CountPaths(string from, string to)
{
    Dictionary<int, int> memo = new() { { GetDevice(to).Id , 1 } };
    return CountPathsMemo(GetDevice(from), memo);
}

int CountPathsMemo(Device device, Dictionary<int, int> memo)
{
    if (memo.TryGetValue(device.Id, out int result))
    {
        return result;
    }
    result = device.Outputs.Sum(x => CountPathsMemo(x, memo));
    memo[device.Id] = result;
    return result;
}

record Device(int Id, List<Device> Outputs);
