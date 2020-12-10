using System;


namespace QueueDoublyLinkedList
{
     class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(9);
            queue.Enqueue(7);

            while (queue.TryDequeue(out var num))
            {
                Console.WriteLine(num);
            }
        }
    }
}