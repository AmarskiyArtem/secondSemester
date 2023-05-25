namespace SkipListLibrary;

using System.Collections;

public class SkipList<T> : IList<T>
    where T : IComparable
{
    static readonly double newLevelChance = 0.5;
    static readonly int maxLevel = 24;
    static readonly Random random = new();

    internal int version = 0;
    internal Node head = new(default, maxLevel);
    private int currentMaxLevel = 0;

    internal class Node
    {
        public Node(T? value, int level)
        {
            Value = value;
            Next = new Node[level];
        }
        public T? Value { get; } 
        public Node[] Next { get; set; }
    }
    

    public T this[int index] 
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var currentNode = head;
            for (var i = 0; i <= index; ++i)
            {
                currentNode = currentNode.Next[0];
            }
            if (currentNode.Value is null)
            {
                throw new InvalidOperationException();
            }
            return currentNode.Value;
        }
        set => throw new NotSupportedException("//TODO");
    }

    public int Count { get; private set; }


    bool ICollection<T>.IsReadOnly => false;

    public void Add(T value)
    {
        var newNodeLevel = RandomLevel();
        var newNode = new Node(value, newNodeLevel);
        var currentNode = head;
        for (var level = currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                currentNode = currentNode.Next[level];
            }
            if (level < newNodeLevel)
            {
                newNode.Next[level] = currentNode.Next[level];
                currentNode.Next[level] = newNode;
            }
        }
        Count++;
        version++;
    }

    public void Clear()
    {
        currentMaxLevel = 1;

        head = new(default, maxLevel);
        version++;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var currentNode = head;
        for (var level = currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (item.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                if (item.CompareTo(currentNode.Next[level].Value) == 0)
                {
                    return true;
                }

                currentNode = currentNode.Next[level];
            }
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || array.Length < Count - arrayIndex)
        {
            throw new ArgumentOutOfRangeException();
        }

        var currentNode = head;
        for (var i = 0; i < arrayIndex; ++i)
        {
            currentNode = currentNode.Next[0];
        }

        for (var i = 0; i < array.Length; ++i)
        {
            array[i] = currentNode.Next[0].Value!;
            currentNode = currentNode.Next[0];
        }
    }

    public int IndexOf(T value)
    {
        var counter = 0;
        var currentNode = head;
        while (currentNode.Next[0] != null)
        {
            if (value.CompareTo(currentNode.Next[0].Value) == 0)
            {
                return counter;
            }
            counter++;
            currentNode = currentNode.Next[0];
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException("//TODO");
    }

    public bool Remove(T value)
    {
        var success = false;
        var currentNode = head;
        for (var level = currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                if (value.CompareTo(currentNode.Next[level].Value) == 0)
                {
                    currentNode.Next[level] = currentNode.Next[level].Next[level];
                    success = true;
                    break;
                }
                currentNode = currentNode.Next[level];
            }
        }
        if (success)
        {
            Count--;
        }
        version++;
        return success;
    }

    public void RemoveAt(int index)
        => Remove(this[index]);

    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        private readonly int version;
        SkipList<T> skipList;
        Node currentNode;
        T? currentValue;

        internal Enumerator(SkipList<T> skipList)
        {
            this.skipList = skipList;
            currentNode = skipList.head;
            version = skipList.version;
            currentValue = default;
        }

        public T Current => currentValue!;

        object? IEnumerator.Current
        {
            get
            {
                if (currentNode.Next == null)
                {
                    throw new InvalidOperationException();
                }
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (version != skipList.version)
            {
                throw new InvalidOperationException();
            }
            if (currentNode.Next[0] == null)
            {
                currentNode = skipList.head;
                currentValue = default;
                return false;
            }

            currentNode = currentNode.Next[0];
            currentValue = currentNode.Value;
            return true;
        }

        public void Reset()
        {
            if (version != skipList.version)
            {
                throw new InvalidOperationException();
            }

            currentNode = skipList.head;
            currentValue = default;
        }
    }

    private int RandomLevel()
    {
        var resultLevel = 1;
        while (random.NextDouble() < newLevelChance && resultLevel < maxLevel)
        {
            resultLevel++;
        }
        currentMaxLevel = Math.Max(currentMaxLevel, resultLevel);
        return resultLevel;
    }

    public Enumerator GetEnumerator()
        => new(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();

}