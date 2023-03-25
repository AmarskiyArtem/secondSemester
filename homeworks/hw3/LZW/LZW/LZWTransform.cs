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
        //var compressedDataWithoutBWT = LZWEncoder.Encode(data, false);
        var compressedData = LZWEncoder.Encode(data, true);
        var newPath = path + ".zipped";
        //File.Create(newPath).Close();
        File.WriteAllBytes(newPath, compressedData);
        //Console.WriteLine((double)compressedData.Length/data.Length);
    }

    public static void Decompress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var compressedData = File.ReadAllBytes(path);
        var data = LZWDecoder.Decode(compressedData);
        File.WriteAllBytes(path[0..(^6)], data);
    }
}
