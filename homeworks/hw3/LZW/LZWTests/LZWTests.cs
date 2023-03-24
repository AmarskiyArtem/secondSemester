namespace LZWTests
{
    public class Tests
    {
        [Test]
        public void EncodeAndDecodeShouldSame()
        {
            LZWTransform.Compress(@"../../../../LZWTests/TestsFiles/v.mp4");
        }
    }
}