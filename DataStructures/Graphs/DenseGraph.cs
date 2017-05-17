using DataStructures.Maps;
using DataStructures.Trees;

namespace DataStructures.Graphs
{
    public class DenseGraph : Graph
    {
        private int[,] _adjacencyMatrix;
        private HashTable<int> _vertexToIndex;
        private HashTable<string> _indexToVertex;

        public DenseGraph(ISet<string> vertices, ISet<Edge> edges, bool isDirected, bool hasNegativeWeight) : base(vertices)
        {
            _isDense = true;
            _isDirected = isDirected;
            _hasNegativeWeight = hasNegativeWeight;

            _adjacencyMatrix = new int[vertices.Size, vertices.Size];
            initAdjacencyMatrix();

            _vertexToIndex = new HashTable<int>();
            _indexToVertex = new HashTable<string>();

            int index = 0;
            foreach (string v in _vertices)
            {
                _vertexToIndex.Put(v, index);
                _indexToVertex.Put(index.ToString(), v);
                ++index;
            }

            foreach (Edge e in edges)
            {
                AddEdge(e);
            }
        }

        public override bool IsAdjacent(string x, string y)
        {
            ThrowIfNotExists(x, y);
            return _adjacencyMatrix[_vertexToIndex.Get(x), _vertexToIndex.Get(y)] != int.MaxValue;
        }

        public override ISet<string> GetNeighbors(string vertex)
        {
            ThrowIfNotExists(vertex);

            int index = _vertexToIndex.Get(vertex);

            ISet<string> neighbors = new AvlTree<string>();
            for (int i = 0; i < _vertices.Size; ++i)
            {
                int weight = _adjacencyMatrix[index, i];
                if (weight != int.MaxValue)
                {
                    string dst = _indexToVertex.Get(i.ToString());
                    neighbors.Insert(dst);
                }
            }

            return neighbors;
        }

        public override ISet<Edge> GetNeighborsAsEdges(string vertex)
        {
            ThrowIfNotExists(vertex);

            int index = _vertexToIndex.Get(vertex);

            ISet<Edge> neighbors = new AvlTree<Edge>();
            for (int i = 0; i < _vertices.Size; ++i)
            {
                int weight = _adjacencyMatrix[index, i];
                if (weight != int.MaxValue)
                {
                    string dst = _indexToVertex.Get(i.ToString());
                    neighbors.Insert(new Edge(vertex, dst, weight));
                }
            }

            return neighbors;
        }

        // if undirected, adding edge (A-B) will also add edge (B-A)
        public override void AddEdge(Edge e)
        {
            ThrowIfNotExists(e.Source, e.Destination);

            int srcIndex = _vertexToIndex.Get(e.Source);
            int dstIndex = _vertexToIndex.Get(e.Destination);

            _adjacencyMatrix[srcIndex, dstIndex] = e.Weight;

            if (!IsDirected)
            {
                _adjacencyMatrix[dstIndex, srcIndex] = e.Weight;
            }
        }

        // if undirected, removing edge (A-B) will also remove edge (B-A)
        public override void RemoveEdge(Edge e)
        {
            ThrowIfNotExists(e.Source, e.Destination);

            int srcIndex = _vertexToIndex.Get(e.Source);
            int dstIndex = _vertexToIndex.Get(e.Destination);

            _adjacencyMatrix[srcIndex, dstIndex] = int.MaxValue;

            if (!IsDirected)
            {
                _adjacencyMatrix[dstIndex, srcIndex] = int.MaxValue;
            }
        }

        private void initAdjacencyMatrix()
        {
            for (int i = 0; i < _adjacencyMatrix.Length; ++i)
            {
                for (int j = 0; j < _adjacencyMatrix.Length; ++j)
                {
                    _adjacencyMatrix[i, j] = int.MaxValue;
                }
            }
        }
    }
}
