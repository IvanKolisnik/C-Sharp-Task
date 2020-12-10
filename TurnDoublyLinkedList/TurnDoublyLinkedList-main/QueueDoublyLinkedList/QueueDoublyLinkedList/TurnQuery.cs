using System;

namespace QueueDoublyLinkedList
{
    public partial class Queue<T> : IQueue<T>
    {
        private Node _head;
        private Node _tail;
 
        public int Count { get; private set; }
 
        public void Clear()
        {
            _head = _tail = null;
            Count = 0;
        }
 
        public T Dequeue()
        {
            T item = Peek();
            _head = _head.Next;
            if (_head == null)
                _tail = null;
            else
                _head.Previous = null;
            Count--;
            return item;
        }
 
        public void Enqueue(T item)
        {
            Node tail = new Node() { Previous = _tail, Value = item };
            if (_tail == null)
                _head = tail;
            else
                _tail.Next = tail;
 
            _tail = tail;
            Count++;
        }
 
        public T Peek()
            => (_head ?? throw new InvalidOperationException()).Value;
 
 
        public bool TryDequeue(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
 
            result = Dequeue();
            return true;
        }
 
        public bool TryPeek(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
 
            result = Peek();
            return true;
        }
    }
}