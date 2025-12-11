#!/home/jeff/.dotnet/dotnet run

#:package Microsoft.Z3@4.11.2

using Microsoft.Z3;

long total = 0;
Context ctx = new();
while (Console.ReadLine() is string line)
{
    string[] pieces = line.Split(' ');
    List<List<int>> buttons = [.. pieces[1..^1].Select(str => str[1..^1].Split(',').Select(int.Parse).ToList())];
    List<int> joltage = [.. pieces[^1][1..^1].Split(',').Select(int.Parse)];

    Optimize solver = ctx.MkOptimize();
    List<IntExpr> variables = [.. buttons.Select((x, i) => ctx.MkIntConst("X" + i))];
    solver.MkMinimize(variables.Aggregate((a, b) => (IntExpr)ctx.MkAdd(a, b)));

    foreach (IntExpr variable in variables)
    {
        solver.Assert(ctx.MkGe(variable, (IntExpr)ctx.MkNumeral(0, ctx.IntSort)));
    }

    for (int joltageIndex = 0; joltageIndex < joltage.Count; joltageIndex++)
    {
        solver.Assert(ctx.MkEq(ctx.MkNumeral(joltage[joltageIndex], ctx.IntSort), buttons
            .Select((button, buttonIndex) => button.Contains(joltageIndex) ? variables[buttonIndex] : null)
            .Where(x => x != null)
            .Aggregate((a, b) => (IntExpr)ctx.MkAdd(a, b))));
    }

    if (solver.Check() != Status.SATISFIABLE)
    {
        throw new Exception();
    }
    Model model = solver.Model;
    total += variables.Sum(x => ((IntNum)model.ConstInterp(x)).Int);
}
Console.WriteLine(total);
