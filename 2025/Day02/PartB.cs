#!/home/jeff/.dotnet/dotnet run

string input = Console.ReadLine()!;
long result = 0;
foreach (string range in input.Split(','))
{
    string[] pieces = range.Split('-');
    long start = long.Parse(pieces[0]);
    long end = long.Parse(pieces[1]);
    for (long i = start; i <= end; i++)
    {
        if (IsInvalid(i))
        {
            result += i;
        }
    }
}
Console.WriteLine(result);

static bool IsInvalid(long id)
{
    ReadOnlySpan<char> str = id.ToString().AsSpan();
    int length = str.Length;
    for (int repLength = 1; repLength <= length / 2; repLength++)
    {
        if (length % repLength != 0)
        {
            continue;
        }
        bool invalid = true;
        for (int offset = repLength; offset < length; offset += repLength)
        {
            if (!str[..repLength].SequenceEqual(str.Slice(offset, repLength)))
            {
                invalid = false;
                break;
            }
        }
        if (invalid)
        {
            return true;
        }
    }
    return false;
}
