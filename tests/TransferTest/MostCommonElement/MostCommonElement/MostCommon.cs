namespace MostCommonElement;

public static class MostCommon
{
    public static T GetMostCommonElement<T>(List<T> array) where T : notnull
    {
        if (array.Count == 0)
        {
            throw new ArgumentException("Array cannot be empty");
        }

        var counts = new Dictionary<T, int>();

        foreach (var element in array)
        {
            if (counts.ContainsKey(element))
            {
                counts[element]++;
            }
            else
            {
                counts.Add(element, 1);
            }
        }

        var mostCommonElement = counts.First().Key;
        var maxCount = counts.First().Value;
        foreach (KeyValuePair<T, int> entry in counts)
        {
            if (entry.Value > maxCount)
            {
                mostCommonElement = entry.Key;
                maxCount = entry.Value;
            }
        }

        return mostCommonElement;
    }
}



