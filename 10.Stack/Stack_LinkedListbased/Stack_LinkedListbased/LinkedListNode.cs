namespace Stack_LinkedListbased
{
    class LinkedListNode
    {
        public int data;
        public LinkedListNode? next;
        public LinkedListNode(int _data)
        {
            this.data = _data;
            next = null;
        }

        public override string ToString()
        {
            return $"{data}";
        }
    }
    class LinkedListIterator
    {
        private LinkedListNode currentNode;
        public LinkedListIterator(LinkedListNode node)
        {
            currentNode = node;
        }
        public int data() => currentNode.data;
        public LinkedListNode Current() => this.currentNode;

        public void Next() => this.currentNode = this.currentNode.next!;
    }

    class LinkedList
    {
        public LinkedListNode head = null!;
        public LinkedListNode tail = null!;
        public int Length = 0;
        public void InsertFirst(int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
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
        public void InsertLast(int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
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

        public void InsertAfter(int _nodeData, int _newData)
        {
            LinkedListNode newNode = new LinkedListNode(_newData);
            LinkedListNode targetNode = Find(_nodeData);
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

        public void InsertBefore(int _nodeData, int _newData)
        {
            LinkedListNode newNode = new LinkedListNode(_newData);
            LinkedListNode parentNode = FindParent(_nodeData);
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

        public void DeleteNode(int _nodeData)
        {
            LinkedListNode targetNode = Find(_nodeData);
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
                LinkedListNode parentNode = FindParent(_nodeData);
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
            LinkedListIterator itr = new LinkedListIterator(this.head);
            for (; itr.Current() is not null; itr.Next())
            {
                Console.Write(itr.Current().ToString() + " " + "-> ");
            }
            Console.WriteLine("\n");
        }


        public LinkedListNode Find(int _data)
        {
            LinkedListIterator itr = new LinkedListIterator(this.head);
            for (; itr.Current() is not null; itr.Next())
            {
                if (itr.data() == _data)
                {
                    return itr.Current();
                }
            }
            return null!;
        }

        public LinkedListNode FindParent(int _data)
        {
            LinkedListIterator itr = new LinkedListIterator(this.head);
            for (; itr.Current().next is not null; itr.Next())
            {
                if (itr.Current().next!.data == _data)
                {
                    return itr.Current();
                }
            }
            return null!;
        }
    }
}