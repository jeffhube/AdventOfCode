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
        Vector2 min = Vector2.Min(a, b);
        Vector2 max = Vector2.Max(a, b);
        long area = ((long)(max.X - min.X + 1)) * ((long)(max.Y - min.Y + 1));
        if (area > largest)
        {
            if (IsValid(vertices, min, max))
            {
                largest = area;
            }
        }
    }
}
Console.WriteLine(largest);

static bool IsValid(List<Vector2> vertices, Vector2 rectMin, Vector2 rectMax)
{
    Vector2 vertexPrevious = vertices.Last();
    foreach (Vector2 vertexCurrent in vertices)
    {
        Vector2 edgeMin = Vector2.Min(vertexCurrent, vertexPrevious);
        Vector2 edgeMax = Vector2.Max(vertexCurrent, vertexPrevious);
        if (edgeMin.X == edgeMax.X) // vertical
        {
            if (edgeMin.X > rectMin.X && edgeMin.X < rectMax.X)
            {
                if ((edgeMin.Y < rectMin.Y && edgeMax.Y > rectMin.Y) ||
                    (edgeMin.Y < rectMax.Y && edgeMax.Y > rectMax.Y) ||
                    (edgeMin.Y >= rectMin.Y && edgeMax.Y <= rectMax.Y))
                {
                    return false;
                }
            }
        }
        else // horizontal
        {
            if (edgeMin.Y > rectMin.Y && edgeMin.Y < rectMax.Y)
            {
                if ((edgeMin.X < rectMin.X && edgeMax.X > rectMin.X) ||
                    (edgeMin.X < rectMax.X && edgeMax.X > rectMax.X) ||
                    (edgeMin.X >= rectMin.X && edgeMax.X <= rectMax.X))
                {
                    return false;
                }
            }
        }
        vertexPrevious = vertexCurrent;
    }
    return true;
}
