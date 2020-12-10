namespace QueueDoublyLinkedList
{
    public partial class Queue<T>
    {
        private class Node
        {
            public Node Next { get; set; }
 
            public Node Previous { get; set; }
            public T Value { get; set; }
 
        }
    }
 
}