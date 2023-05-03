namespace Stack_LinkedListbased
{
    public class Stack
    {
        LinkedList list;
        public Stack()
        {
            list = new LinkedList();
        }
        public void push(int _data) => list.InsertFirst(_data);

        public int pop()
        {
            if (list.Length==0) return -1;
            int data = list.head.data;
            list.DeleteHead();
            return data;
        }
        public int peek()
        {
            return list.head.data;
        }
        public bool IsEmpty() => list.Length == 0;

        public void Print() => list.PrintList();

        public int Length() => list.Length;
    }
}