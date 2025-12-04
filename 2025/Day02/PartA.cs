#!/home/jeff/.dotnet/dotnet run

string input = Console.ReadLine()!;
long result = 0;
foreach (string range in input.Split(","))
{
    string[] pieces = range.Split('-');
    long start = long.Parse(pieces[0]);
    long end = long.Parse(pieces[1]);
    for (long i = start; i <= end; i++)
    {
        ReadOnlySpan<char> str = i.ToString().AsSpan();
        int length = str.Length;
        if (length % 2 == 0)
        {
            int halfLength = length / 2;
            if (str[..halfLength].SequenceEqual(str[halfLength..]))
            {
                result += i;
            }
        }
    }
}
Console.WriteLine(result);
