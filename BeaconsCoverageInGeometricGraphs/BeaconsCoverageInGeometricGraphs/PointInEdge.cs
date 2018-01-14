using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconsCoverageInGeometricGraphs
{
    /// <summary>
    /// PointInEdge is a point which is strictly inside the straight line segment represented by an edge. 
    /// PointInEdge inhertes from Point, as it has a fixed position in the plane.
    /// PointInEdge exposes properties to get the edge that represents the straight line segment that contains it strictly.
    /// </summary>
    public class PointInEdge:Point
    {
        /// <summary>
        /// Gets the edge (tuple of vertex) that represents the straight line segment that contains it strictly.
        /// </summary>
        public (Vertex u, Vertex v) Edge{ get; private set; }

        /// <summary>
        /// Creates a new PointInEdge in the specified position, strictly inside the straight line segment represented by the specified edge.
        /// It will not check if the specified position is strictly inside the straight line segment represented by the specified edge. It will assume it.
        /// </summary>
        /// <param name="X">X postion of the point.</param>
        /// <param name="Y">Y postion of the point.</param>
        /// <param name="edge">Edge (tuple of vertex) that represents the straight line segment that contains it strictly.</param>
        internal PointInEdge(double X, double Y, (Vertex u, Vertex v) edge) : base(X, Y)
        {
            Edge = edge;
        }
    }
}
