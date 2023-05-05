using ByKhaled;

namespace DictionaryImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ByKhaled.Dictionary<string, string> dictionary = new ByKhaled.Dictionary<string, string>();
            dictionary.Print();
            dictionary.Set("Sinar", "sinar@gmail.com");
            dictionary.Set("Elvis", "elvis@gmail.com");
            dictionary.Print();
            dictionary.Set("Tane", "tane@gmail.com");
            dictionary.Set("Gerti", "gerti@gmail.com");
            dictionary.Set("Arist", "arist@gmail.com");
            dictionary.Print();
            Console.WriteLine("-----------\n" + dictionary.Get("Tane"));
            Console.WriteLine("-----------\n" + dictionary.Get("Arist"));
            Console.WriteLine("-----------\n" + dictionary.Get("Arist2"));
            dictionary.Remove("Elvis");
            dictionary.Print();
            dictionary.Remove("Sinar");
            dictionary.Print();
            dictionary.Remove("Tane");
            dictionary.Print();
            dictionary.Remove("Gerti");
            dictionary.Print();
            dictionary.Remove("Arist");
            dictionary.Print();
            dictionary.Set("Arist", "arist@gmail.com");
            dictionary.Print();
            dictionary.Set("Arist", "arist20@gmail.com");
            dictionary.Print();

        }
    }
}
