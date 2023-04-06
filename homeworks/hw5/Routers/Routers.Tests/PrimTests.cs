namespace Routers.Tests;


/*
 *  1: 4(15), 3(4), 2(3)
    2: 4(8), 5(10)
    3: 5(11)
    4: 5(30)
 */
public class PrimTests
{
    private static bool IsEqualDicts(Dictionary<(int, int), int> first, Dictionary<(int, int), int> second)
    {
        foreach (var kvp in first)
        {
            if (second[kvp.Key] != kvp.Value)
            {
                return false;
            }
        }
        return first.Count == second.Count;
    }

    [Test]
    public void ConnectedGraphShouldRightSpanningTree()
    {
        var graph = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (1, 3), 4 },
            { (1, 2), 3 },
            { (2, 4), 8 },
            { (2, 5), 10 },
            { (3, 5), 11 },
            { (4, 5), 30 },
        };
        var rightSpanningTree = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (3, 5), 11 },
            { (2, 5), 10 },
            { (4, 5), 30 },
        };
        var spanningTree = Prim.GetMaximalSpanningTree(graph);
        Assert.IsTrue(IsEqualDicts(spanningTree, rightSpanningTree));
    }
}