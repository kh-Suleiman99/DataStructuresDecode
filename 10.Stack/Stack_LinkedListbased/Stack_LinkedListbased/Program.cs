namespace Stack_LinkedListbased
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.push(1);
            s.push(2);
            s.push(3);
            s.push(4);
            s.push(5);
            s.Print();
            int data = s.peek();
            Console.WriteLine(data);
            s.Print();
            data = s.pop();
            Console.WriteLine(data);
            s.Print();
            data = s.pop();
            Console.WriteLine(data);
            s.Print();
            data = s.pop();
            Console.WriteLine(data);
            s.Print();
            data = s.pop();
            Console.WriteLine(data);
            s.Print();
            Console.WriteLine(s.Length());
            data = s.pop();
            Console.WriteLine(data);
            Console.WriteLine(s.Length());
        }
    }

    
}