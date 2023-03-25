namespace LZWTests;

public class Tests
{

    [Test]
    public void EncodeAndDecodeShouldSame()
    {
        LZWTransform.Compress(@"../../../../LZWTests/TestsFiles/HarryPotter.txt");
        LZWTransform.Decompress(@"../../../../LZWTests/TestsFiles/HarryPotter.txt.zipped");

    }
}