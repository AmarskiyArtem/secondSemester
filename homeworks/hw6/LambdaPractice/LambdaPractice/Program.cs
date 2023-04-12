
using LambdaPractice;

var a = new List<int>()
{
    1, 2, 3, 4, 5, 6
};

a = Funcs.Filter<int>(a, x => x % 2 == 0);
a.Capacity = 2;
