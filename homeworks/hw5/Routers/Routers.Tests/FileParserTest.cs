using Routers.Exceptions;

namespace Routers.Tests;

public class FileParserTest
{
    [Test]
    public void CorrectFileShouldCorrectParse()
    {
        var graph = FileParser.GetGraphFromFile(@"../../../TestFiles/CorrectTestFile.txt");
        var rightResult = new Dictionary<(int, int), int>
        {
            { (1, 2), 10 },
            { (1, 3), 5 },
            { (1, 5), 4 },
            { (2, 3), 1 },
            { (2, 4), 3 },
            { (3, 5), 14 },
        };
        Assert.IsTrue(PrimTests.IsEqualDicts(graph, rightResult));
    }

    [Test]
    public void InvaildLinesShouldException()
    {
        Assert.Throws<InvalidLineException>(() => FileParser.GetGraphFromFile(@"../../../TestFiles/IncorrectTestFile.txt"));
    }
}
