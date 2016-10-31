using DataStructures.Graphs;
using DataStructures.Lists;
using DataStructures.Maps;
using DataStructures.Trees;
using DSA.Common;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting data structure program");

            HashTable<Item> h = new HashTable<Item>();

            string[] list = { "lamp", "desk", "chair", "fridge", "pencil", "pen" };
            foreach (var s in list)
            {
                h.Put(s, new Item(s));
            }

            string[] list2 = { "lamp1", "desk1", "chair1", "fridge1", "pencil", "pen" };
            foreach (var s in list2)
            {
                h.Put(s, new Item(s));
                //h.Get(s);
            }

            Item i1 = new Item("lamp");

            h.Put(i1.Name, i1);


            Item result = h.Get("lamp");

            Console.WriteLine(result.GetInfo());

            Console.WriteLine(h.Load);

            Console.WriteLine("finished data structure program");
            Console.Read();
        }
    }
}
