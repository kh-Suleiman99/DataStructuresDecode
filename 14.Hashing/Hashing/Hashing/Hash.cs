using System.Text;

namespace Hashing
{
    public class Hash
    {
        public uint Hash32(string str)
        {
            //This offcet Basis give us hash with 32 bit
            uint offcetBasis = 2166136261;
            uint FNVPrime = 16777619;
            //transform data to Bytes
            byte[] data = Encoding.ASCII.GetBytes(str);

            uint hash = offcetBasis;
            foreach(byte b in data)
            {
                hash ^= b;
                hash *= FNVPrime;
            }
            Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
            return hash;

        }

        public ulong Hash64(string str)
        {
            //This offcet Basis give us hash with 64 bit
            ulong offcetBasis = 14695981039346656037;
            ulong FNVPrime = 1099511628211;
            //transform data to Bytes
            byte[] data = Encoding.ASCII.GetBytes(str);

            ulong hash = offcetBasis;
            foreach (byte b in data)
            {
                hash ^= b;
                hash *= FNVPrime;
            }
            Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
            return hash;

        }
    }
}