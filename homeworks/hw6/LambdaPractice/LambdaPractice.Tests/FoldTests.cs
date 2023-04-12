namespace LambdaPractice.Tests;

public class FoldTests
{
    [Test]
    public void IntToIntTest()
    {
        var list = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9,
        };
        Assert.That(Funcs.Fold<int, int>(list, 0, (x, acc) => x + acc), Is.EqualTo(45));
    }

    [Test]
    public void StringToIntTest()
    {
        var list = new List<string>()
        {
            "1", "M2", "Fd3", "ttt4"
        };
        Assert.That(Funcs.Fold<string, int>(list, 0, (x, acc) => acc + x.Length), Is.EqualTo(10));
    }
}
