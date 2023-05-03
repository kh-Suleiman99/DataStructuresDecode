namespace Stack_Arraybased
{
    public class Stack<T>
    {
        private T[] list;
        private int _topIndex;
        private int _initSize;
        private int _currentSize;

        public Stack()
        {
            _initSize = 5;
            _currentSize = _initSize;
            list = new T[_initSize];
            _topIndex = -1;
        }
        public void push(T _data)
        {
            ResizeOrNot();
            list[++_topIndex] = _data;
        }
        public T pop()
        {
            if (_topIndex == -1) return default(T)!;
            T data = list[_topIndex--];
            return data;
        }
        public T peek()
        {
            if (_topIndex == -1) return default(T)!;
            return list[_topIndex];
        }
        public bool IsEmpty() => _topIndex == -1;

        public void Print() 
        {
            for (int i = _topIndex; i>=0;i--)
            {
                Console.Write($"{list[i]}-> ");
            }
            Console.WriteLine();
        }

        public int Length() => _topIndex + 1;

        public void ResizeOrNot()
        {
            if (_topIndex < _currentSize - 1) return;
            Console.WriteLine("Resize");
            T[] newArray = new T[_currentSize + _initSize];
            Buffer.BlockCopy(list, 0, newArray, 0, Buffer.ByteLength(list));
            list = newArray;
            _currentSize += _initSize;
        }
    }
}