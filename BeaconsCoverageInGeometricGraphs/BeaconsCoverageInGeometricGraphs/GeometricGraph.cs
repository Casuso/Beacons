using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconsCoverageInGeometricGraphs
{
    /// <summary>
    /// Geometric Graph.
    /// Every vertex has a fixed position in the plane and every edge represents a straight line segment that joins pairs of vertices.
    /// The graph will be simple, so, graph loops (edges from one vertex to himself) and multiple edges (two edges between to same vertices) are not allowed.
    /// </summary>
    public class GeometricGraph
    {
        List<Vertex> _vertices;

        /// <summary>
        /// Creates a new empty Geometric Graph. 
        /// </summary>
        public GeometricGraph()
        {
            _vertices = new List<Vertex>();
        }

        /// <summary>
        /// Gets an IEnumerable of the vertices of the graph.
        /// </summary>
        public IEnumerable<Vertex> Vertices
        {
            get
            {
                foreach (Vertex v in _vertices)
                    yield return v;
            }
        }

        /// <summary>
        /// Gets the vertex of the graph at the specified index.
        /// </summary>
        /// <param name="index">The zero based index of the vertex of the graph to get.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Vertex this[int index]
        {
            get
            {
                if (index < 0 || index >= _vertices.Count)
                    throw new IndexOutOfRangeException();

                return _vertices[index];
            }
        }

        /// <summary>
        /// Creates a new vertex in the specified postion, and adds it at the end of the graph.
        /// This method don't check if there is another vertex at the same position or if they are there three vertices in line.
        /// </summary>
        /// <param name="X">X position of the vertex.</param>
        /// <param name="Y">Y position of the vertex.</param>
        /// <returns>The new vertex created.</returns>
        public Vertex CreateAndAddVertexAt(double X, double Y)
        {
            Vertex v = new Vertex(X, Y, _vertices.Count);

            _vertices.Add(v);

            return v;
        }

        /// <summary>
        /// Adds and edge to the graph if the edge is not a graph loop or a multiple edge.
        /// </summary>
        /// <param name="u">One vertex of the edge.</param>
        /// <param name="v">The other vertex of the edge.</param>
        /// <returns>True if the edge is not a graph loop or a multiple edge. False in other case.</returns>
        /// <exception cref="InvalidOperationException">At least one of the vertices don't belong to this graph.</exception>  
        public bool AddEdge(Vertex u, Vertex v)
        {
            // check if the vertices belong to this graph
            if (u.Index >= _vertices.Count || _vertices[u.Index] != u || v.Index >= _vertices.Count || _vertices[v.Index] != v)
                throw new InvalidOperationException("Vertices must belong to the current graph.");


            // check possible graph loop
            if (u == v)
                return false;

            // check possible multiple edges
            if (v.Degree < u.Degree)
            {
                // swap u, v
                var temp = u;
                u = v;
                v = temp;
            }

            foreach (Vertex adjacent in u.AdjacentsList)
                if (adjacent == v)
                    return false;


            // add edge and return true
            u.AdjacentsList.Add(v);
            v.AdjacentsList.Add(u);

            return true;
        }
    }
}
