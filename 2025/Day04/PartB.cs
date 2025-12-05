#!/home/jeff/.dotnet/dotnet run

List<string> rows = [];
while (Console.ReadLine() is string row)
{
    rows.Add(row);
}

int rowCount = rows.Count;
int colCount = rows[0].Length;
byte[,] adjacentCounts = new byte[rowCount, colCount];

for (int r = 0; r < rowCount; r++)
{
    for (int c = 0; c < colCount; c++)
    {
        if (rows[r][c] == '.')
        {
            adjacentCounts[r, c] = 255;
            continue;
        }

        int adjacent = GetNeighbors(new Coord(r, c)).Count(x => rows[x.Row][x.Column] == '@');
        adjacentCounts[r, c] = (byte)adjacent;
    }
}

int total = 0;
for (int r = 0; r < rowCount; r++)
{
    for (int c = 0; c < colCount; c++)
    {
        TryRemove(new Coord(r, c));
    }
}
Console.WriteLine(total);

void TryRemove(Coord coord)
{
    if (adjacentCounts[coord.Row, coord.Column] >= 4)
    {
        return;
    }

    total++;
    adjacentCounts[coord.Row, coord.Column] = 255;

    foreach (Coord neighbor in GetNeighbors(coord))
    {
        adjacentCounts[neighbor.Row, neighbor.Column]--;
        TryRemove(neighbor);
    }
}

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
