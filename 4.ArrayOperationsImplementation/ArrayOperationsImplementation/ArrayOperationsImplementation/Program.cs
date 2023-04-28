namespace ArrayOperationsImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,2,3};
            OurArray ourarray = new();
            ourarray.Resize<int>(ref arr, 4);
            Console.WriteLine(String.Join(", ",arr));
        }
    }

    class OurArray
    {
        public void Resize<T>(ref T[] source, int newSize)
        {
            //Validations
            if (newSize <= source.Length) return;
            if(source is null) return;
            if(source.Length == newSize) return;

            //processes
            //create new empty array with new size
            T[] newArray = new T[newSize];
            //move all items from source array to new array
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));
            //assign a new array address to the source array address.
            source = newArray;

        }
    }
}