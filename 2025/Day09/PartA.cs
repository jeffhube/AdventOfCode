#!/home/jeff/.dotnet/dotnet run

using System.Numerics;

List<Vector2> vertices = [];
while (Console.ReadLine() is string line)
{
    string[] pieces = line.Split(',');
    vertices.Add(new Vector2(int.Parse(pieces[0]), int.Parse(pieces[1])));
}

long largest = 0;
for (int i = 0; i < vertices.Count; i++)
{
    for (int j = 0; j < i; j++)
    {
        Vector2 a = vertices[i];
        Vector2 b = vertices[j];
        long area = ((long)Math.Abs(b.X - a.X) + 1) * ((long)Math.Abs(b.Y - a.Y) + 1);
        largest = Math.Max(largest, area);
    }
}
Console.WriteLine(largest);
