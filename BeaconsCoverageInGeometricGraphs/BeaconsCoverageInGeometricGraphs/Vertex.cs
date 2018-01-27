using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconsCoverageInGeometricGraphs
{
    /// <summary>
    /// Vertex of the geometric graph.
    /// Vertex inhertes from Point, as any vertex will be placed in some fixed position in the plane.
    /// Vertex exposes indexers and properties to access neighbors.
    /// </summary>
    public class Vertex:Point
    {
        List<Vertex> _adjacents;

        /// <summary>
        /// Internal neighbors list to be opperated from graph.
        /// </summary>
        internal List<Vertex> AdjacentsList => _adjacents;

        /// <summary>
        /// Creates a new vertex in the specified X,Y position.
        /// The new vertex will not have initially any neighbor.
        /// </summary>
        /// <param name="X">X position of the vertex.</param>
        /// <param name="Y">Y position of the vertex.</param>
        /// <param name="index"> Index of the vertex in the graph.</param>
        internal Vertex(double X, double Y, int index):base(X, Y)
        {
            _adjacents = new List<Vertex>();
            Index = index;
        }

        /// <summary>
        /// Gets the index of the vertex in the graph.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the degree of the vertex.
        /// </summary>
        public int Degree
        {
            get
            {
                return _adjacents.Count;
            }
        }

        /// <summary>
        /// Gets an IEnumerable of the neighbors of the vertex.
        /// </summary>
        public IEnumerable<Vertex> Adjacents
        {
            get
            {
                //*** Creo q hay una forma mas eficiente de devolver el enumerador de neighbors, aun sin exponer la lista directamente para q no le hagan cast.
                foreach (Vertex neighbor in _adjacents)
                    yield return neighbor;
            }
        }

        /// <summary>
        /// Gets the vertex neighbor at the specified index.
        /// </summary>
        /// <param name="index">The zero based index of the vertex neighbor to get.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Vertex this[int index]
        {
            get
            {
                if (index < 0 || index >= _adjacents.Count)
                    throw new IndexOutOfRangeException();

                return _adjacents[index];
            }
            internal set
            {
                _adjacents[index] = value;
            }
        }
    }
}
