using priorityQueue;

namespace PriorityQueueLibrary.Tests;

public class PriorityQueueTests
{
    [Test]
    public void EmptyFromEmptyQueueShouldTrue()
    {
        var queue = new PriorityQueue<int>();
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void EmptyFromNotEmptyQueueShouldFalse()
    {
        var queue = new PriorityQueue<string>();
        queue.Enqueue("aaa", 4);
        Assert.IsFalse(queue.Empty);
    }

    [Test]
    public void DequeueFromEmptyQueueShouldException()
    {
        var queue = new PriorityQueue<string>();
        Assert.Throws<PriorityQueueIsEmptyException>(() => queue.Dequeue());
    }

    [Test]
    public void SomeEnqueueShouldRightDequeue()
    {
        var queue = new PriorityQueue<int>();
        queue.Enqueue(1, 10);
        queue.Enqueue(2, 11);
        queue.Enqueue(3, 15);
        queue.Enqueue(4, 8);
        Assert.That(queue.Dequeue(), Is.EqualTo(3));
        Assert.That(queue.Dequeue(), Is.EqualTo(2));
    }

    [Test]
    public void DequeueFromHeadShouldNotFall()
    {
        var queue = new PriorityQueue<string>();
        queue.Enqueue("a", 20);
        queue.Enqueue("2", 16);
        queue.Enqueue("3", 15);
        Assert.That(queue.Dequeue(), Is.EqualTo("a"));
        Assert.That(queue.Dequeue(), Is.EqualTo("2"));
        Assert.IsFalse(queue.Empty);
    }

    [Test]
    public void DequeueFromTailShouldNotFall()
    {
        var queue = new PriorityQueue<string>();
        queue.Enqueue("3", 11);
        queue.Enqueue("2", 16);
        queue.Enqueue("a", 20);
        Assert.That(queue.Dequeue(), Is.EqualTo("a"));
        Assert.That(queue.Dequeue(), Is.EqualTo("2"));
        Assert.IsFalse(queue.Empty);
    }

    public void DequeueWithSamePriorityShouldRightOrder()
    {
        var queue = new PriorityQueue<int>();
        queue.Enqueue(1, 14);
        queue.Enqueue(2, 11);
        queue.Enqueue(3, 15);
        queue.Enqueue(4, 14);
        queue.Enqueue(6, 14);
        queue.Dequeue();
        Assert.That(queue.Dequeue(), Is.EqualTo(14));
        Assert.That(queue.Dequeue(), Is.EqualTo(4));
    }

}
