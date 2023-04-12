namespace LambdaPractice;

internal class Funcs <T>
{
    public static List<T> Map(List<T> list, Func<T, T> func)
    {
        var result = new List<T>();
        foreach (var x in list)
        {
            result.Add(func(x));
        }
        return result;
    }
}
