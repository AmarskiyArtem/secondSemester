namespace Routers;

using System.Text.RegularExpressions;

internal static class FileParser
{

    private static bool isCorrectLine(string line)
        => Regex.IsMatch(line, @"\d+: (\d+ \(\d+\),? ?)+");

    public static LinkedList<(int, LinkedList<(int, int)>)> ParseFile(string path)
    {
        var result = new LinkedList<(int, LinkedList<(int, int)>)>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (!isCorrectLine(line))
            {
                throw;
            }
        }
        return result;
    }


}
