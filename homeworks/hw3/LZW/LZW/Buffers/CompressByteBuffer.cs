namespace LZW.Buffers;

internal class CompressByteBuffer
{
    public List<byte> Data { get; private set; } = new();

    public int CurrentNumberOfBitsPerChar { get; set; } = 9;

    public byte CurrentByte { get; private set; }

    
}
