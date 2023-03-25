namespace LZW.Buffers;

internal class DecompressByteBuffer
{
    public List<int> Data { get; private set; } = new();

    public int CurrentBitsPerNumber { get; set; } = 9;

    public int CurrentNumber { get; private set; }
    public int BitsInCurrentNumber { get; private set; }

    private const int BitsInByte = 8;


    public bool AddByteToData(byte bt)
    {
        bool wasAdded = false;
        var bits = GetBitsFromByte(bt);
        foreach (var bit in bits)
        {
            CurrentNumber = (CurrentNumber << 1) + bit;
            ++BitsInCurrentNumber;
            if (BitsInCurrentNumber == CurrentBitsPerNumber)
            {
                AddNumberToData();
                wasAdded = true;
            }
        }
        return wasAdded;
    }

    public void AddNumberToData()
    {
        Data.Add(CurrentNumber);
        CurrentNumber = 0;
        BitsInCurrentNumber = 0;
    }

    private static byte[] GetBitsFromByte(byte bt)
    {
        var bits = new byte[BitsInByte];
        for (var i = BitsInByte - 1; i >= 0; i--)
        {
            bits[i] = (byte)(bt % 2);
            bt >>= 1;
        }
        return bits;
    }

    public void AddLastByte(byte bt)
    {
        var bits = BitsOfLastByte(bt);
        foreach(var bit in bits)
        {
            CurrentNumber = (CurrentNumber << 1) + bit;
            ++BitsInCurrentNumber;
            if (BitsInCurrentNumber == CurrentBitsPerNumber)
            {
                AddNumberToData();
            }
        }
    }

    private byte[] BitsOfLastByte(byte bt)
    {
        var bits = new List<byte>();
        while (bt > 0)
        {
            bits.Add((byte)(bt % 2));
            bt >>= 1;
        }
        while (bits.Count + BitsInCurrentNumber < BitsInByte)
        {
            bits.Add(0);
        }
        bits.Reverse();
        return bits.ToArray();
    }

}