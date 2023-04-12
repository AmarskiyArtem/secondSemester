
using LambdaPractice;

var lst  = new List<int>() 
{
    0, 1, 2, 3, 4, 5,
};

lst = Funcs<int>.Map(lst, x => x * 2);
lst.Clear();