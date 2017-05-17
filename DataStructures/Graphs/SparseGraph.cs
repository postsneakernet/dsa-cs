using DataStructures.Maps;
using DataStructures.Trees;

namespace DataStructures.Graphs
{
    public class SparseGraph : Graph
    {
        private HashTable<ISet<Edge>> _vertexToAdjacencySet;

        public SparseGraph(ISet<string> vertices, ISet<Edge> edges, bool isDirected, bool hasNegativeWeight) : base(vertices)
        {
            _isDense = false;
            _isDirected = isDirected;
            _hasNegativeWeight = hasNegativeWeight;

            _vertexToAdjacencySet = new HashTable<ISet<Edge>>();

            foreach (string v in _vertices)
            {
                _vertexToAdjacencySet.Put(v, new AvlTree<Edge>());
            }

            foreach (Edge e in edges)
            {
                AddEdge(e);
            }
        }

        public override bool IsAdjacent(string x, string y)
        {
            ThrowIfNotExists(x, y);
            ISet<Edge> adjacencySet = _vertexToAdjacencySet.Get(x);
            return adjacencySet.Contains(new Edge(x, y));
        }

        public override ISet<string> GetNeighbors(string vertex)
        {
            ThrowIfNotExists(vertex);

            ISet<Edge> adjacencySet = _vertexToAdjacencySet.Get(vertex);

            ISet<string> neighbors = new AvlTree<string>();
            foreach (Edge e in adjacencySet)
            {
                neighbors.Insert(e.Destination);
            }

            return neighbors;
        }

        public override ISet<Edge> GetNeighborsAsEdges(string vertex)
        {
            ThrowIfNotExists(vertex);

            ISet<Edge> adjacencySet = _vertexToAdjacencySet.Get(vertex);

            ISet<Edge> neighbors = new AvlTree<Edge>();
            foreach (Edge e in adjacencySet)
            {
                neighbors.Insert(e);
            }

            return neighbors;
        }

        // if undirected, adding edge (A-B) will also add edge (B-A)
        public override void AddEdge(Edge e)
        {
            ThrowIfNotExists(e.Source, e.Destination);

            RemoveEdge(e); // remove first if present to allow update weight
            ISet<Edge> adjacencySet = _vertexToAdjacencySet.Get(e.Source);
            adjacencySet.Insert(e);

            if (!IsDirected)
            {
                Edge e2 = new Edge(e.Destination, e.Source, e.Weight);
                RemoveEdge(e2);
                adjacencySet = _vertexToAdjacencySet.Get(e.Destination);
                adjacencySet.Insert(e2);
            }
        }

        // if undirected, removing edge (A-B) will also remove edge (B-A)
        public override void RemoveEdge(Edge e)
        {
            ThrowIfNotExists(e.Source, e.Destination);

            ISet<Edge> adjacencySet = _vertexToAdjacencySet.Get(e.Source);
            adjacencySet.Remove(e);

            if (!IsDirected)
            {
                adjacencySet = _vertexToAdjacencySet.Get(e.Destination);
                adjacencySet.Remove(new Edge(e.Destination, e.Source, e.Weight));
            }
        }
    }
}
