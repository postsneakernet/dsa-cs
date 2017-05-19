using DataStructures.Lists;
using DataStructures.Trees;
using System.Collections;

namespace DataStructures.Maps
{
    public class HashTable<T>
    {
        private const ulong _initialBuckets = 16;
        private ulong _buckets;
        private int _size;
        private int _occupied;
        private LinkedList<KeyValue<T>>[] _table;

        public int Size { get { return _size; } }
        public float Load { get { return (float) _occupied / _buckets; } }
        public int Slots { get { return (int) _buckets; } }

        public HashTable()
        {
            _buckets = _initialBuckets;
            _table = new LinkedList<KeyValue<T>>[_buckets];
            _size = 0;
            _occupied = 0;
        }

        public static HashTable<T> ShallowHashTableCopy(HashTable<T> originalTable)
        {
            HashTable<T> table = new HashTable<T>();
            foreach (KeyValue<T> kv in originalTable)
            {
                table.Put(kv.Key, kv.Value);
            }
            return table;
        }

        public T Get(string key)
        {
            int index = GenerateHash(key);
            LinkedList<KeyValue<T>> bucket = _table[index];

            if (bucket != null)
            {
                foreach (KeyValue<T> item in bucket)
                {
                    if (item.Key == key)
                    {
                        return item.Value;
                    }
                }
            }

            return default(T);
        }

        public void Put(string key, T value)
        {
            int index = GenerateHash(key);
            LinkedList<KeyValue<T>> bucket = _table[index];
            KeyValue<T> kv = new KeyValue<T>(key, value);

            if (bucket == null)
            {
                bucket = CreateBucket(index);
                AddKeyValue(bucket, kv);
                CheckLoad();
            } else
            {
                int count = 0;
                foreach (KeyValue<T> item in bucket)
                {
                    if (item.Key == key)
                    {
                        AddKeyValue(bucket, kv, count);
                        return;
                    }

                    ++count;
                }

                AddKeyValue(bucket, kv);
            }
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
                        RemoveKeyValue(bucket, count);

                        if (bucket.Size == 0) { DeleteBucket(index); }

                        return true;
                    }

                    ++count;
                }
            }

            return false;
        }

        public void Clear()
        {
            _buckets = _initialBuckets;
            _table = new LinkedList<KeyValue<T>>[_buckets];
            _size = 0;
            _occupied = 0;
        }

        public ISet<string> GetKeySet()
        {
            ISet<string> keySet = new AvlTree<string>();
            for (int i = 0; i < _table.Length; ++i)
            {
                if (_table[i] == null) { continue; }

                foreach (KeyValue<T> kv in _table[i])
                {
                    keySet.Insert(kv.Key);
                }
            }
            return keySet;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _table.Length; ++i)
            {
                if (_table[i] == null) { continue; }

                foreach (KeyValue<T> kv in _table[i])
                {
                    yield return kv;
                }
            }
        }

        private int GenerateHash(string s)
        {
            ulong hash = 5381;

            foreach (var c in s ?? "")
            {
                hash = ((hash << 5) + hash) + c;  // djb2: hash * 33 + c
            }

            return (int)(hash % _buckets);
        }

        private LinkedList<KeyValue<T>> CreateBucket(int index)
        {
            var bucket = new LinkedList<KeyValue<T>>();
            _table[index] = bucket;
            ++_occupied;

            return bucket;
        }

        private void DeleteBucket(int index)
        {
            _table[index] = null;
            --_occupied;
        }

        private void AddKeyValue(LinkedList<KeyValue<T>> bucket, KeyValue<T> kv, int index = -1)
        {
            if (index > -1)
            {
                bucket.RemoveAt(index);
                bucket.AddAt(index, kv);
            } else
            {
                bucket.Add(kv);
                ++_size;
            }
        }

        private void RemoveKeyValue(LinkedList<KeyValue<T>> bucket, int index)
        {
            bucket.RemoveAt(index);
            --_size;
        }

        private void CheckLoad()
        {
            if (Load < .75) { return; }

            var old = _table;
            _table = new LinkedList<KeyValue<T>>[_buckets * 2];
            _buckets = (ulong) _table.Length;
            _size = 0;
            _occupied = 0;

            for (int i = 0; i < old.Length; ++i)
            {
                if (old[i] == null) { continue; }

                foreach (KeyValue<T> kv in old[i])
                {
                    Put(kv.Key, kv.Value);
                }
            }
        }
    }

    public class KeyValue<T>
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
