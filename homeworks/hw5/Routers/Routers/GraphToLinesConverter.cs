namespace Routers;

public static class GraphToLinesConverter
{
    public static string[] GetLinesFromGraph(Dictionary<(int, int), int> graph)
    {
        var lines = new List<string>();
        foreach (var edge in graph)
        {
            lines.Add($"{edge.Key.Item1}: {edge.Key.Item2} ({edge.Value})");
        }
        return lines.ToArray();
    }
}
