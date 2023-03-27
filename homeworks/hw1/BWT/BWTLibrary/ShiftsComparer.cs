namespace BWTLibrary;

internal class ShiftsComparer : IComparer<int>
{
    public ShiftsComparer(string data)
    {
        this.data = data;
    }

    private string data;

    int IComparer<int>.Compare(int firstElementStartIndex, int secondElementStartIndex)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[(firstElementStartIndex + i) % data.Length] > data[(secondElementStartIndex + i) % data.Length])
            {
                return 1;
            }
            if (data[(firstElementStartIndex + i) % data.Length] < data[(secondElementStartIndex + i) % data.Length])
            {
                return -1;
            }
        }
        return 0;
    }
}
