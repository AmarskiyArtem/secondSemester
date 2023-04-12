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
}
