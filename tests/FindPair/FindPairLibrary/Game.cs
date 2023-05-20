namespace FindPairLibrary;
public class Game
{
    private class Button
    {
        public bool IsPressed { get; set; }
        public int Value { get; set; }

    }

    public Game(int size)
    {
        if (size % 2 != 0)
        {
            throw new ArgumentException();
        }
        var numbers = new List<int>();
        for (int i = 0; i < size * size / 2; i++)
        {
            numbers.Add(i);
            numbers.Add(i);
        }
        var buttons = new Button[size, size];
        var rng = new Random();
        for (var i = 0; i < size; ++i)
        {
            for (var j = 0; j < size; ++j)
            {
                buttons[i, j] = new Button() { IsPressed = false, Value = numbers[rng.Next((size*size)%numbers.Count)] };
                numbers.Remove(buttons[i, j].Value);
            }
        }
    }


}
