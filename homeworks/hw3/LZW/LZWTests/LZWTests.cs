namespace LZWTests;

public class Tests
{
    private static IEnumerable<TestCaseData> Path()
    {
        yield return new TestCaseData(@"../../../TestFiles/HarryPotter.txt");
        yield return new TestCaseData(@"../../../TestFiles/NeverGonnaGiveUup.mp3");
        yield return new TestCaseData(@"../../../TestFiles/shad.jpg");
    }

    [TestCaseSource(nameof(Path))]
    public void EncodeAndDecodeShouldSame(string path)
    {
        var data = File.ReadAllBytes(path);
        byte[] dataCopy = new byte[data.Length];
        Array.Copy(data, dataCopy, data.Length);
        data = LZWEncoder.Encode(data, true);
        data = LZWDecoder.Decode(data);
        Assert.IsTrue(data.SequenceEqual(dataCopy));
    }

    [Test]
    public void TryingToEncodeNullShouldException()
    {
        Assert.Throws<ArgumentNullException>(() => LZWEncoder.Encode(null!, false)); // :)
    }

    [Test]
    public void TryingToDecodeNullShouldException()
    {
        Assert.Throws<ArgumentNullException>(() => LZWDecoder.Decode(null!));
    }

    [Test]
    public void TryingToEncodeEmptyShouldException()
    {
        Assert.Throws<ArgumentException>(() => LZWEncoder.Encode(new byte[0], true));
    }

    [Test]
    public void TryingToDecodeEmptyShouldException()
    {
        Assert.Throws<ArgumentException>(() => LZWDecoder.Decode(new byte[0]));
    }

    [Test]
    public void CompressNonExistentFileShouldExpection()
    {
        Assert.Throws<FileNotFoundException>(() => LZWTransform.Compress(@"../ghost.txt"));
    }

    [Test]
    public void DecompressNonExistentFileShouldExpection()
    {
        Assert.Throws<FileNotFoundException>(() => LZWTransform.Decompress(@"../../ghost.txt"));
    }

    [Test]
    public void DecompressNonZippedFileShouldExpection()
    {
        Assert.Throws<ArgumentException>(() => LZWTransform.Decompress(@"../../../TestFiles/HarryPotter.zip"));
    }
}