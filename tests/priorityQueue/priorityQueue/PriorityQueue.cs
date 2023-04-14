using priorityQueue;
using System.Diagnostics;

namespace PriorityQueueLibrary;

/// <summary>
/// Priority queue implementation with O(1) for insert and O(n) for get value with max priority
/// </summary>
/// <typeparam name="T">Type of objects in Queue</typeparam>
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

    /// <summary>
    /// Insert value with priority to queue
    /// </summary>
    public void Enqueue(T value, int priority)
    {
        var newNode = new Node(value, priority, tail);
        tail = newNode;
    }

    /// <summary>
    /// Returns if queue is empty
    /// </summary>
    public bool Empty { get => tail == null; }

    private void DeleteNode(Node node)
    {
        if (tail == node)
        {
            tail = tail.Next;
            return;
        }
        var currentNode = tail ?? throw new ArgumentNullException();
        while (currentNode.Next != node)
        {
            currentNode = currentNode.Next;
            if (currentNode == null)
            {
                throw new ArgumentNullException();
            }
        }
        currentNode.Next = node.Next;
    }

    /// <summary>
    /// Returns the value with highest priority
    /// </summary>
    /// <exception cref="PriorityQueueIsEmptyException"></exception>
    public T Dequeue()
    {
        if (Empty)
        {
            throw new PriorityQueueIsEmptyException();
        }
        var nodeWithMaxPriority = tail;
        if (tail == null)
        {
            throw new ArgumentNullException();
        }
        var currentNode = tail.Next;
        while (currentNode != null)
        {
            if (nodeWithMaxPriority == null)
            {
                throw new ArgumentNullException();
            }
            if (currentNode.Priority >= nodeWithMaxPriority.Priority)
            {
                nodeWithMaxPriority = currentNode;
            }
            currentNode = currentNode.Next;
        }
        if (nodeWithMaxPriority == null)
        {
            throw new ArgumentNullException();
        }
        var value = nodeWithMaxPriority.Value;
        DeleteNode(nodeWithMaxPriority);
        return value;
    }
}
