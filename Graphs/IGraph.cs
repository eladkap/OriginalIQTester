using System.Collections.Generic;

namespace Graphs
{
    public interface IGraph
    {
        void Show();

        /// <summary>
        /// Returns true if vertices i, j, k are neighbors such that
        /// they are aligned in the same direction
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns>True if vertices i, j, k are aligned neighbors</returns>
        bool AreAlignedNeighbors(int i, int j, int k);

        /// <summary>
        /// Checks if a legal move can be performed
        /// in posistions i, j, k
        /// </summary>
        /// <param name="i">Source position</param>
        /// <param name="j">Via position</param>
        /// <param name="k">Destination position</param>
        /// <returns>True if legal move and false otherwise</returns>
        bool IsLegalMove(int i, int j, int k);

        /// <summary>
        /// Performs legal move: transfer checker from position i
        /// to position k, and clear position j
        /// </summary>
        /// <param name="i">Source position</param>
        /// <param name="j">Via position</param>
        /// <param name="k">Destination position</param>
        /// <returns>True if move is legal and false otherwise</returns>
        bool Move(int i, int j, int k);

        /// <summary>
        /// Updates the graph after the move was performed
        /// </summary>
        /// <param name="i">Source position</param>
        /// <param name="j">Via position</param>
        /// <param name="k">Destination position</param>
        void UpdateGraphAfterMove(int i, int j, int k);

        /// <summary>
        /// Returns list of states of the vertices (has checker or not)
        /// </summary>
        /// <returns>List of states of the vertices (has checker or not)</returns>
        List<bool> GetVerticesState();

        /// <summary>
        /// Set checker in position index
        /// </summary>
        /// <param name="index">Vertex index</param>
        void SetChecker(int index);

        /// <summary>
        /// Unset checker in position index
        /// </summary>
        /// <param name="index">Vertex index</param>
        void UnsetChecker(int index);
    }
}
