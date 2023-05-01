using System.Collections.Generic;

namespace DoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //linkedList test
            //LinkedList<int> linkedList = new LinkedList<int>();
            //linkedList.InsertLast(1);
            //linkedList.InsertLast(2);
            //linkedList.InsertLast(3);
            //linkedList.InsertLast(4);
            //linkedList.InsertLast(5);
            //linkedList.InsertLast(6);
            //linkedList.InsertLast(7);
            //linkedList.PrintList();
            //linkedList.InsertAfter(7,55);
            //linkedList.PrintList();
            //linkedList.DeleteNode(4);
            //linkedList.PrintList();
            //linkedList.DeleteNode(55);
            //linkedList.PrintList();
            //linkedList.DeleteNode(7);
            //linkedList.PrintList();
            //linkedList.InsertBefore(1, 7);
            //linkedList.PrintList();
            //linkedList.InsertBefore(5, 55);
            //linkedList.PrintList();
            //linkedList.InsertBefore(55,10);
            //linkedList.PrintList();
            //linkedList.InsertBefore(10, 9);
            //linkedList.PrintList();
            //linkedList.DeleteNode(9);
            //linkedList.PrintList();
            //Console.WriteLine(linkedList.head +"-" + linkedList.tail);


            //generic test 
            LinkedList<char> linkedList = new LinkedList<char>();
            linkedList.InsertLast('a');
            linkedList.InsertLast('b');
            linkedList.InsertLast('c');
            linkedList.InsertLast('d');
            linkedList.InsertLast('e');
            linkedList.InsertLast('f');
            linkedList.InsertLast('g');
            linkedList.PrintList();
            linkedList.InsertBefore('d', 'w');
            linkedList.PrintList();
            linkedList.InsertBefore('g', 'x');
            linkedList.PrintList();
            linkedList.InsertBefore('a', 'y');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.DeleteNode('y');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.DeleteNode('g');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.DeleteNode('w');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.InsertAfter('a', 'n');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.InsertAfter('x', 'j');
            linkedList.PrintList();
            Console.WriteLine("length: " + linkedList.length);
            linkedList.InsertAfter('e', 'z');
            linkedList.PrintList();
            Console.WriteLine(linkedList.head + "-" + linkedList.tail);
            Console.WriteLine("length: " + linkedList.length);

            //coping test 
            LinkedList<char> linkedListcopy = new LinkedList<char>();
            linkedListcopy = linkedList.GetCopy();
            Console.WriteLine("******************\ncopy linked List ");
            linkedListcopy.PrintList();
            linkedListcopy.InsertLast('t');
            linkedListcopy.PrintList();
            linkedListcopy.DeleteNode('e');
            linkedListcopy.PrintList();
            Console.WriteLine("******************\noriginal linked List ");
            linkedList.PrintList();

        }
    }

    class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T>? next;
        public LinkedListNode<T>? back;
        public LinkedListNode(T _data)
        {
            this.data = _data;
            next = null;
            back = null;
        }

        public override string ToString()
        {
            return $"{data}";
        }
    }

    class LinkedListIterator<T>
    {
        private LinkedListNode<T> currentNode;
        public LinkedListIterator(LinkedListNode<T> node)
        {
            currentNode = node;
        }
        public T data() => currentNode.data;
        public LinkedListNode<T> Current() => this.currentNode;

        public void Next() => this.currentNode = this.currentNode.next!;
    }

    class LinkedList<T>  where T : IComparable
    {
        public LinkedListNode<T> head = null!;
        public LinkedListNode<T> tail = null!;
        public int length = 0;
        public void InsertLast(T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.back = tail;
                tail = newNode;
            }
            length++;
        }

        public void InsertAfter(T _nodeData, T _newData)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_newData);
            LinkedListNode<T> targetNode = Find(_nodeData);
            newNode.next = targetNode.next;
            newNode.back= targetNode;
            if (targetNode.next == null)
            {
                tail = newNode;
            }
            else
            {
                targetNode.next.back = newNode;
            }
            targetNode.next = newNode;
            length++;
        }

        public void InsertBefore(T _nodeData, T _newData)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_newData);
            LinkedListNode<T> targetNode = Find(_nodeData);
            newNode.next = targetNode;
            if (targetNode == head)
            {
                head = newNode;
            }
            else
            {
                targetNode.back!.next = newNode;
                newNode.back = targetNode.back;
            }
            targetNode.back = newNode;
            length++;
        }

        public void DeleteNode(T _nodeData)
        {
            LinkedListNode<T> targetNode = Find(_nodeData);
            if (targetNode == head && targetNode == tail)
            {
                head = null!;
                tail = null!;
            }
            else if (targetNode == head)
            {
                head = targetNode.next!;
                targetNode.next!.back = null;
            }
            else if (targetNode == tail)
            {
                tail = targetNode.back!;
                targetNode.back!.next = null!;
            }
            else
            {
                targetNode.back!.next = targetNode.next;
                targetNode.next!.back = targetNode.back;
            }
            length--;
        }

        public LinkedList<T> GetCopy()
        {
            LinkedList<T> copy = new LinkedList<T>();
            LinkedListIterator<T> itr = new LinkedListIterator<T>(this.head);
            for (; itr.Current() is not null; itr.Next())
            {
                copy.InsertLast(itr.data());
            }
            return copy;
        }

        public void PrintList()
        {
            LinkedListIterator<T> itr = new LinkedListIterator<T>(this.head);
            for (; itr.Current() is not null; itr.Next())
            {
                Console.Write(itr.Current().ToString() + " " + "-> ");
            }
            Console.WriteLine("\n");
        }


        public LinkedListNode<T> Find(T _data)
        {
            LinkedListIterator<T> itr = new LinkedListIterator<T>(this.head);
            for (; itr.Current() is not null; itr.Next())
            {
                if (_data.CompareTo(itr.data())==0)
                {
                    return itr.Current();
                }
            }
            return null!;
        }

    }
}
