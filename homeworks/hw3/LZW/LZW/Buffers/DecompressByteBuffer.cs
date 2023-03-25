namespace LZW.Buffers;

internal class DecompressByteBuffer
{
    public List<int> Data { get; private set; } = new();

    public int CurrentBitsPerNumber { get; set; } = 9;

    public int currentNumber { get; private set; }
    public int bitsInCurrentNumber { get; private set; }

    private const int BitsInByte = 8;


    public bool AddByteToData(byte bt)
    {
        bool wasAdded = false;
        var bits = GetBitsFromByte(bt);
        foreach (var bit in bits)
        {
            currentNumber = (currentNumber << 1) + bit;
            ++bitsInCurrentNumber;
            if (bitsInCurrentNumber == CurrentBitsPerNumber)
            {
                AddNumberToData();
                wasAdded = true;
            }
        }
        return wasAdded;
    }

    public void AddNumberToData()
    {
        Data.Add(currentNumber);
        currentNumber = 0;
        bitsInCurrentNumber = 0;
    }

    private byte[] GetBitsFromByte(byte bt)
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
            currentNumber = (currentNumber << 1) + bit;
            ++bitsInCurrentNumber;
            if (bitsInCurrentNumber == CurrentBitsPerNumber)
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
        while (bits.Count + bitsInCurrentNumber < BitsInByte)
        {
            bits.Add(0);
        }
        bits.Reverse();
        return bits.ToArray();
    }

}