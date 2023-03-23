namespace LZW;

using TrieLibrary;

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

}
