using DataStructures.Graphs;
using DataStructures.Maps;
using DataStructures.Trees;
using System;

namespace Algorithms.Graphs
{
    public class Dijkstra : ShortestPath
    {
        private ISet<string> _visited = new AvlTree<string>();
        private BinaryHeap<VertexDistance> _queue = BinaryHeap<VertexDistance>.CreateMinHeap();

        public Dijkstra(Graph graph) : base(graph) { }

        protected override void Clear()
        {
            base.Clear();
            _visited = new AvlTree<string>();
            _queue = BinaryHeap<VertexDistance>.CreateMinHeap();
        }

        public override ShortestPathResult Find(string source)
        {
            Clear();

            foreach (string v in _graph.Vertices)
            {
                _distance.Put(v, int.MaxValue);
                _previous.Put(v, null);
            }

            _distance.Put(source, 0);
            _queue.Push(new VertexDistance(source, 0));

            while (!_queue.IsEmpty)
            {
                VertexDistance current = _queue.Pop();

                if (!_visited.Contains(current.Vertex))
                {
                    _visited.Insert(current.Vertex);
                    foreach (Edge e in _graph.GetNeighborsAsEdges(current.Vertex))
                    {
                        if (_distance.Get(current.Vertex) + e.Weight < _distance.Get(e.Destination))
                        {
                            _distance.Put(e.Destination, _distance.Get(current.Vertex) + e.Weight);
                            _previous.Put(e.Destination, current.Vertex);
                            _queue.Push(new VertexDistance(e.Destination, _distance.Get(e.Destination)));
                        }
                    }
                }
            }

            return new ShortestPathResult(_previous, _distance, source, _hasNegativeCycle);
        }
    }

    class VertexDistance : IComparable
    {
        public string Vertex { get; set; }
        public int Distance { get; set; }

        public VertexDistance(string v, int d)
        {
            Vertex = v;
            Distance = d;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            VertexDistance otherVertexDistance = obj as VertexDistance;
            if (otherVertexDistance == null)
            {
                throw new ArgumentException("Object is not a VertexDistance");
            }

            return this.Distance.CompareTo(otherVertexDistance.Distance);
        }
    }
}
