#!/home/jeff/.dotnet/dotnet run

using System.Numerics;

List<Vector3> vertices = [];
while (Console.ReadLine() is string line)
{
    string[] pieces = line.Split(',');
    vertices.Add(new Vector3(int.Parse(pieces[0]), int.Parse(pieces[1]), int.Parse(pieces[2])));
}

List<Edge> edges = [];
for (int i = 0; i < vertices.Count; i++)
{
    for (int j = 0; j < i; j++)
    {
        edges.Add(new Edge(i, j, (vertices[i] - vertices[j]).LengthSquared()));
    }
}

edges.Sort((a, b) => a.LengthSquared.CompareTo(b.LengthSquared));

Dictionary<int, List<int>> verticesByCircuit = [];
Dictionary<int, int> circuitByVertex = [];

for (int i = 0; i < edges.Count; i++)
{
    Edge edge = edges[i];
    List<int> newCircuitVertices = [];

    if (circuitByVertex.TryGetValue(edge.VertexA, out int existingCircuitA))
    {
        newCircuitVertices.AddRange(verticesByCircuit[existingCircuitA]);
        verticesByCircuit.Remove(existingCircuitA);
    }
    else
    {
        newCircuitVertices.Add(edge.VertexA);
    }

    if (circuitByVertex.TryGetValue(edge.VertexB, out int existingCircuitB))
    {
        if (existingCircuitA != existingCircuitB)
        {
            newCircuitVertices.AddRange(verticesByCircuit[existingCircuitB]);
            verticesByCircuit.Remove(existingCircuitB);
        }
    }
    else
    {
        newCircuitVertices.Add(edge.VertexB);
    }

    if (newCircuitVertices.Count == 1000)
    {
        Console.WriteLine((int)vertices[edge.VertexA].X * (int)vertices[edge.VertexB].X);
        break;
    }

    verticesByCircuit[i] = newCircuitVertices;
    foreach (int x in newCircuitVertices)
    {
        circuitByVertex[x] = i;
    }
}

record Edge(int VertexA, int VertexB, float LengthSquared);
