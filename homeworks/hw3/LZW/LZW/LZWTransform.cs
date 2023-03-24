namespace LZW;

public static class LZWTransform
{
    public static void Compress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var data = File.ReadAllBytes(path);
        var compressedData = LZWEncoder.Encode(data);
        var newPath = path + ".zipped";
        File.Create(newPath).Close();
        File.WriteAllBytes(newPath, compressedData);
        Console.WriteLine((double)compressedData.Length/data.Length);
    }

    public static void Decompress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var compressedData = File.ReadAllBytes(path);
        var data = LZWDecoder.Decode(compressedData);
        var newPath = path[0..(path.Length - 6)];
        File.Create(newPath).Close();
        File.WriteAllBytes(newPath, data);
    }
}
