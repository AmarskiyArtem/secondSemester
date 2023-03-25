namespace LZW;

/// <summary>
/// Class for LZW (with BWT) transform, works with path to files
/// </summary>
public static class LZWTransform
{
    /// <summary>
    /// Takes path to file and creates path.zipped files in same directory
    /// </summary>
    /// <param name="path">path to file</param>
    /// <returns>compressionRatioWithBWT and compressionRatioWithoutBWT</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static (double compressionRatioWithBWT, double compressionRatioWithoutBWT) Compress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var data = File.ReadAllBytes(path);
        var compressedDataWithBWT = LZWEncoder.Encode(data, true);
        var compressedDataWithoutBWT = LZWEncoder.Encode(data, false);
        File.WriteAllBytes(path + ".zipped", compressedDataWithBWT);
        return ((double)compressedDataWithBWT.Length / data.Length, (double)compressedDataWithoutBWT.Length / data.Length);
    }

    /// <summary>
    /// Takes path to compressed files, creates decompressed files in same directory
    /// </summary>
    /// <param name="path">path to file</param>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ArgumentException">if file with not supported format</exception>
    public static void Decompress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        if (!path.EndsWith(".zipped"))
        {
            throw new ArgumentException("Not supported format");
        }
        var compressedData = File.ReadAllBytes(path);
        var data = LZWDecoder.Decode(compressedData);
        File.WriteAllBytes(path[0..(^6)], data);
    }
}
