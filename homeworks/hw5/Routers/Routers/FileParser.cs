namespace Routers;

using System.Text.RegularExpressions;

public static class FileParser
{

    private static bool IsCorrectLine(string line)
        => Regex.IsMatch(line, @"\d+: (\d+ \(\d+\),? ?)+");

    public static LinkedList<(int, LinkedList<(int, int)>)> ParseFile(string path)
    {
        var result = new LinkedList<(int, LinkedList<(int, int)>)>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (!IsCorrectLine(line))
            {
                throw new IncorrectLineException($"{line} does not match the pattern");
            }
        }
        return result;
    }


}
