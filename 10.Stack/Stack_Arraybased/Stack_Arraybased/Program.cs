using System.Collections.Generic;

namespace Stack_Arraybased
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Length: " + stack.Length());
            Console.WriteLine("Is empty?" + stack.IsEmpty());
            stack.push('a');
            stack.push('b');
            stack.push('c');
            stack.push('d');
            stack.push('e');
            Console.WriteLine("Is empty?"+ stack.IsEmpty());
            Console.WriteLine("Length: " + stack.Length());
            stack.Print();
            stack.push('f');
            stack.Print();
            Console.WriteLine(stack.pop());
            stack.Print();
            Console.WriteLine(stack.pop());
            stack.Print();
            Console.WriteLine(stack.pop());
            stack.Print();
            Console.WriteLine(stack.pop());
            stack.Print();
            Console.WriteLine(stack.pop());
            stack.Print();
            Console.WriteLine(stack.pop());
            Console.WriteLine("Is empty?" + stack.IsEmpty());
            Console.WriteLine("Length: "+stack.Length());
        }
    }
}