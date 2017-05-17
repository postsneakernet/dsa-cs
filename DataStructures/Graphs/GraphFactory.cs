using DataStructures.Lists;
using DataStructures.Maps;
using DataStructures.Trees;
using System;

namespace DataStructures.Graphs
{
    public abstract class GraphFactory
    {
        public static Graph CreateGraph(GraphConfig gc)
        {
            Graph graph;
            if (gc.IsDense)
            {
                graph = new DenseGraph(gc.Vertices, gc.Edges, gc.IsDirected, gc.HasNegativeWeight);
            }
            else
            {
                graph = new SparseGraph(gc.Vertices, gc.Edges, gc.IsDirected, gc.HasNegativeWeight);
            }

            return graph;
        }
    }

    public class GraphConfig
    {
        private bool _isDense = false;
        private bool _isDirected = false;
        private bool _hasNegativeWeight = false;
        private ISet<string> _vertices;
        private ISet<Edge> _edges;

        public bool IsDense { get { return _isDense; } }
        public bool IsDirected { get { return _isDirected; } }
        public bool HasNegativeWeight { get { return _hasNegativeWeight; } }
        public ISet<string> Vertices { get { return _vertices; } }
        public ISet<Edge> Edges { get { return _edges; } }

        public GraphConfig CreateGraphConfig()
        {
            return new GraphConfig();
        }

        public GraphConfig SetDense()
        {
            _isDense = true;
            return this;
        }

        public GraphConfig SetDirected()
        {
            _isDirected = true;
            return this;
        }

        public GraphConfig SetNegativeWeight()
        {
            _hasNegativeWeight = true;
            return this;
        }

        public GraphConfig AddVertices(ISet<string> vertices)
        {
            if (_vertices == null)
            {
                _vertices = vertices;
            }
            else
            {
                foreach (string v in vertices)
                {
                    _vertices.Insert(v);
                }
            }

            return this;
        }

        public GraphConfig AddEdges(ISet<Edge> edges)
        {
            if (_edges == null)
            {
                _edges = edges;
            }
            else
            {
                foreach (Edge e in edges)
                {
                    _edges.Insert(e);
                }
            }

            return this;
        }

        public GraphConfig AddVertex(string vertex)
        {
            if (_vertices == null)
            {
                _vertices = new AvlTree<string>();
            }
            _vertices.Insert(vertex);

            return this;
        }

        public GraphConfig AddEdge(Edge edge)
        {
            if (_edges == null)
            {
                _edges = new AvlTree<Edge>();
            }
            _edges.Insert(edge);

            return this;
        }

        public Graph Build()
        {
            if (_vertices == null)
            {
                throw new InvalidStateException();
            }

            _edges = (_edges == null) ? new AvlTree<Edge>() : _edges;

            return GraphFactory.CreateGraph(this);
    }

    public class InvalidStateException : Exception
    {
        public InvalidStateException() { }
        public InvalidStateException(string message) : base(message) { }
        public InvalidStateException(string message, Exception inner) : base(message, inner) { }
    }
}
