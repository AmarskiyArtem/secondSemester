using priorityQueue;

namespace PriorityQueueLibrary;

public class PriorityQueue<T>
{
    private class Node
    {
        public Node(T value, int priority, Node? next)
        {
            Value = value;
            Priority = priority;
            Next = next;
        }

        public Node? Next { get; set; }
        public T Value { get; }
        public int Priority { get; }
    }

    private Node? tail;
    public void Enqueue(T value, int priority)
    {
        var newNode = new Node(value, priority, tail);
        tail = newNode;
    }

    public bool Empty { get {  return tail == null; } }

    private void DeleteNode(Node node)
    {
        if (tail == node)
        {
            tail = tail.Next;
            return;
        }
        var currentNode = tail;
        while (currentNode.Next != node)
        {
            currentNode = currentNode.Next;
        }
        currentNode.Next = node.Next;
    }

    public T Dequeue()
    {
        if (Empty)
        {
            throw new PriorityQueueIsEmptyException();
        }
        var nodeWithMaxPriority = tail;
        var currentNode = tail.Next;
        while (currentNode != null)
        {
            if (currentNode.Priority >= nodeWithMaxPriority.Priority)
            {
                nodeWithMaxPriority = currentNode;
            }
            currentNode = currentNode.Next;
        }
        var value = nodeWithMaxPriority.Value;
        DeleteNode(nodeWithMaxPriority);
        return value;
    }
}
