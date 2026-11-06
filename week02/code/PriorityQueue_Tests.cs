using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them all.
    // Expected Result: Items are dequeued in order of highest priority (ItemC: 5, ItemA: 3, ItemB: 1).
    // Defect(s) Found: PriorityQueue.Dequeue did not remove items from the internal list upon dequeue, and the loop skipped checking the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 3);
        priorityQueue.Enqueue("ItemB", 1);
        priorityQueue.Enqueue("ItemC", 5);

        Assert.AreEqual("ItemC", priorityQueue.Dequeue());
        Assert.AreEqual("ItemA", priorityQueue.Dequeue());
        Assert.AreEqual("ItemB", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where multiple items share the highest priority.
    // Expected Result: The first item added with the highest priority is dequeued first (FIFO tie-breaker).
    // Defect(s) Found: Dequeue used `>=` instead of `>`, causing the last item with high priority to be selected instead of the first item (LIFO instead of FIFO for ties).
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("Low", 2);
        priorityQueue.Enqueue("SecondHigh", 5);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: None. Exception was handled correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}