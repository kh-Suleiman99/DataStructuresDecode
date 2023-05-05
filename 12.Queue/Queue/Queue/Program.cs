using System.Collections.Generic;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Has data? " + queue.HasData());
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Has data? " + queue.HasData());
            queue.Print();
            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.Dequeue());
            queue.Print();
            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.Dequeue());
            queue.Print();
            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.Dequeue());
            queue.Print();
            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.Dequeue());
            queue.Print();
        }
    }
}