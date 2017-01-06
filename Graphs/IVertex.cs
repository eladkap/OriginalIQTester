namespace Graphs
{
    interface IVertex
    {
        /// <summary>
        /// Returns the neighbor type if vertexIndex is a neighbor,
        /// and 0 otherwise
        /// </summary>
        /// <param name="vertexIndex">Vertex index</param>
        /// <returns>Neighbor type if neighbors and 0 othrewise</returns>
        int NeighborType(int vertexIndex);

        /// <summary>
        /// Returns true if neighbors and false otherwise
        /// </summary>
        /// <param name="vertexIndex">Vertex index</param>
        /// <returns>True if neighbors and false otherwise</returns>
        bool IsNeighbor(int vertexIndex);
    }
}
