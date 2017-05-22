using DataStructures.Graphs;

namespace Algorithms.Graphs
{
    public class BellmanFord : ShortestPath
    {
        public BellmanFord(Graph graph) : base(graph) { }

        public override ShortestPathResult Find(string source)
        {
            Clear();
            Initialize(source);

            for (int i = 0; i < _graph.Vertices.Size - 1; ++i)
            {
                foreach (Edge e in _graph.GetEdges())
                {
                    Relax(e.Source, e);
                }
            }

            foreach (Edge e in _graph.GetEdges())
            {
                if (Relax(e.Source, e))
                {
                    _hasNegativeCycle = true;
                }
            }

            return new ShortestPathResult(_previous, _distance, source, _hasNegativeCycle);
        }
    }
}
