using System.Collections.Generic;

namespace Queue
{
    class Queue<T> where T : IComparable<T>
    {
        private LinkedList<T> linkedlist;
        public Queue()
        {
            linkedlist = new LinkedList<T>();
        }
        public void Enqueue(T _data)
        {
            linkedlist.InsertLast(_data);
        }
        public T Dequeue()
        {
            T data = linkedlist.head.data;
            linkedlist.DeleteHead();
            return data;
        }

        public T peek()
        {
            if (linkedlist.head == null) return default(T)!;
            return linkedlist.head.data;
        }

        public bool HasData()
        {
            return linkedlist.Length != 0;
        }

        public int Size()
        {
            return linkedlist.Length;
        }

        public void Print() 
        {
            linkedlist.PrintList();
        }

    }
}