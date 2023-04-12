namespace LambdaPractice;

public static class Funcs
{
    public static List<TOutput> Map<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> func)
    {
        var result = new List<TOutput>();
        foreach (var x in list)
        {
            result.Add(func(x));
        }
        return result;
    }

    public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var x in list)
        {
            if (predicate(x))
            {
                result.Add(x);
            }
        }
        return result;
    }

    public static TOutput Fold<TInput, TOutput>(List<TInput> list, TOutput initialValue, Func<TInput, TOutput, TOutput> func)
    {
        foreach (var x in list)
        {
            initialValue = func(x, initialValue);
        }
        return initialValue;
    }
}
