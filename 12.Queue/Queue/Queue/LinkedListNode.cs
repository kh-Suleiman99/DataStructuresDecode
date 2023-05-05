namespace Queue
{
    class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T>? next;
        public LinkedListNode(T _data)
        {
            this.data = _data;
            next = null;
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

    class LinkedList<T> where T : IComparable<T> 
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int Length;
        public LinkedList()
        {
            head = null!;
            tail = null!;
            Length = 0;
    }
        
        public void InsertFirst(T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (head is null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            Length++;
        }
        public void DeleteHead()
        {
            if (head is null) return;

            if (head == tail)
            {
                head = null!;
                tail = null!;
            }
            else
            {
                head = head.next!;
            }
            Length--;
        }
        public void InsertLast(T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (head is null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
            Length++;
        }

        public void InsertAfter(T _nodeData, T _newData)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_newData);
            LinkedListNode<T> targetNode = Find(_nodeData);
            if (targetNode is not null)
            {
                newNode.next = targetNode.next;
                targetNode.next = newNode;
                if (tail == targetNode)
                {
                    tail = newNode;
                }
            }
            Length++;
        }

        public void InsertBefore(T _nodeData, T _newData)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_newData);
            LinkedListNode<T> parentNode = FindParent(_nodeData);
            if (parentNode is not null)
            {
                newNode.next = parentNode.next;
                parentNode.next = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            Length++;
        }

        public void DeleteNode(T _nodeData)
        {
            LinkedListNode<T> targetNode = Find(_nodeData);
            if (targetNode is null)
            {
                return;
            }
            if (targetNode == head && targetNode == tail)
            {
                head = null!;
                tail = null!;
            }
            else if (targetNode == head)
            {
                head = head.next!;
            }
            else
            {
                LinkedListNode<T> parentNode = FindParent(_nodeData);
                parentNode.next = targetNode.next;
                if (targetNode == tail)
                {
                    tail = parentNode;
                }
            }
            Length--;
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
                if (itr.data().CompareTo(_data) == 0)
                {
                    return itr.Current();
                }
            }
            return null!;
        }

        public LinkedListNode<T> FindParent(T _data)
        {
            LinkedListIterator<T> itr = new LinkedListIterator<T>(this.head);
            for (; itr.Current().next is not null; itr.Next())
            {
                if (itr.Current().next!.data.CompareTo(_data) == 0)
                {
                    return itr.Current();
                }
            }
            return null!;
        }
    }
}