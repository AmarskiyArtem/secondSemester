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
        Console.WriteLine(String.Join(" ", data));
    }

}
