using DataStructures.Graphs;
using DataStructures.Maps;

namespace Algorithms.Graphs
{
    public abstract class ShortestPath
    {
        protected HashTable<string> _previous = new HashTable<string>();
        protected HashTable<int> _distance = new HashTable<int>();
        protected bool _hasNegativeCycle = false;
        protected Graph _graph;

        public ShortestPath(Graph graph)
        {
            _graph = graph;
        }

        protected virtual void Clear()
        {
            _previous.Clear();
            _distance.Clear();
            _hasNegativeCycle = false;
        }

        public abstract ShortestPathResult Find(string source);
    }

    public class ShortestPathFactory
    {
        public static ShortestPath CreateShortestPath(Graph graph)
        {
            if (graph.HasNegativeWeight)
            {
                return new BellmanFord(graph);
            }
            else
            {
                return new Dijkstra(graph);
            }
        }
    }

    public class ShortestPathResult
    {
        public HashTable<string> Previous { get; }
        public HashTable<int> Distance { get; }
        public string Source { get; }
        public bool HasNegativeCycle { get; }

        public ShortestPathResult(HashTable<string> prev, HashTable<int> dist, string src, bool negCycle)
        {
            Previous = HashTable<string>.ShallowHashTableCopy(prev);
            Distance = HashTable<int>.ShallowHashTableCopy(dist);
            Source = src;
            HasNegativeCycle = negCycle;
        }
    }
}
