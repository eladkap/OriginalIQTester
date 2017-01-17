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
        /// Perform step and update the graph after the step
        /// </summary>
        /// <param name="step">step</param>
        void PerformStep(Step step);

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
