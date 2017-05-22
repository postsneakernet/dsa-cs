using DataStructures.Maps;
using DataStructures.Trees;
using System;

namespace DataStructures.Graphs
{
    public abstract class Graph
    {
        protected ISet<string> _vertices;
        protected bool _isDense;
        protected bool _isDirected;
        protected bool _hasNegativeWeight;

        public ISet<string> Vertices { get { return _vertices; } }
        public bool IsDense { get { return _isDense; } }
        public bool IsDirected { get { return _isDirected; } }
        public bool HasNegativeWeight { get { return _hasNegativeWeight; } }

        public Graph(ISet<string> vertices)
        {
            _vertices = AvlTree<string>.ShallowSetCopy(vertices);
        }

        public abstract bool IsAdjacent(string x, string y);
        public abstract ISet<string> GetNeighbors(string vertex);
        public abstract ISet<Edge> GetNeighborsAsEdges(string vertex);
        public abstract void AddEdge(Edge e);
        public abstract void RemoveEdge(Edge e);

        protected bool Exists(string vertex)
        {
            return _vertices.Contains(vertex);
        }

        protected void ThrowIfNotExists(string vertex)
        {
            if (!Exists(vertex)) { throw new NoSuchVertexException(); }
        }

        protected void ThrowIfNotExists(string x, string y)
        {
            ThrowIfNotExists(x);
            ThrowIfNotExists(y);
        }

        public ISet<Edge> GetEdges()
        {
            ISet<Edge> edges = new AvlTree<Edge>();

            foreach (string v in Vertices)
            {
                edges.InsertAll(GetNeighborsAsEdges(v));
            }

            return edges;
        }

        public GraphComponents ExportComponents()
        {
            ISet<string> vertices = AvlTree<string>.ShallowSetCopy(_vertices);
            ISet<Edge> edges = new AvlTree<Edge>();

            foreach (string v in _vertices)
            {
                ISet<Edge> adjacencySet = GetNeighborsAsEdges(v);

                foreach (Edge e in adjacencySet)
                {
                    edges.Insert(new Edge(e.Source, e.Destination, e.Weight));
                }
            }

            return new GraphComponents(vertices, edges);
        }

        public void printGraph()
        {
            Console.Write("Graph Vertices: ");
            foreach (string v in _vertices)
            {
                Console.Write("{0} ");
            }
            Console.WriteLine();

            foreach (string v in _vertices)
            {
                Console.WriteLine("Vertex {0} Adjaceny List:", v);

                ISet<Edge> adjacencySet = GetNeighborsAsEdges(v);
                foreach (Edge e in adjacencySet)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    public class NoSuchVertexException : Exception
    {
        public NoSuchVertexException() { }
        public NoSuchVertexException(string message) : base(message) { }
        public NoSuchVertexException(string message, Exception inner) : base(message, inner) { }
    }

    public class Edge : IComparable
    {
        public string Source { get; }
        public string Destination { get; }
        public int Weight { get; set; } // default 1, e.g. undirected

        public Edge(string src, string dst)
        {
            Source = src;
            Destination = dst;
            Weight = 1;
        }

        public Edge(string src, string dst, int wt)
        {
            Source = src;
            Destination = dst;
            Weight = wt;
        }

        public override string ToString()
        {
            return String.Format("({0})---{1}---({2})", Source, Weight, Destination);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Edge otherEdge = obj as Edge;
            if (otherEdge == null)
            {
                throw new ArgumentException("Object is not an Edge");
            }

            int res = this.Source.CompareTo(otherEdge.Source);
            if (res != 0)
            {
                return res;
            }
            return this.Destination.CompareTo(otherEdge.Destination);
        }
    }

    public class GraphComponents
    {
        public ISet<string> Vertices { get; }
        public ISet<Edge> Edges { get; }

        public GraphComponents(ISet<string> vertices, ISet<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }
    }
}
