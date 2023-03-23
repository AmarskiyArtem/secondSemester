using LZW.Buffers;

namespace LZW;

internal class LZWDecoder
{
    public static byte[] Decode(byte[] data)
    {
        var output = new List<byte>();
        var dictionary = FillDictBySingleByteSequences();

    }

    private static Dictionary<int, List<byte>> FillDictBySingleByteSequences()
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256;  i++)
        {
            dictionary[i] = new List<byte>() { (byte)i};
        }
        return dictionary;
    }

    private static int[] GetNumbers(byte[] data)
    {
        var buffer = new DecompressByteBuffer();
    }
}
