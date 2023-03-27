namespace InsertionSortTests;

public class Tests
{
    private static bool IsSorted(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    [Test]
    public void CommonArraysShouldRightSorting()
    {
        int[] testArrayOne = { 1, 2, 3, 4 };
        int[] testArrayTwo = { 4, 3, 2, 1 };
        int[] testArrayThree = { 5, 6, 4, 3, 10, 2, 7 };
        var testArrays = new[] { testArrayOne, testArrayTwo, testArrayThree };
        for (var i = 0; i < testArrays.Length; ++i)
        {
            InsertSort.InsertionSort(testArrays[i]);
            Assert.IsTrue(IsSorted(testArrays[i]));
        }
    }

    [Test]
    public void EmptyArrayShouldNoException()
    {
        InsertSort.InsertionSort(new int[] { });
    }

    [Test]
    public void ArrayWithSimularValuesShouldNothingChange()
    {
        var testArray = new[] { 1, 1, 1, 1, 1, 1 };
        InsertSort.InsertionSort(testArray);
        for (var i = 0; i < 6; ++i)
        {
            Assert.IsTrue(testArray[i] == 1);
        }
        Assert.IsTrue(testArray.Length == 6);
    }
}