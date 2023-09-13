namespace BracketBalance.Tests;

public class ValidBrackerSequenceTests
{

    [Test]
    public void ValidSequenceShouldTrue()
    {
        Assert.That(ValidBrackerSequence.IsValidBracketSequence("<()[]>"), Is.EqualTo(true));
    }

    [Test]
    public void EmptyStringShouldTrue()
    {
        Assert.That(ValidBrackerSequence.IsValidBracketSequence(String.Empty), Is.EqualTo(true));
    }

    [Test]
    public void InvalidSequenceShouldFalse()
    {
        Assert.That(ValidBrackerSequence.IsValidBracketSequence("<(>[]>"), Is.EqualTo(false));
    }

}