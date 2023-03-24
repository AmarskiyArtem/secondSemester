namespace LZW.Buffers;

internal class CompressByteBuffer
{
    public List<byte> Data { get; private set; } = new();

    public int CurrentNumberOfBitsPerNumber { get; set; } = 9;

    public byte CurrentByte { get; private set; } = 0;

    private int bitsInCurrentByte = 0;

    private const int BitsInByte = 8;

    public void AddNumberToData(int number)
    {
        var bits = GetBitsFromNumber(number);
        foreach (var bit in bits)
        {
            CurrentByte = (byte)((CurrentByte << 1) + bit);
            bitsInCurrentByte++;
            if (bitsInCurrentByte == BitsInByte)
            {
                AddByteToData();
            }
        }
    }

    public void AddByteToData()
    {
        Data.Add(CurrentByte);
        CurrentByte = 0;
        bitsInCurrentByte = 0;
    }

    private byte[] GetBitsFromNumber(int number)
    {
        var bits = new byte[CurrentNumberOfBitsPerNumber];
        for (var i = CurrentNumberOfBitsPerNumber - 1; i >= 0; i--)
        {
            bits[i] = (byte)(number % 2);
            number >>= 1;
        }
        return bits;
    }
}
