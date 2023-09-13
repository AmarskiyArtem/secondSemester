namespace MostCommonElement;

/// <summary>
/// Provides utility methods for finding the most common element in a list.
/// </summary>
public static class MostCommon
{
    /// <summary>
    /// Returns the most common element from a list. In case of multiple equally common elements,
    /// the first one encountered will be returned.
    /// </summary>>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="array">The list of elements to analyze.</param>
    /// <returns>The most common element in the list.</returns>
    /// <exception cref="ArgumentException">Thrown when the input list is empty.</exception>
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



