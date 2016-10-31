using System;

namespace DSA.Common
{
    public class Item
    {
        private static Random rand = new Random();
        private int _id;
        public string Name { get; set; }
        public int Id { get { return _id; } }

        public Item(string name)
        {
            Name = name;
            _id = rand.Next(1, 1000);
        }

        public string GetInfo()
        {
            return String.Format("id: {0}, name: {1}", Id, Name);
        }
    }
}
