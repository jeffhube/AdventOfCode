#!/home/jeff/.dotnet/dotnet run

List<string> rows = [];
while (Console.ReadLine() is string row)
{
    rows.Add(row);
}

int rowCount = rows.Count;
int colCount = rows[0].Length;
int total = 0;

for (int r = 0; r < rowCount; r++)
{
    string row = rows[r];
    for (int c = 0; c < colCount; c++)
    {
        if (row[c] == '.')
        {
            continue;
        }

        int adjacent = GetNeighbors(new Coord(r, c)).Count(x => rows[x.Row][x.Column] == '@');
        if (adjacent < 4)
        {
            total++;
        }
    }
}
Console.WriteLine(total);

IEnumerable<Coord> GetNeighbors(Coord coord)
{
    int minRow = Math.Max(0, coord.Row - 1);
    int maxRow = Math.Min(rowCount - 1, coord.Row + 1);
    int minCol = Math.Max(0, coord.Column - 1);
    int maxCol = Math.Min(colCount - 1, coord.Column + 1);
    for (int r = minRow; r <= maxRow; r++)
    {
        for (int c = minCol; c <= maxCol; c++)
        {
            if (r != coord.Row || c != coord.Column)
            {
                yield return new Coord(r, c);
            }
        }
    }
}

record struct Coord(int Row, int Column);
