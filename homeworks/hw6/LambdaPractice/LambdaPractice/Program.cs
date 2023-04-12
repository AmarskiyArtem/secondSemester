
using LambdaPractice;

var a = new List<int>()
{
    1, 2, 3
};

Console.WriteLine(Funcs.Fold<int, int>(a, 0, (x, acc) => x + acc)); 
