using System.Collections.Generic;

namespace ByKhaled
{
    public class Dictionary<TKey, TValue> where TKey : class
    {

        private KeyValuePair[] entrise;
        private int _initialSize;
        private int _entriseCount;
        public Dictionary()
        {
            _initialSize = 3;
            entrise = new KeyValuePair[_initialSize];
        }

        public void ResizeOrNot()
        {
            if (_entriseCount < entrise.Length ) return;

            int newSize = entrise.Length + _initialSize;
            Console.WriteLine($"Resize from {entrise.Length} to {newSize}");
            KeyValuePair[] newArray = new KeyValuePair[newSize];
            Array.Copy(entrise, newArray, entrise.Length);
            entrise = newArray;
        }

        public void Set(TKey key, TValue value)
        {
            for (int i =0; i< _entriseCount;i++)
            {
                if (entrise[i] != null && entrise[i].Key == key)
                {
                    entrise[i].Value = value;
                    return;
                }
            }
            ResizeOrNot();
            KeyValuePair keyValuePair = new KeyValuePair(key, value);
            entrise[_entriseCount] = keyValuePair;
            _entriseCount++; 
        }

        public TValue Get(TKey key)
        {
            for (int i = 0; i < _entriseCount; i++)
            {
                if (entrise[i] != null && entrise[i].Key == key)
                {
                    return entrise[i].Value; 
                }
            }
            return default(TValue)!;
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < _entriseCount; i++)
            {
                if (entrise[i] != null && entrise[i].Key == key)
                {
                    entrise[i] = entrise[_entriseCount - 1];
                    entrise[_entriseCount - 1] = null!;
                    _entriseCount--;
                    return true;
                }
            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine($"--------------------\nSize : {_entriseCount}");
            for (int i = 0; i < _entriseCount; i++)
            {
                Console.WriteLine(entrise[i]+",");
            }
        }

        public int Size => _entriseCount;
        class KeyValuePair
        {
            TKey _key;
            TValue _value;
            public KeyValuePair(TKey key, TValue value)
            {
                _key = key;
                _value = value;
            }

            public TKey Key
            {
                get { return _key; }
            }

            public TValue Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public override string ToString()
            {
                return $"{_value}";
            }
        }
    }
}