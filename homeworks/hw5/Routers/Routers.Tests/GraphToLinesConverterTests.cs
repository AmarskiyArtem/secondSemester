namespace Routers.Tests;

public class GraphToLinesConverterTests
{
    [Test]
    public void GraphShouldRightArray()
    {
        var graph = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (3, 5), 11 },
            { (2, 5), 10 },
            { (4, 5), 30 },
        };
        var result = GraphToLinesConverter.GetLinesFromGraph(graph);
        var rightResult = new string[] { "1: 4 (15)", "3: 5 (11)", "2: 5 (10)", "4: 5 (30)" };
        Assert.That(result, Is.EqualTo(rightResult));
    }

    [Test]
    public void EmptyGraphShouldNormalReaction()
    {
        Assert.That(GraphToLinesConverter.GetLinesFromGraph(new Dictionary<(int, int), int>()), Is.EqualTo(new string[0]));
    }
}
