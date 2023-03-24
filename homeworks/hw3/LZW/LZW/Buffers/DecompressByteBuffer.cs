namespace LZW.Buffers;

internal class DecompressByteBuffer
{
    public List<int> Data { get; private set; } = new();

    public int BitsPerNumber { get; set; } = 9;

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
            if (bitsInCurrentNumber == BitsPerNumber)
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
            if (bitsInCurrentNumber == BitsPerNumber)
            {
                AddNumberToData();
            }
        }
    }

    private byte[] BitsOfLastByte(byte oneByte)
    {
        var bites = new List<byte>();
        while (oneByte > 0)
        {
            bites.Add((byte)(oneByte % 2));
            oneByte >>= 1;
        }

        while (bites.Count + bitsInCurrentNumber < BitsInByte)
        {
            bites.Add(0);
        }

        bites.Reverse();
        return bites.ToArray();
    }

}