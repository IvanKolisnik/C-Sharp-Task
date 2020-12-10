namespace QueueDoublyLinkedList
{
    public interface IQueue<T>
    {
        void Clear();
        T Peek();
        T Dequeue();
        void Enqueue(T item);
        bool TryPeek(out T result);
        bool TryDequeue(out T result);
        int Count { get; }
    }
 
}