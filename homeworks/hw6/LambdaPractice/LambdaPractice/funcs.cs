namespace LambdaPractice;

/// <summary>
/// A static class that implements some methods for working with lists 
/// </summary>
public static class Funcs
{
    /// <summary>
    /// Takes a list and a func, returns a list with a func applied to each element
    /// </summary>
    /// <typeparam name="TInput">type of input list params</typeparam>
    /// <typeparam name="TOutput">type of input list params</typeparam>
    public static List<TOutput> Map<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> func)
    {
        var result = new List<TOutput>();
        foreach (var x in list)
        {
            result.Add(func(x));
        }
        return result;
    }

    /// <summary>
    /// Takes a list and a bool func, return list of the elements of original list for which the func() is true
    /// </summary>
    /// <typeparam name="T">Type of list</typeparam>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> func)
    {
        var result = new List<T>();
        foreach (var x in list)
        {
            if (func(x))
            {
                result.Add(x);
            }
        }
        return result;
    }

    /// <summary>
    /// Takes a list, an initial value,
    /// and a func that takes the current accumulated value and the current list item,
    /// and returns the next accumulated value.
    /// </summary>
    /// <typeparam name="TInput">Type of list params</typeparam>
    /// <typeparam name="TOutput">Type of a accumulating value</typeparam>
    /// <returns>Accumulated value obtained after the entire passage of the list</returns>
    public static TOutput Fold<TInput, TOutput>(List<TInput> list, TOutput initialValue, Func<TInput, TOutput, TOutput> func)
    {
        foreach (var x in list)
        {
            initialValue = func(x, initialValue);
        }
        return initialValue;
    }
}
