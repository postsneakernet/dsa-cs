using DataStructures.Lists;
using System;

namespace DataStructures.Maps
{
    public class HashTable<T>
    {
        private ulong _buckets = 16;
        private int _size;
        private int _occupied;
        private LinkedList<KeyValue<T>>[] _table;

        public int Size { get { return _size; } }
        public float Load { get { return (float)_occupied / _buckets; } }

        public HashTable()
        {
            _table = new LinkedList<KeyValue<T>>[_buckets];
            _size = 0;
        }

        public T Get(string key)
        {
            int index = GenerateHash(key);
            LinkedList<KeyValue<T>> bucket = _table[index];

            if (bucket != null)
            {
                Console.WriteLine("Get: bucket exists at {0}", index);
                foreach (KeyValue<T> item in bucket)
                {
                    if (item.Key == key)
                    {
                        Console.WriteLine("Get: key {0} exists", key);
                        return item.Value;
                    }
                }
            } else
            {
                Console.WriteLine("Get: bucket does not exists at {0}", index);
            }

            Console.WriteLine("Get: key {0} does not exist", key);
            return default(T);
        }

        public void Put(string key, T value)
        {
            KeyValue<T> kv = new KeyValue<T>(key, value);

            int index = GenerateHash(key);
            LinkedList<KeyValue<T>> bucket = _table[index];

            if (bucket == null)
            {
                Console.WriteLine("Put: Creating new bucket at {0}", index);
                bucket = new LinkedList<KeyValue<T>>();
                bucket.Add(kv);
                _table[index] = bucket;
                ++_size;
                ++_occupied;
            } else
            {
                Console.WriteLine("Put: Bucket exists at {0}", index);
                int count = 0;
                foreach (KeyValue<T> item in bucket)
                {
                    if (item.Key == key)
                    {
                        Console.WriteLine("Put: Key already present, updating {0}", key);
                        bucket.AddAt(count, kv);
                        break;
                    }

                    ++count;
                }

                bucket.Add(kv);
                ++_size;
            }

            // check Load
        }

        public bool Remove(string key)
        {
            int index = GenerateHash(key);
            LinkedList<KeyValue<T>> bucket = _table[index];

            if (bucket != null)
            {
                int count = 0;
                foreach (KeyValue<T> item in bucket)
                {
                    if (item.Key == key)
                    {
                        bucket.RemoveAt(count);
                        --_size;

                        if (bucket.Size == 0)
                        {
                            _table[index] = null;
                            --_occupied;
                        }

                        // check Load

                        return true;
                    }

                    ++count;
                }
            }

            return false;
        }

        public int GenerateHash(string s)
        {
            ulong hash = 5381;

            foreach (var c in s ?? "")
            {
                hash = ((hash << 5) + hash) + c;  // djb2: hash * 33 + c
            }

            return (int)(hash % _buckets);
        }
    }

    class KeyValue<T>
    {
        private string _key;

        public string Key { get { return _key; } }
        public T Value { get; set; }

        public KeyValue(string key, T value)
        {
            _key = key;
            Value = value;
        }
    }
}
